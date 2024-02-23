using Bus_Reservation_System.Models.DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bus_Reservation_System.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<BusType> BusType { get; set; }
        public DbSet<BusBusType> BusBusType { get; set; }
        public DbSet<Bus> Bus { get; set; }
        public DbSet<Booking> Booking { get; set; }

        

    }
}
