using Assignment2.Shared;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Server.Data
{
    public class MyDBContext : DbContext

    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
    }
}
