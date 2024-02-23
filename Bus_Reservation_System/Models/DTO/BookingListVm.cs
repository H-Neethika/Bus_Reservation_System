using Bus_Reservation_System.Models.Domain;

namespace Bus_Reservation_System.Models.DTO
{
    public class BookingListVm
    {
        public IQueryable<Booking>? BookingList { get; set; }
    }
}
