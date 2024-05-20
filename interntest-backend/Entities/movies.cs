using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternTest_Backend.Entities
{
    public class movies
    {
        [Key]
        public int Id { get; set; }
        public int MovieDuration {  get; set; }
        public DateTime EndTime { get; set;}
        public DateTime PremiereDate { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Image {  get; set; }
        public string Language { get; set; }
        public int MovieTypeId { get; set; }
        public string Name { get; set; }
        public int RateId { get; set; }
        public string Trailer {  get; set; }
        public bool IsActive { get; set; }
        public string HeroImage {  get; set; }


        [ForeignKey("MovieTypeId")]
        public virtual movieTypes MovieTypes { get; set; }

        [ForeignKey("RateId")]
        public virtual rates Rates { get; set; }

        public virtual ICollection<schedules> Schedules { get; set; }

        public movies(int movieDuration, DateTime endTime, DateTime premiereDate, string description, string director, string image, string language, int movieTypeId, string name, int rateId, string trailer, bool isActive, string heroImage)
        {
            MovieDuration = movieDuration;
            EndTime = endTime;
            PremiereDate = premiereDate;
            Description = description;
            Director = director;
            Image = image;
            Language = language;
            MovieTypeId = movieTypeId;
            Name = name;
            RateId = rateId;
            Trailer = trailer;
            IsActive = isActive;
            HeroImage = heroImage;
        }
    }
}
