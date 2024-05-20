using InternTest_Backend.Entities;
using InternTest_Backend.Interfaces;
using InternTest_Backend.Requests;

namespace InternTest_Backend.Services
{
    public class BillStatusService : IBillStatusService
    {
        private AppDbContext _context = new AppDbContext();

        public List<billStatuses> LoadBillStatuses(LoadBillStatusRequest request)
        {
            var res = _context.billStatuses.ToList();
            if (request.Id.HasValue)
            {
                res = res.Where(x => x.Id == request.Id).ToList();
            }
            return res;
        }
    }
}
