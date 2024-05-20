using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class refreshTokens
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredTime { get; set; }
        public int UderId { get; set; }

        [ForeignKey("UserId")]
        public virtual users Users { get; set; }
    }
}
