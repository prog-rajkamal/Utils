using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminCrud.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private FakeUser userList;

        public UserController()
        {
            this.userList = FakeUser.GetUsers();
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            lock (this.userList.Users)
            {
                return this.userList.Users;
            }
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {

                return Ok(this.userList.Users.First(us => us.Id == id));
            }
            catch (Exception)
            {

                //this.Redirect("User not found");
                return NotFound("User not found");
            }
        }

        // POST: api/User
        [HttpPost]
        public User Post([FromBody]User value)
        {

            lock (this.userList.Users)
            {

                this.userList.Users.Add(new Models.User()
                {
                    Name = value.Name,
                    DateOfBirth = value.DateOfBirth,
                    UserRole = value.UserRole,
                    EmailId = value.EmailId,
                    Id = this.userList.Users.Last().Id + 1,
                });
            }

            return this.userList.Users.Last();

        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            var num = this.userList.Users.RemoveAll(usr => usr.Id == id);
            if (num == 0)
            {
                return Json(new { StatusCode = 404, Message = "NO User was found." });
            }
            return Json(new { StatusCode = 200, Message = "User was deleted succesfully." });
        }
    }
}
