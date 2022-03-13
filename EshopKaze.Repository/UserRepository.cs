using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EshopKaze.Repository
{

   
    public class UserRepository
    {
        private readonly EshopKazeEntities db;

        public UserRepository()
        {
            db = new EshopKazeEntities();
        }

        public User Get(int id)
        {
            return db.User.FirstOrDefault(x => x.Id == id);
        }

        public User Get(string username)
        {
            return db.User.FirstOrDefault(x => x.Username == username);
        }


        public User Get(string username, string password)
        {
            var user = Get(username);
            if (user?.Password == CreateMD5Hash(password))
                return user;
            return null;
        }


        public User Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));


            var u = Get(user.Username);

            if (u != null)
                throw new DuplicateWaitObjectException($"Username {user.Username} already exist !");
            user.Password = CreateMD5Hash(user.Password);
            user = db.User.Add(user);
            db.SaveChanges();
            return user;
        }


        public User Set(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));


            var currentDb = new EshopKazeEntities();

            var OldUser = currentDb.User.Find(user.Id);

            if (OldUser == null)
                throw new KeyNotFoundException($"User not found!");

            var u = currentDb.User.FirstOrDefault(x => x.Username == user.Username);

            if (u != null && u.Id != OldUser.Id)
                throw new DuplicateWaitObjectException($"Username {user.Username} already exist !");

            user.Password = String.IsNullOrEmpty(user.Password) || OldUser.Password != user.Password?CreateMD5Hash(user.Password):user.Password;

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return user;
        }

        public string CreateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i<hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));

            }

            return sb.ToString();

        }


    }
}
