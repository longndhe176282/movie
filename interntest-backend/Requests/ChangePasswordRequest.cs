namespace InternTest_Backend.Requests
{
    public class ChangePasswordRequest
    {
        public string oldPassword {  get; set; }
        public string newPassword { get; set; }
        public string repeatNewPassword { get; set; }
    }
}
