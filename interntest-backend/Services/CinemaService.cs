using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;
using Microsoft.EntityFrameworkCore;

namespace InternTest_Backend.Services
{
    public class CinemaService : ICinemaService
    {
        private AppDbContext _context = new AppDbContext();

        private bool isExistedId(int id)
        {
            foreach (cinemas c in _context.cinemas.ToList())
            {
                if (c.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public string AddNewCinema(NewCinemaRequest newCinema)
        {
            cinemas temp = new cinemas(newCinema.Address, newCinema.Description, newCinema.Code, newCinema.NameOfCinema, newCinema.IsActive);
            _context.cinemas.Add(temp);
            _context.SaveChanges();
            return "Đã thêm thành công";
        }

        public string DeleteCinema(int id)
        {
            if (!isExistedId(id))
            {
                return "Id không tồn tại";
            }
            _context.cinemas.FirstOrDefault(x => x.Id == id).IsActive = false;
            _context.SaveChanges();
            return "Đã xóa thành công";
        }

        public List<cinemas> LoadCinema(LoadCinemaRequest request)
        {
            var res = _context.cinemas.Where(x => x.IsActive == true).Include(x => x.Rooms).ThenInclude(x => x.Schedules).ThenInclude(x => x.Tickets).ThenInclude(x => x.BillTickets).ThenInclude(x => x.Bills).ToList();
            if (request.Id.HasValue)
            {
                res = res.Where(x => x.Id == request.Id).ToList();
            }
            if (request.movieId.HasValue)
            {
                res = res.Where(x => x.Rooms.Any(x => x.Schedules.Any(x => x.MovieId == request.movieId))).ToList();
            }
            return res;
        }

        public string UpdateCinema(UpdateCinemaRequest updatingCinema)
        {
            if (isExistedId(updatingCinema.Id))
            {
                return "Id không tồn tại";
            }
            cinemas oldCinema = _context.cinemas.FirstOrDefault(x => x.Id == updatingCinema.Id);
            oldCinema.Address = updatingCinema.Address;
            oldCinema.Code = updatingCinema.Code;
            oldCinema.NameOfCinema = updatingCinema.NameOfCinema;
            oldCinema.Description = updatingCinema.Description;
            oldCinema.IsActive = updatingCinema.IsActive;
            _context.SaveChanges();
            return "Đã cập nhật thành công";
        }
    }
}
