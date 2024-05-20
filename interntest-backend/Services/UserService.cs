using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using InternTest_Backend.Requests;

namespace InternTest_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context = new AppDbContext();

        public string ConfirmRegisterEmail(string email, string confirmCode)
        {
            users user = _context.users.FirstOrDefault(x => x.Email == email && x.IsActive == true);
            if (user == null)
            {
                return "Email khong ton tai";
            }
            if (isValidActiveCode(email, confirmCode))
            {
                user.UserStatusId = 2;
                _context.SaveChanges();
                return "Da xac thuc email kick hoat tai khoan";
            }
            return "Ma code khong hop le";
        }

        private bool isValidActiveCode(string email, string code)
        {
            confirmEmails confirmEmail = _context.confirmEmails.Include(c => c.Users).Where(x => x.Users.Email == email && x.Users.IsActive == true && x.IsConfirm == false).OrderByDescending(x => x.RequiredDateTime).FirstOrDefault();
            if (confirmEmail == null)
            {
                return false;
            }
            if (confirmEmail.ExpiredDateTime < DateTime.Now || confirmEmail.RequiredDateTime > DateTime.Now)
            {
                return false;
            }
            if (confirmEmail.ConfirmCode == code)
            {
                confirmEmail.IsConfirm = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        private bool isValidResetCode(string email, string code)
        {
            confirmEmails confirmEmail = _context.confirmEmails.Include(c => c.Users).FirstOrDefault(x => x.ConfirmCode == code);
            if (confirmEmail == null)
            {
                return false;
            }
            if (confirmEmail.ExpiredDateTime < DateTime.Now || confirmEmail.RequiredDateTime > DateTime.Now)
            {
                return false;
            }
            if (confirmEmail.Users.Email == email)
            {
                confirmEmail.IsConfirm = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        private string randomPassword()
        {
            Random rd = new Random();
            return rd.Next(10000000, 99999999).ToString();
        }

        public string ConfirmResetEmail(string email, string resetCode)
        {
            users user = _context.users.FirstOrDefault(x => x.Email == email && x.IsActive == true);
            if (user == null)
            {
                return "Email khong ton tai";
            }
            if (isValidResetCode(email, resetCode))
            {

                string newPassword = randomPassword();

                string fromMail = "long2003.2014@gmail.com";
                string fromPassword = "lkel bktt rnek ahtb";

                var emailToConfirm = new MailMessage();
                emailToConfirm.From = new MailAddress("long2003.2014@gmail.com");
                emailToConfirm.Subject = "Mat khau moi sau khi reset";
                emailToConfirm.To.Add(new MailAddress(email));
                emailToConfirm.Body = "Mat khau moi cua ban la: " + newPassword;
                emailToConfirm.IsBodyHtml = true;

                var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(emailToConfirm);

                user.Password = newPassword;
                _context.SaveChanges();

                return "Da reset mat khau tai khoan, mat khau moi da duoc gui den gmail";
            }
            return "Ma code khong hop le";
        }

        public string ForgetPassword(string email)
        {
            users user = getUserByEmail(email);
            if (user == null)
            {
                return "Email khong ton tai";
            }

            string resetCode = randomCode();

            string fromMail = "long2003.2014@gmail.com";
            string fromPassword = "lkel bktt rnek ahtb";

            var emailToConfirm = new MailMessage();
            emailToConfirm.From = new MailAddress("long2003.2014@gmail.com");
            emailToConfirm.Subject = "xac thuc email de dat lai mat khau";
            emailToConfirm.To.Add(new MailAddress(email));
            emailToConfirm.Body = "Ma xac thuc cua ban la: " + resetCode;
            emailToConfirm.IsBodyHtml = true;

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(emailToConfirm);

            _context.confirmEmails.Add(new confirmEmails(user.Id, DateTime.Now, DateTime.Now.AddMinutes(5), resetCode, false));
            _context.SaveChanges();

            return "Da gui ma xac nhan den gmail";
        }

        public List<users> LoadUser()
        {
            return _context.users.Where(x => x.IsActive == true).ToList();
        }

        public users Login(LoginRequest loginModel)
        {
            users user = getUserByUsername(loginModel.username);
            if (user == null || !matchedUser(user, loginModel.password) || user.UserStatusId == 1)
            {
                return null;
            }

            return user;
        }

        public string getAccessToken(int userId)
        {
            return GenerateAccessToken(userId);
        }

        private bool matchedUser(users user, string password)
        {
            if (user.Password == password)
            {
                return true;
            }
            return false;
        }

        private users getUserByUsername(string username)
        {
            foreach (users u in _context.users.Where(x => x.IsActive == true).ToList())
            {
                if (u.Username == username) { return u; }
            }
            return null;
        }

        private users getUserByEmail(string email)
        {
            foreach (users u in _context.users.Where(x => x.IsActive == true).ToList())
            {
                if (u.Email == email) { return u; }
            }
            return null;
        }

        public string Register(RegisterRequest registerModel)
        {
            users user = getUserByEmail(registerModel.email);
            if (user != null)
            {
                return "Email đã được sử dụng";
            }
            user = getUserByUsername(registerModel.username);
            if (user != null)
            {
                return "Tên người dùng đã được sử dụng";
            }
            if (registerModel.password != registerModel.repeatPassword)
            {
                return "Mật khâu và nhập lại mật khẩu không khớp";
            }

            _context.users.Add(new users(0, registerModel.username, registerModel.email, registerModel.name, registerModel.phonenumber, registerModel.password, 4, 1, true, 4));

            _context.SaveChanges();


            string confirmCode = randomCode();

            string fromMail = "long2003.2014@gmail.com";
            string fromPassword = "lkel bktt rnek ahtb";

            var emailToConfirm = new MailMessage();
            emailToConfirm.From = new MailAddress("long2003.2014@gmail.com");
            emailToConfirm.Subject = "xac thuc email de dang nhap beta cinema";
            emailToConfirm.To.Add(new MailAddress(registerModel.email));
            emailToConfirm.Body = "Ma xac thuc cua ban la: " + confirmCode;
            emailToConfirm.IsBodyHtml = true;

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(emailToConfirm);

            users confirmingUser = getUserByUsername(registerModel.username);

            DateTime requied = DateTime.Now;
            DateTime expired = DateTime.Now.AddMinutes(5);

            _context.confirmEmails.Add(new confirmEmails(confirmingUser.Id, requied, expired, confirmCode, false));
            _context.SaveChanges();


            return "Đã đăng ký thành công, hãy kiểm tra email để lấy mã xác thực";
        }

        private string randomCode()
        {
            Random rd = new Random();
            return rd.Next(100000, 999999).ToString();
        }

        public string DeleteUser(int id)
        {
            if (!isExistedId(id))
            {
                return "Id không tồn tại";
            }
            users deleteUser = _context.users.FirstOrDefault(x => x.Id == id && x.IsActive == true);
            deleteUser.IsActive = false;
            _context.SaveChanges(true);
            return "Đã xóa thành công";
        }

        private bool isExistedId(int id)
        {
            foreach (users u in _context.users.Where(x => x.IsActive == true).ToList())
            {
                if (u.Id == id && u.IsActive == true) return true;
            }
            return false;
        }

        private bool isExistedUsername(string username)
        {
            foreach (users u in _context.users.Where(x => x.IsActive == true).ToList())
            {
                if (u.Username == username && u.IsActive == true) return true;
            }
            return false;
        }

        private bool isExistedAnotherUsername(int id, string username)
        {
            foreach (users u in _context.users.Where(x => x.Id != id && x.IsActive == true).ToList())
            {
                if (u.Username == username && u.IsActive == true) return true;
            }
            return false;
        }


        private bool isExistedEmail(string email)
        {
            foreach (users u in _context.users.Where(x => x.IsActive == true).ToList())
            {
                if (u.Email == email && u.IsActive == true) return true;
            }
            return false;
        }

        private bool isExistedAnotherEmail(int id, string email)
        {
            foreach (users u in _context.users.Where(x => x.Id != id && x.IsActive == true).ToList())
            {
                if (u.Email == email && u.IsActive == true) return true;
            }
            return false;
        }

        public string AddNewUser(NewUserRequest newUser)
        {
            if (isExistedUsername(newUser.username))
            {
                return "Tên người dùng đã tồn tại";
            }
            if (isExistedEmail(newUser.email))
            {
                return "Email đã tồn tại";
            }
            users temp = new users(newUser.point, newUser.username, newUser.email, newUser.name, newUser.phonenumber, newUser.password, newUser.rankCustomerId, newUser.userStatusId, true, newUser.roleId);
            _context.users.Add(temp);
            _context.SaveChanges();
            return "Đã thêm thành công";
        }

        private string GenerateAccessToken(int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(IConstant.constant.secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("userIdType", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Audience = "Postman",
                Issuer = "BetaCinema",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string ChangePassword(string accessToken, ChangePasswordRequest request)
        {
            try
            {
                if (request.newPassword != request.repeatNewPassword)
                {
                    return "Mật khẩu mới và lập lại mật khẩu mới không khớp, hãy kiểm tra lại";
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(IConstant.constant.secretKey);

                tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "userIdType").Value);

                var user = _context.users.FirstOrDefault(x => x.Id == userId);
                if (user.Password != request.oldPassword)
                {
                    return "Mật khẩu cũ không đúng không thể cập nhật mật khẩu";
                }
                if (user == null)
                {
                    return "Không tìm thấy người dùng phù hợp";
                }

                user.Password = request.newPassword;

                _context.SaveChanges();

                return "Đã thay đổi mật khẩu thành công";
            }
            catch (SecurityTokenExpiredException)
            {
                return "Phiên đăng nhập đã hết hạn vui lòng đăng nhập lại";
            }
        }



        public users UpdateUserProfile(string accessToken, UpdateProfileRequest request)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(IConstant.constant.secretKey);

                tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "userIdType").Value);

                var user = _context.users.FirstOrDefault(x => x.Id == userId && x.IsActive == true);
                if (user == null)
                {
                    return null;
                }

                user.Name = request.name;
                user.Email = request.email;
                user.PhoneNumber = request.phoneNumber;

                _context.SaveChanges();
                return user;
            }
            catch (SecurityTokenExpiredException)
            {
                return null;
            }
        }


        public string UpdateUser(UpdateUserRequest updatingUser)
        {
            if (!isExistedId(updatingUser.id))
            {
                return "Id không tồn tại";
            }
            if (isExistedAnotherUsername(updatingUser.id, updatingUser.username))
            {
                return "Tên người dùng đã tồn tại";
            }
            if (isExistedAnotherEmail(updatingUser.id, updatingUser.email))
            {
                return "Email đã tồn tại";
            }
            users oldUser = _context.users.FirstOrDefault(x => x.Id == updatingUser.id);
            oldUser.Point = updatingUser.point;
            oldUser.Name = updatingUser.name;
            oldUser.Email = updatingUser.email;
            oldUser.Username = updatingUser.username;
            oldUser.Password = updatingUser.password;
            oldUser.PhoneNumber = updatingUser.phonenumber;
            oldUser.RankCustomerId = updatingUser.rankCustomerId;
            oldUser.UserStatusId = updatingUser.userStatusId;
            oldUser.RoleId = updatingUser.roleId;
            _context.SaveChanges();
            return "Đã cập nhật thành công";
        }
    }
}
