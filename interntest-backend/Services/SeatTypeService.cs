using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;

namespace InternTest_Backend.Services
{
    public class SeatTypeService : ISeatTypeService
    {
        private AppDbContext _context = new AppDbContext();

        public List<seatTypes> LoadSeatType()
        {
            return _context.seatTypes.ToList();
        }
    }
}
