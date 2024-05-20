using InternTest_Backend.Entities;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;

namespace InternTest_Backend.Interfaces
{
    public interface ICinemaService
    {
        List<cinemas> LoadCinema(LoadCinemaRequest request);
        string DeleteCinema(int id);
        string AddNewCinema(NewCinemaRequest newCinema);
        string UpdateCinema(UpdateCinemaRequest updatingCinema);
    }
}
