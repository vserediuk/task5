using Microsoft.EntityFrameworkCore;
using task5.Data.Models;

namespace task5.Data
{
    public class Task5DbContext: DbContext
    {
        public Task5DbContext(DbContextOptions<Task5DbContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }

}
