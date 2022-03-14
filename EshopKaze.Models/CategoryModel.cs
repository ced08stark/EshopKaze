namespace EshopKaze.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }

        public CategoryModel() { }

        public CategoryModel(int id, string name, int userId, UserModel user)
        {
            Id = id;
            Name = name;
            UserId = userId;
            User = user;
        }

       
    }
}