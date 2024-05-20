using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Requests;
using InternTest_Backend.VnpayObj;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace InternTest_Backend.Services
{
    public class BillService : IBillService
    {
        private readonly AppDbContext _context = new AppDbContext();

        public string CreateBill(CreateBillRequest request)
        {
            try
            {
                var temp = new bills(request.TotalMoney, request.TradingCode, request.CreateTime, request.CustomerId, request.Name, request.CreateAt, request.PromotionId, request.IsActive, request.BillStatusId);
                _context.bills.Add(temp);
                _context.SaveChanges();
                if (request.FoodId.HasValue)
                {
                    _context.billFoods.Add(new billFoods(request.FoodQuantity, temp.Id, request.FoodId));
                    _context.SaveChanges(true);
                }
                _context.billTickets.Add(new billTickets(request.TicketQuantity, temp.Id, request.TicketId));
                _context.SaveChanges();
                return "Đã tạo hóa đơn thành công";
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
        }

        public string PayBill(HttpContext context, double price, string movieName)
        {
            string vnp_Returnurl = "http://localhost:8080/result";
            string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
            string vnp_TmnCode = "B2YBA1ZO";
            string vnp_HashSecret = "FEASBPMNMWPUKPJRNROEFYNPGUNQOYRB";

            OrderInfo order = new OrderInfo();
            order.OrderId = DateTime.Now.Ticks;
            order.Amount = (long)price;
            order.Status = "0";
            order.CreatedDate = DateTime.Now;

            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());
            vnpay.AddRequestData("vnp_BankCode", null);

            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", context.Connection.RemoteIpAddress.ToString());

            vnpay.AddRequestData("vnp_Locale", "vn");

            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan hoa don xem phim " + movieName);
            vnpay.AddRequestData("vnp_OrderType", "other");

            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            return paymentUrl;
        }

        public string PayLastBillSuccess(string accessToken)
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
            int userId = int.Parse(jwtToken.Claims.First(x => x.Type == "userIdType").Value);

            users user = _context.users.FirstOrDefault(x => x.Id == userId);

            bills lastBill = _context.bills.Include(x => x.Promotions).ThenInclude(x => x.RankCustomers).OrderByDescending(x => x.CreateTime).FirstOrDefault(x => x.CustomerId == userId);

            if (lastBill != null)
            {
                lastBill.BillStatusId = 2;
                _context.SaveChanges();
            }
            user.Point += (int?)Math.Round((double)((lastBill.Promotions.Percent * lastBill.Promotions.RankCustomers.Point) / 100));
            _context.SaveChanges();

            return "Đã xác nhận thành công";
        }
    }
}
