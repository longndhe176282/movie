using InternTest_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternTest_Backend.Entities
{
    public class AppDbContext : DbContext
    {

        public DbSet<banners> banners { get; set; }
        public DbSet<billFoods> billFoods { get; set; }
        public DbSet<bills> bills { get; set; }
        public DbSet<billStatuses> billStatuses { get; set; }
        public DbSet<billTickets> billTickets { get; set; }
        public DbSet<cinemas> cinemas { get; set; }
        public DbSet<confirmEmails> confirmEmails { get; set; }
        public DbSet<foods> foods { get; set; }
        public DbSet<generalSettings> generalSettings { get; set; }
        public DbSet<movies> movies { get; set; }
        public DbSet<movieTypes> movieTypes { get; set; }
        public DbSet<promotions> promotions { get; set; }
        public DbSet<rankCustomers> rankCustomers { get; set; }
        public DbSet<rates> rates { get; set; }
        public DbSet<refreshTokens> refreshTokens { get; set; }
        public DbSet<roles> roles { get; set; }
        public DbSet<rooms> rooms { get; set; }
        public DbSet<schedules> schedules { get; set; }
        public DbSet<seats> seats { get; set; }
        public DbSet<seatsStatus> seatsStatus { get; set; }
        public DbSet<seatTypes> seatTypes { get; set; }
        public DbSet<tickets> tickets { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<userStatuses> userStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =(local); database = Project_Movie;uid=sa;pwd=123456;TrustServerCertificate=True;Trusted_Connection=True;");

        }
    }
}
