using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AdminCrud.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder opts)
        {
            opts.UseSqlServer(@"Server=Delli5\SQLEx; Database = master; User id=sa;Password=info123!");
        }


        public DbSet<User> Users { get; set; }
    }
}