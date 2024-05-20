using InternTest_Backend.Entities;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;

namespace InternTest_Backend.Interfaces
{
    public interface IRoomService
    {
        List<rooms> LoadRoom(LoadRoomRequest request);
        string DeleteRoom(int id);
        string AddNewRoom(NewRoomRequest newRoom);
        string UpdateRoom(UpdateRoomRequest updatingRoom);
    }
}
