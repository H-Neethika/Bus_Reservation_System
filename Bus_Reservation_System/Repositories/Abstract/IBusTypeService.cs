using Bus_Reservation_System.Models.Domain;
using Bus_Reservation_System.Models.DTO;

namespace Bus_Reservation_System.Repositories.Abstract
{
    public interface IBusTypeService
    {
        bool Add(BusType model);
        bool Update(BusType model);

        BusType GetById(int id);
        bool Delete(int id);

        IQueryable<BusType> List();


    }
}
