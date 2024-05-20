using InternTest_Backend.Entities;
using InternTest_Backend.Requests;

namespace InternTest_Backend.Interfaces
{
    public interface IScheduleService
    {
        List<schedules> LoadSchedule(LoadScheduleRequest request);

        string DeleteSchedule(int id);

        string AddNewSchedule(NewScheduleRequest request);

        string UpdateSchedule(UpdateScheduleRequest request);
    }
}
