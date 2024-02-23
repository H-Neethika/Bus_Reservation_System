using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bus_Reservation_System.Models.Domain
{
    public class Bus
    {
        public int Id { get; set; }
        [Required]
        public string? BusNo { get; set; }
        [Required]
        public string? BusName { get; set; }

        public string? BusImage { get; set; }
        [Required]
        public int SeatCapacity { get; set; }
        [Required]
        public string? From { get; set; }
        [Required]
        public string? To { get; set; }
        [Required]
        public string? BusStops { get; set; }
        [Required]
        public string? DepartureTime { get; set; }
        [Required]
        public string? ArrivalTime { get; set; }
        [Required]
        public string? TravelDate { get; set; }
        [Required]
        public int BookingPrice { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [Required]
        public List<int>? BusTypes { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? BusTypeList { get; set; }
        [NotMapped]
        public string? BusTypeNames { get; set; }
        [NotMapped]
        public MultiSelectList? MultiBusTypeList { get; set; }
    }
}
