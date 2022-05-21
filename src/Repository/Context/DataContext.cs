using Microsoft.EntityFrameworkCore;
using Model.Domain;

namespace Repository.Context
{
    // this is used for our verification tests, don't rename or change the access modifier
    public class DataContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    
    }
}