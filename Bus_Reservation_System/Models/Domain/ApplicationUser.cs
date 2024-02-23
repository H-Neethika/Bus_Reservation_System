using Microsoft.AspNetCore.Identity;

namespace Bus_Reservation_System.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
