using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;

namespace InternTest_Backend.Services
{
    public class BannerService : IBannerService
    {
        private readonly AppDbContext _context = new AppDbContext();

        public List<banners> LoadBanner()
        {
            return _context.banners.ToList();
        }
    }
}
