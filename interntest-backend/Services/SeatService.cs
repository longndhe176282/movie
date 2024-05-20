using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Models;

namespace InternTest_Backend.Services
{
    public class SeatService : ISeatService
    {
        private AppDbContext _context = new AppDbContext();

        private bool isExistedId(int id)
        {
            foreach (seats s in _context.seats.ToList())
            {
                if (s.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public List<seats> LoadSeat()
        {
            return _context.seats.Where(x => x.IsActive == true).ToList();
        }

        public string DeleteSeat(int id)
        {
            if (!isExistedId(id))
            {
                return "Id không tồn tại";
            }
            _context.seats.FirstOrDefault(x => x.Id == id).IsActive = false;
            _context.SaveChanges();
            return "Đã xóa thành công";
        }

        public string AddNewSeat(NewSeatRequest newSeat)
        {
            seats temp = new seats(newSeat.Number, newSeat.SeatStatusId, newSeat.Line, newSeat.RoomId, newSeat.IsActive, newSeat.SeatTypeId);
            _context.seats.Add(temp);
            _context.SaveChanges();
            return "Đã thêm thành công";
        }

        public string UpdateSeat(UpdateSeatRequest updatingSeat)
        {
            if (!isExistedId(updatingSeat.Id))
            {
                return "Id không tồn tại";
            }
            seats oldSeat = _context.seats.FirstOrDefault(x => x.Id == updatingSeat.Id);
            oldSeat.Number = updatingSeat.Number;
            oldSeat.SeatStatusId = updatingSeat.SeatStatusId;
            oldSeat.SeatTypeId = updatingSeat.SeatTypeId;
            oldSeat.Line = updatingSeat.Line;
            oldSeat.RoomId = updatingSeat.RoomId;
            oldSeat.IsActive = updatingSeat.IsActive;
            _context.SaveChanges();
            return "Đã cập nhật thành công";
        }
    }
}
