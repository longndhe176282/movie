using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;
using Microsoft.EntityFrameworkCore;

namespace InternTest_Backend.Services
{
    public class RoomService : IRoomService
    {
        private AppDbContext _context = new AppDbContext();


        private bool isExistedId(int id)
        {
            foreach(rooms r in _context.rooms.ToList())
            {
                if (r.Id == id)
                {
                    return true;
                }    
            }    
            return false;
        }

        public string AddNewRoom(NewRoomRequest newRoom)
        {
            rooms temp = new rooms(newRoom.Capacity, newRoom.Type, newRoom.Description, newRoom.CinemaId, newRoom.Code, newRoom.Name, newRoom.IsActive);
            _context.rooms.Add(temp);
            _context.SaveChanges();
            return "Đã thêm thành công";
        }

        public string DeleteRoom(int id)
        {
            if (!isExistedId(id))
            {
                return "Id không tồn tại";
            }
            _context.rooms.FirstOrDefault(x => x.Id == id).IsActive = false;
            _context.SaveChanges();
            return "Đã xóa thành công";
        }

        public List<rooms> LoadRoom(LoadRoomRequest request)
        {
            var res = _context.rooms.Where(x => x.IsActive == true).Include(x => x.Schedules).Include(x => x.Cinemas).ToList();
            if(request.Id.HasValue)
            {
                res = res.Where(x => x.Id == request.Id).ToList();
            }    
            if(request.movieId.HasValue)
            {
                res = res.Where(x => x.Schedules.Any(x => x.MovieId == request.movieId)).ToList();
            }    
            if(request.CinemaId.HasValue)
            {
                res = res.Where(x => x.CinemaId == request.CinemaId).ToList();
            }    
            return res;
        }

        public string UpdateRoom(UpdateRoomRequest updatingRoom)
        {
            if (!isExistedId(updatingRoom.Id))
            {
                return "Id không tồn tại";
            }
            rooms oldRoom = _context.rooms.FirstOrDefault(x => x.Id == updatingRoom.Id);
            oldRoom.Name = updatingRoom.Name;
            oldRoom.IsActive = updatingRoom.IsActive;
            oldRoom.Capacity = updatingRoom.Capacity;
            oldRoom.Description = updatingRoom.Description;
            oldRoom.CinemaId = updatingRoom.CinemaId;
            oldRoom.Code = updatingRoom.Code;
            oldRoom.Type = updatingRoom.Type;
            _context.SaveChanges();
            return "Đã cập nhật thành công";
        }
    }
}
