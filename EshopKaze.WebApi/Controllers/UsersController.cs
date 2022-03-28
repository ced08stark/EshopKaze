using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EshopKaze.Models;
using EshopKaze.Repository;


namespace EshopKaze.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UserRepository userRepository;
        public UsersController()
        {
            userRepository = new UserRepository();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var user  = userRepository.Get(id);
            if (user == null)
                return NotFound();
            return Ok(MapUser(user));
        }


        [HttpGet]
        public IHttpActionResult Get(string username)
        {
            var user = userRepository.Get(username);
            if (user == null)
                return NotFound();
            return Ok(MapUser(user));
        }


        [HttpGet]
        public IHttpActionResult Login(string username, string password)
        {
            var user = userRepository.Get(username, password);
            if (user == null)
                return NotFound();
            return Ok(MapUser(user));
        }


        [HttpPost]
        public IHttpActionResult Post([FromBody] UserModel userModel)
        {

                if (userModel == null)
                    return BadRequest();
                var user = new User(0, userModel.Username, userModel.Password, userModel.Fullname, userModel.Role);
                user = userRepository.Add(user);

                return Ok(MapUser(user));
          
            
            
        }


        [HttpPut]
        public IHttpActionResult Put(UserModel userModel)
        {

            try
            {
                if (userModel == null)
                    return BadRequest();
                var user = new User(userModel.Id, userModel.Username, userModel.Password, userModel.Fullname, userModel.Role);
                user = userRepository.Set(user);

                return base.Ok(MapUser(user));
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DuplicateWaitObjectException)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        private UserModel MapUser(User user)
        {
            return new UserModel(user?.Id ?? 0, user?.Username, user?.Password, user?.Fullname, user?.Role);
        }
    }
}
