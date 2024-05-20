using InternTest_Backend.Entities;
using InternTest_Backend.Models;

namespace InternTest_Backend.Interfaces
{
    public interface IMovieService
    {
        List<movies> LoadMovie(LoadMovieRequest request);

        string DeleteMovie(int id);
        string AddNewMovie(NewMovieRequest newMovie);
        string UpdateMovie(UpdateMovieRequest updatingMovie);
    }
}
