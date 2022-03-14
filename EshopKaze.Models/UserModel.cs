namespace EshopKaze.Models
{
    public class UserModel
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
       

        public UserModel()
        {

        }

        public UserModel(int id, string username, string password, string fullname, string role)
        {
            Id = id;
            Username = username;
            Password = password;
            Fullname = fullname;
            Role = role;
        }

        
    }
}