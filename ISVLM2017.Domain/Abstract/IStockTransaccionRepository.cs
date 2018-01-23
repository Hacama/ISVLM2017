using System.Collections.Generic;
using ISVLM2017.Domain.Entities;


namespace ISVLM2017.Domain.Abstract
{
   public interface IStockTransaccionRepository
    {
       void grabarEjemplares(StockTransaccion st);
    }
}
