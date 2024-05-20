using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class cinemas
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string NameOfCinema { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<rooms> Rooms { get; set; }

        public cinemas(string address, string description, string code, string nameOfCinema, bool isActive)
        {
            Address = address;
            Description = description;
            Code = code;
            NameOfCinema = nameOfCinema;
            IsActive = isActive;
        }
    }
}
