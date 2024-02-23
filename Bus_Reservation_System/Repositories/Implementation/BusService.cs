using Bus_Reservation_System.Models.Domain;
using Bus_Reservation_System.Models.DTO;
using Bus_Reservation_System.Repositories.Abstract;

namespace Bus_Reservation_System.Repositories.Implementation
{
    public class BusService : IBusService
    {
        private readonly DatabaseContext ctx;

        public BusService(DatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Bus model)
        {
            try
            {
                ctx.Bus.Add(model);
                ctx.SaveChanges();
                foreach (int busTypeId in model.BusTypes)
                {
                    var busBusType = new BusBusType
                    {
                        BusId = model.Id,
                        BusTypeId = busTypeId
                    };
                    ctx.BusBusType.Add(busBusType);
                }
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
                var busBusTypes = ctx.BusBusType.Where(a => a.BusId == data.Id);
                foreach (var busBusType in busBusTypes)
                {
                    ctx.BusBusType.Remove(busBusType);
                }
                ctx.Bus.Remove(data);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Bus GetById(int id)
        {
            return ctx.Bus.Find(id);
        }

        public BusListVm List(string term1 = "", string term2 = "", string term3 = "", bool paging = false, int currentPage = 0)
        {
            var data = new BusListVm();

            var list = ctx.Bus.ToList();

            if (!string.IsNullOrEmpty(term1))
            {
                term1 = term1.ToLower();
                list = list.Where(a => a.From.ToLower().StartsWith(term1)).ToList();
            }

            if (!string.IsNullOrEmpty(term2))
            {
                term2 = term2.ToLower();
                list = list.Where(b => b.To.ToLower().StartsWith(term2)).ToList();
            }

            if (!string.IsNullOrEmpty(term3))
            {
                term3 = term3.ToLower();
                list = list.Where(c => c.TravelDate.ToLower().StartsWith(term3)).ToList();
            }


            foreach (var Bus in list)
            {
                var BusTypes = (from BusType in ctx.BusType
                                join mg in ctx.BusBusType
                                       on BusType.Id equals mg.BusTypeId
                                where mg.BusId == Bus.Id
                                select BusType.BusTypeName
                                       ).ToList();
                var BusTypeNames = string.Join(',', BusTypes);
                Bus.BusTypeNames = BusTypeNames;
            }
            data.BusList = list.AsQueryable();
            return data;
        }

        public bool Update(Bus model)
        {
            try
            {
                var BusTypeToDeleted = ctx.BusBusType.Where(a => a.BusId == model.Id && !model.BusTypes.Contains(a.BusTypeId)).ToList();
                foreach (var BusBusType in BusTypeToDeleted)
                {
                    ctx.BusBusType.Remove(BusBusType);
                }
                foreach (int speciId in model.BusTypes)
                {
                    var BusBusType = ctx.BusBusType.FirstOrDefault(a => a.BusId == model.Id && a.BusTypeId == speciId);
                    if (BusBusType == null)
                    {
                        BusBusType = new BusBusType { BusTypeId = speciId, BusId = model.Id };
                        ctx.BusBusType.Add(BusBusType);
                    }
                }
                ctx.Bus.Update(model);

                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> GetSBusTypeByBusId(int BusId)
        {
            var BusTypeIds = ctx.BusBusType.Where(a => a.BusId == BusId).Select(a => a.BusTypeId).ToList();
            return BusTypeIds;
        }

        public IQueryable<Bus> List()
        {
            var data = ctx.Bus.AsQueryable();
            return data;
        }
    }
}
