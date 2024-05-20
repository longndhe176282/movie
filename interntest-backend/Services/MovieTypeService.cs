using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;

namespace InternTest_Backend.Services
{
    public class MovieTypeService : IMovieTypeService
    {
        private readonly AppDbContext _context = new AppDbContext();
        public List<movieTypes> LoadMovieType()
        {
            return _context.movieTypes.ToList();
        }
    }
}
