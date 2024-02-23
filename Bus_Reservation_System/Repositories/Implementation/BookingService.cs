using Bus_Reservation_System.Models.Domain;
using Bus_Reservation_System.Models.DTO;
using Bus_Reservation_System.Repositories.Abstract;

namespace Bus_Reservation_System.Repositories.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly DatabaseContext ctx;
        public BookingService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Booking model)
        {
            try
            {
                ctx.Booking.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if (data == null)
                    return false;
                ctx.Booking.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Booking GetById(int id)
        {
            return ctx.Booking.Find(id);
        }

        public BookingListVm List(string term1 = "", string term2 = "", DateTime term3 = default(DateTime))
        {
            var List = ctx.Booking.ToList();
        
            var data = new BookingListVm
            {
                BookingList = List.AsQueryable()
            };

            return data;

        }

        public bool Update(Booking model)
        {
            try
            {
                ctx.Booking.Update(model);
                
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<int> GetBusTypeByBusId(int busId)
        {
            var busTypeIds = ctx.BusBusType.Where(a => a.BusId == busId).Select(a => a.BusTypeId).ToList();
                return busTypeIds;
        }
    }
}
