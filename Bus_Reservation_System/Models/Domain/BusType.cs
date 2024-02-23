using System.ComponentModel.DataAnnotations;

namespace Bus_Reservation_System.Models.Domain
{
    public class BusType
    {
        public int Id { get; set; }

        [Required]
        public string? BusTypeName { get; set; }
    }
}
