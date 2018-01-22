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
            // this.userList = FakeUser.GetUsers();
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using (var context = new UserContext())
            {
                return context.Users.ToList();
            }
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                using (var context = new UserContext())
                {
                    return Ok(context.Users.First(us => us.Id == id));
                }
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



            using (var context = new UserContext())
            {
                var newUser = new Models.User()
                {
                    Name = value.Name,
                    DateOfBirth = value.DateOfBirth,
                    UserRole = value.UserRole,
                    EmailId = value.EmailId,
                };
                context.Users.Add(newUser);
                context.SaveChanges();
                return newUser;
            }


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
            using (var cxt = new UserContext())
            {
                var delUser = cxt.Users.Find(id);
                if (delUser == null)
                {
                    return Json(new { StatusCode = 404, Message = "NO User was found." });
                }
                cxt.Users.Remove(delUser);
                cxt.SaveChanges();

            }

            return Json(new { StatusCode = 200, Message = "User was deleted succesfully." });
        }
    }
}
