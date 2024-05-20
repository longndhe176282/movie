using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Collections.Generic;
using System.Linq;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace InternTest_Backend.Services
{
    public class ScheduleService : IScheduleService
    {
        private AppDbContext _context;

        public ScheduleService()
        {
            _context = new AppDbContext();
        }

        private bool isExistedId(int id)
        {
            foreach (schedules m in _context.schedules.ToList())
            {
                if (m.Id == id && m.IsActive == true) return true;
            }
            return false;
        }

        public string AddNewSchedule(NewScheduleRequest newSchedule)
        {
            schedules temp = new schedules(newSchedule.Price, newSchedule.StartAt, newSchedule.EndAt, newSchedule.Code, newSchedule.MovieId, newSchedule.Name, newSchedule.RoomId, newSchedule.IsActive);
            foreach (schedules s in _context.schedules.Where(x => x.IsActive == true).ToList())
            {
                if ((temp.StartAt < s.StartAt && s.StartAt < temp.EndAt && s.RoomId == temp.RoomId) ||
                    (temp.StartAt < s.EndAt && s.EndAt < temp.EndAt && s.RoomId == temp.RoomId) ||
                    (s.StartAt < temp.StartAt && temp.StartAt < s.EndAt && s.RoomId == temp.RoomId) ||
                    (s.StartAt < temp.EndAt && temp.EndAt < s.EndAt && s.RoomId == temp.RoomId))
                {
                    return "Phòng này đã có lịch đặt không thể thêm lịch mới";
                }
            }
            _context.schedules.Add(temp);
            _context.SaveChanges();
            return "Đã thêm thành công";
        }

        public string DeleteSchedule(int id)
        {
            if (!isExistedId(id))
            {
                return "Id không tồn tại";
            }
            _context.schedules.FirstOrDefault(x => x.Id == id).IsActive = false;
            _context.SaveChanges();
            return "Đã xóa thành công";
        }

        public List<schedules> LoadSchedule(LoadScheduleRequest request)
        {
            List<schedules> res = _context.schedules.Include(x => x.Rooms).Where(x => x.IsActive == true).ToList();
            if (request.LowerDate.HasValue && request.UpToDate.HasValue)
            {
                res = res.Where(x => x.StartAt >= request.LowerDate && x.EndAt <= request.UpToDate).ToList();
            }
            if (request.LowerPrice.HasValue && request.UpToPrice.HasValue)
            {
                res = res.Where(x => x.Price >= request.LowerPrice && x.Price <= request.UpToPrice).ToList();
            }
            if (request.MovieId.HasValue)
            {
                res = res.Where(x => x.MovieId == request.MovieId).ToList();
            }
            if (request.CinemaId.HasValue)
            {
                res = res.Where(x => x.Rooms.CinemaId == request.CinemaId).ToList();
            }
            if (request.RoomId.HasValue)
            {
                res = res.Where(x => x.RoomId == request.RoomId).ToList();
            }
            return res;
        }

        public string UpdateSchedule(UpdateScheduleRequest updatingSchedule)
        {
            if (!isExistedId(updatingSchedule.Id))
            {
                return "Id không tồn tại";
            }
            foreach (schedules s in _context.schedules.Where(x => x.IsActive == true && x.Id != updatingSchedule.Id).ToList())
            {
                if ((updatingSchedule.StartAt < s.StartAt && s.StartAt < updatingSchedule.EndAt && s.RoomId == updatingSchedule.RoomId) ||
                    (updatingSchedule.StartAt < s.EndAt && s.EndAt < updatingSchedule.EndAt && s.RoomId == updatingSchedule.RoomId) ||
                    (s.StartAt < updatingSchedule.StartAt && updatingSchedule.StartAt < s.EndAt && s.RoomId == updatingSchedule.RoomId) ||
                    (s.StartAt < updatingSchedule.EndAt && updatingSchedule.EndAt < s.EndAt && s.RoomId == updatingSchedule.RoomId))
                {
                    return "Phòng này đã có lịch đặt không thể thêm lịch mới";
                }
            }
            schedules oldSchedule = _context.schedules.FirstOrDefault(x => x.Id == updatingSchedule.Id);
            oldSchedule.Price = updatingSchedule.Price;
            oldSchedule.StartAt = updatingSchedule.StartAt;
            oldSchedule.EndAt = updatingSchedule.EndAt;
            oldSchedule.Code = updatingSchedule.Code;
            oldSchedule.MovieId = updatingSchedule.MovieId;
            oldSchedule.Name = updatingSchedule.Name;
            oldSchedule.RoomId = updatingSchedule.RoomId;
            oldSchedule.IsActive = updatingSchedule.IsActive;
            _context.SaveChanges();
            return "Đã cập nhật thành công";
        }
    }
}
