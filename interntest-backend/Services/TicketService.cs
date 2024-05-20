using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Requests;
using Microsoft.EntityFrameworkCore;

namespace InternTest_Backend.Services
{
    public class TicketService : ITicketService
    {
        private AppDbContext _context = new AppDbContext();
        public List<tickets> LoadTicket(LoadTicketRequest request)
        {
            var res = _context.tickets.Include(x => x.Schedules).Include(x => x.Seats).ToList();
            if (request.Id.HasValue)
            {
                res = res.Where(x => x.Id == request.Id).ToList();
            }
            if(request.MovieId.HasValue)
            {
                res = res.Where(x => x.Schedules?.MovieId == request.MovieId).ToList();
            }
            if (request.RoomId.HasValue)
            {
                res = res.Where(x => x.Seats.RoomId == request.RoomId).ToList();
            }
            if(request.ScheduleId.HasValue)
            {
                res = res.Where(x => x.ScheduleId == request.ScheduleId).ToList();
            }    
            return res;
        }
    }
}
