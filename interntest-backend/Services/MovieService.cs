using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;
using System.Linq;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace InternTest_Backend.Services
{
    public class MovieService : IMovieService
    {
        private AppDbContext _context;

        public MovieService()
        {
            _context = new AppDbContext();
        }

        private bool isExistedId(int id)
        {
            foreach (movies m in _context.movies.ToList())
            {
                if (m.Id == id && m.IsActive == true) return true;
            }
            return false;
        }

        public string AddNewMovie(NewMovieRequest newMovie)
        {
            movies temp = new movies(newMovie.MovieDuration, newMovie.EndTime, newMovie.PremiereDate, newMovie.Description, newMovie.Director, newMovie.Image, newMovie.Language, newMovie.MovieTypeId, newMovie.Name, newMovie.RateId, newMovie.Trailer, newMovie.IsActive, newMovie.HeroImage);
            _context.movies.Add(temp);
            _context.SaveChanges();
            return "Đã thêm thành công";
        }

        public string DeleteMovie(int id)
        {
            if(!isExistedId(id)) 
            {
                return "Id không tồn tại";
            }
            _context.movies.FirstOrDefault(x => x.Id == id).IsActive = false;
            _context.SaveChanges();
            return "Đã xóa thành công";
        }

        public List<movies> LoadMovie(LoadMovieRequest request)
        {
            List<movies> res = _context.movies.Include(x => x.Rates).Include(x => x.MovieTypes).Include(x => x.Schedules).ThenInclude(x => x.Rooms).ThenInclude(x => x.Seats).Where(x => x.IsActive == true).ToList();
            if(request.Id.HasValue)
            {
                res = res.Where(x => x.Id == request.Id).ToList();
            }
            if (request.MovieTypeId.HasValue)
            {
                res = res.Where(x => x.MovieTypeId == request.MovieTypeId).ToList();
            }
            if(request.CinemaId.HasValue)
            {
                res = res.Where(x => x.Schedules.Any(y => y.Rooms.CinemaId == request.CinemaId)).ToList();
            }
            if (request.RoomId.HasValue)
            {
                res = res.Where(x => x.Schedules.Any(y => y.RoomId == request.RoomId)).ToList();
            }
            if (request.filterWithEmptySeat == true)
            {
                res = res.Where(x => x.Schedules.Any(y => y.Rooms.Seats.Any(z => z.SeatStatusId == 1))).ToList();
            }
            return res;
        }

        public string UpdateMovie(UpdateMovieRequest updatingMovie)
        {
            if (!isExistedId(updatingMovie.Id))
            {
                return "Id không tồn tại";
            }
            movies oldMovie = _context.movies.FirstOrDefault(x => x.Id == updatingMovie.Id);
            oldMovie.MovieDuration = updatingMovie.MovieDuration;
            oldMovie.EndTime = updatingMovie.EndTime;
            oldMovie.PremiereDate = updatingMovie.PremiereDate;
            oldMovie.Description = updatingMovie.Description;
            oldMovie.Director = updatingMovie.Director;
            oldMovie.Image = updatingMovie.Image;
            oldMovie.Language = updatingMovie.Language;
            oldMovie.MovieTypeId = updatingMovie.MovieTypeId;
            oldMovie.Name = updatingMovie.Name;
            oldMovie.RateId = updatingMovie.RateId;
            oldMovie.Trailer = updatingMovie.Trailer;
            oldMovie.IsActive = updatingMovie.IsActive;
            oldMovie.HeroImage = updatingMovie.HeroImage;
            _context.SaveChanges();
            return "Đã cập nhật thành công";
        }
    }
}
