using System.ComponentModel.DataAnnotations;

namespace InternTest_Backend.Entities
{
    public class billStatuses
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
