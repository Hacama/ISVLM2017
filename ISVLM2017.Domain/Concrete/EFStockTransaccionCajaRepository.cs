using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ISVLM2017.Domain.Concrete
{
    public class EFStockTransaccionCajaRepository : IStockTransaccionCajaRepository
    {
        private EFDbContext context = new EFDbContext();
        public void grabarTransaccion(StockTransaccionCaja stc)
        {
            context.StockTransaccionCajas.Add(stc);
            context.SaveChanges();
        }
    }
}
