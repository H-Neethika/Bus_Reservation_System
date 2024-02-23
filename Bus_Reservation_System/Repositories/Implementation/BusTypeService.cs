using Bus_Reservation_System.Models.Domain;
using Bus_Reservation_System.Repositories.Abstract;

namespace Bus_Reservation_System.Repositories.Implementation
{
    public class BusTypeService : IBusTypeService
    {
        private readonly DatabaseContext ctx;

        public BusTypeService(DatabaseContext ctx)
        {
            this.ctx = ctx;   
        }
        public bool Add(BusType model)
        {
            try
            {
                ctx.BusType.Add(model);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.GetById(id);
                if(data == null)
                    return false;
                ctx.BusType.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public BusType GetById(int id)
        {
            return ctx.BusType.Find(id);
        }

        public IQueryable<BusType> List()
        {
            var data = ctx.BusType.AsQueryable();
            return data;    
        }

        public bool Update(BusType model)
        {
            try
            {
                ctx.BusType.Update(model);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
