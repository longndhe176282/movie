namespace InternTest_Backend.Models
{
    public class NewUserRequest
    {
        public int point {  get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phonenumber { get; set; }
        public int rankCustomerId { get; set; }
        public int userStatusId { get; set; }
        public int roleId { get; set; }
    }
}
