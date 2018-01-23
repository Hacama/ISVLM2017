using System.Collections.Generic;
using ISVLM2017.Domain.Entities;


namespace ISVLM2017.Domain.Abstract
{
    public interface IStockRepository
    {
        IEnumerable<Stock> Stocks { get; }
        List<Stock> buscarListaStock();
        void grabarStock(Stock Stocks);
        void borrarStock(Stock ts_);
         Stock modificarStock(Stock ts_);
         Stock buscarStock(Stock ts_);
    }
}
