using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EshopKaze.Repository;

namespace EshopKaze.WebApi.Models
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

        public UserModel(User user):this(user?.Id??0, user?.Username, user?.Password, user?.Fullname, user?.Role)
        {
            
        }
    }
}