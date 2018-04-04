using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminCrud.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string EmailId { get; set; }
        public Role UserRole { get; set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }
        public User()
        {
            // TODO remove this
            CreatedAt = DateTimeOffset.Now;
        }
    }

    public enum Role
    {
        Guest, User, Moderator, Admin
    }
}
