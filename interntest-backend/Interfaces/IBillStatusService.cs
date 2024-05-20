using InternTest_Backend.Entities;
using InternTest_Backend.Requests;

namespace InternTest_Backend.Interfaces
{
    public interface IBillStatusService
    {
        List<billStatuses> LoadBillStatuses(LoadBillStatusRequest request);
    }
}
