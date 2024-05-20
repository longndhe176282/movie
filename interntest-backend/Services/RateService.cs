using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;

namespace InternTest_Backend.Services
{
    public class RateService : IRateService
    {
        private AppDbContext _context = new AppDbContext();

        public List<rates> LoadRate()
        {
            return _context.rates.ToList();
        }
    }
}
