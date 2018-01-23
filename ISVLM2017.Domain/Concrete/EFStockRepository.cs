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
        public void grabarStock(Stock Stocks)
        {
              if (String.IsNullOrEmpty(Stocks.stock_id.ToString ())) {
                  Console.Write ("") ;
              }
 
            if (Stocks.stock_id != null)
            {
                context.Stocks.Add(Stocks);
                context.SaveChanges();
            }
            
        }
        public void borrarStock(Stock ts_)
        {
            var borrarDatos = (from j in context.Stocks
                               where j.stock_id == ts_.stock_id
                               select j).Single();
            context.Stocks.Remove(borrarDatos);
            context.SaveChanges();
        }
        public Stock modificarStock(Stock ts_)
        {
            var modificarDatos = (from j in context.Stocks
                                  where j.stock_id == ts_.stock_id
                                  select j).SingleOrDefault();
            modificarDatos.stock_nombre = ts_.stock_nombre;
            modificarDatos.stock_precio = ts_.stock_precio;
            modificarDatos.stock_comision_canilla = ts_.stock_comision_canilla;
            modificarDatos.stock_comision_distribuidor = ts_.stock_comision_distribuidor;
            modificarDatos.stock_tipomercaderia = ts_.stock_tipomercaderia;
            modificarDatos.stock_fechaventa = ts_.stock_fechaventa;
            modificarDatos.proveedor_id = ts_.proveedor_id;
            modificarDatos.stock_marca = ts_.stock_marca;
            context.SaveChanges();
            return modificarDatos;

        }
        public Stock buscarStock(Stock ts_)
        {
            var mostrarDatos = (from j in context.Stocks
                                where j.stock_id == ts_.stock_id
                                select j).Single();
            Stock ju = new Stock();
            ju.stock_id = mostrarDatos.stock_id;
            ju.stock_nombre = mostrarDatos.stock_nombre;
            ju.stock_precio = mostrarDatos.stock_precio;
            ju.stock_comision_canilla = mostrarDatos.stock_comision_canilla;
            ju.stock_comision_distribuidor = mostrarDatos.stock_comision_distribuidor;
            ju.stock_tipomercaderia = mostrarDatos.stock_tipomercaderia;
            ju.stock_fechaventa = mostrarDatos.stock_fechaventa;
            ju.proveedor_id = mostrarDatos.proveedor_id;
            ju.stock_marca = mostrarDatos.stock_marca;
            return ju;
        }
    }
}
