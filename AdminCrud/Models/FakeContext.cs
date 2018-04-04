using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCrud.Models
{
    public class FakeUser
    {
        private static FakeUser _single;
        public FakeUser()
        {
            //int user_seq = 1;
            Users = new List<User>();

            for (int user_seq = 1; user_seq < 100; user_seq++)
            {

                Users.Add(new User()
                {
                    Id = user_seq,
                    Name = "User " + user_seq,
                    EmailId = String.Format("user{0}@crud.com", user_seq),
                    DateOfBirth = new DateTimeOffset(1980 + user_seq, user_seq % 12 + 1, user_seq % 28 + 1, 0, 0, 0, TimeSpan.Zero),
                    UserRole = Role.User
                });
            }

        }

        internal static FakeUser GetUsers()
        {
            var a = new { };
            lock (a)
            {
                if (_single == null)
                {
                    _single = new FakeUser();
                }
            }
            return _single;
        }

        public List<User> Users { get; set; }
    }
}
