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
            this.userList = new FakeUser();
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this.userList.Users;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            try {

                return this.userList.Users.First( us => us.Id == id);
            }
            catch(Exception) {

                //this.Redirect("User not found");
                throw new Exception("User not found");
            }
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
