using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class confirmEmails
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime RequiredDateTime { get; set; }
        public DateTime ExpiredDateTime { get; set; }
        public string? ConfirmCode { get; set; }
        public bool IsConfirm { get; set; }


        [ForeignKey("UserId")]
        public virtual users Users { get; set; }

        public confirmEmails() { }

        public confirmEmails(int? userId, DateTime requiredDateTime, DateTime expiredDateTime, string? confirmCode, bool isConfirm)
        {
            this.UserId = userId;
            this.RequiredDateTime = requiredDateTime;
            this.ExpiredDateTime = expiredDateTime;
            this.ConfirmCode = confirmCode;
            this.IsConfirm = isConfirm;
        }
    }
}
