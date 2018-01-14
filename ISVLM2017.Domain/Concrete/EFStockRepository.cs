using System;
using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ISVLM2017.Domain.Concrete
{
    public class EFStockRepository : IStockRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Stock> Stocks 
        {
            get { return context.Stocks ; }
        }
        public List<Stock> buscarListaStock()
        {
            List<Stock> listr = new List<Stock>();
            var listtcDatos = from j in context.Stocks
                              select j;
            foreach (Stock ts_ in listtcDatos)
            {
                Stock ju = new Stock();
                ju.stock_id = ts_.stock_id;
                ju.stock_nombre = ts_.stock_nombre;
                ju.stock_precio = ts_.stock_precio;
                ju.stock_comision_canilla = ts_.stock_comision_canilla;
                ju.stock_comision_distribuidor = ts_.stock_comision_distribuidor;
                ju.stock_tipomercaderia = ts_.stock_tipomercaderia;
                ju.stock_fechaventa = ts_.stock_fechaventa;
                ju.proveedor_id = ts_.proveedor_id;
                ju.stock_marca = ts_.stock_marca;
                listr.Add(ju);
            }
            return listr;
        }
    }
}
