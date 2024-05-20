namespace InternTest_Backend.Models
{
    public class RegisterRequest
    {
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string repeatPassword { get; set; }
        public string phonenumber { get; set; }
    }
}
