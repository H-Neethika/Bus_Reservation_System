using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bus_Reservation_System.Models.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public string? BusNo { get; set; }
        [Required]
        public string? TravelDate { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? NIC_or_Passport { get; set; }
        [Required]
        public string? Email { get; set; }
       

        public string? PaymentSlip { get; set;}


        [NotMapped]
        public IFormFile? ImageFile { get; set; }



    }
}
