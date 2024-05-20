using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;

namespace InternTest_Backend.Services
{
    public class SeatsStatusService : ISeatsStatusService
    {
        private AppDbContext _context = new AppDbContext();

        public List<seatsStatus> LoadSeatStatus()
        {
            return _context.seatsStatus.ToList();
        }
    }
}
