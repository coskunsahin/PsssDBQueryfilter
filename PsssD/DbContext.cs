using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PsssD
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
      
       
        public DbSet<User> Users  { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
 