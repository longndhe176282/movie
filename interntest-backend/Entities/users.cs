using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class users
    {
        [Key]
        public int Id { get; set; }
        public int? Point { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int? RankCustomerId { get; set; }
        public int? UserStatusId { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("UserStatusId")]
        public virtual userStatuses? UserStatuses { get; set; }

        [ForeignKey("RankCustomerId")]
        public virtual rankCustomers? RankCustomers { get; set; }

        public virtual ICollection<refreshTokens>? RefreshTokens { get; set; }

        public virtual ICollection<bills>? Bills { get; set; }

        [ForeignKey("RoleId")]
        public virtual roles? Roles { get; set; }

        public virtual ICollection<confirmEmails>? ConfirmEmails { get; set; }

        public users()
        {

        }

        public users(int? point, string username, string email, string name, string phoneNumber, string password, int? rankCustomerId, int? userStatusId, bool isActive, int roleId)
        {
            Point = point;
            Username = username;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
            Password = password;
            RankCustomerId = rankCustomerId;
            UserStatusId = userStatusId;
            IsActive = isActive;
            RoleId = roleId;
        }
    }
}
