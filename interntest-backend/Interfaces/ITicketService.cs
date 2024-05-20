using InternTest_Backend.Entities;
using InternTest_Backend.Requests;

namespace InternTest_Backend.Interfaces
{
    public interface ITicketService
    {
        List<tickets> LoadTicket(LoadTicketRequest request);
    }
}
