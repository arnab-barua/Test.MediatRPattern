using Microsoft.EntityFrameworkCore;

namespace MediatRPattern.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Customer> Customers { get; set; }
    }
}
