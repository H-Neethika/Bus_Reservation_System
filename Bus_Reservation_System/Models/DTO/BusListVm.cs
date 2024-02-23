using Bus_Reservation_System.Models.Domain;

namespace Bus_Reservation_System.Models.DTO
{
    public class BusListVm
    {
        public IQueryable<Bus>?BusList { get; set; }

    }
}
