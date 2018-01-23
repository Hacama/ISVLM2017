using System;
using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ISVLM2017.Domain.Concrete
{
    public class EFStockTransaccionRepository : IStockTransaccionRepository
    {
        private EFDbContext context = new EFDbContext();
        public void grabarEjemplares(StockTransaccion st)
        {
            context.StockTransacciones.Add(st);
            context.SaveChanges();
        }
    }
}
