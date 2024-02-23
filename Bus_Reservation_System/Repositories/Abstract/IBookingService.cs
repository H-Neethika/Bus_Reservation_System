using Bus_Reservation_System.Models.Domain;
using Bus_Reservation_System.Models.DTO;
using Humanizer.Localisation;

namespace Bus_Reservation_System.Repositories.Abstract
{
    public interface IBookingService
    {
        bool Add(Booking model);
        bool Update(Booking model);
        Booking GetById(int id);
        bool Delete(int id);
        BookingListVm List(string term1 = "", string term2 = "", DateTime term3= default(DateTime));
        List<int> GetBusTypeByBusId(int busId);
    }
}
