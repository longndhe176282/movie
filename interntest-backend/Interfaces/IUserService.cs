using InternTest_Backend.Entities;
using InternTest_Backend.Models;
using InternTest_Backend.Requests;

namespace InternTest_Backend.Interfaces
{
    public interface IUserService
    {
        string Register(RegisterRequest registerModel);
        string ConfirmRegisterEmail(string email, string confirmCode);
        users Login(LoginRequest loginModel);
        string ForgetPassword(string email);
        string ConfirmResetEmail(string email, string code);
        List<users> LoadUser();
        string DeleteUser(int id);
        string AddNewUser(NewUserRequest newUser);
        string UpdateUser(UpdateUserRequest updatingUser);
        string ChangePassword(string accessToken, ChangePasswordRequest request);
        users UpdateUserProfile(string accessToken, UpdateProfileRequest request);
    }
}
