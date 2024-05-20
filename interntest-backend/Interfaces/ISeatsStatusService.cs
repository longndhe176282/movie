using InternTest_Backend.Entities;

namespace InternTest_Backend.Interfaces
{
    public interface ISeatsStatusService
    {
        List<seatsStatus> LoadSeatStatus();
    }
}
