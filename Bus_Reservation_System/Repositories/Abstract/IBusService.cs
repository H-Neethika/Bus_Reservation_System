using Bus_Reservation_System.Models.Domain;
using Bus_Reservation_System.Models.DTO;

namespace Bus_Reservation_System.Repositories.Abstract
{
    public interface IBusService
    {
        bool Add(Bus model);
        bool Update(Bus model);

        Bus GetById(int id);
        bool Delete(int id);

        BusListVm List(string term1 = "", string term2 = "", string term3 = "", bool paging = false, int currentPage = 0);

        List<int> GetSBusTypeByBusId(int busId);

    }
}
