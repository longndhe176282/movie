using InternTest_Backend.Entities;
using InternTest_Backend.Models;

namespace InternTest_Backend.Interfaces
{
    public interface ISeatService
    {
        List<seats> LoadSeat();
        string DeleteSeat(int id);
        string AddNewSeat(NewSeatRequest newSeat);
        string UpdateSeat(UpdateSeatRequest updatingSeat);
    }
}
