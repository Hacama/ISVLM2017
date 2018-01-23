using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ISVLM2017.Domain.Concrete
{
    public  class EFConfiguracionEjemplarRepository : IConfiguracionEjemplarRepository
    {
        private EFDbContext context = new EFDbContext();
        public List<ConfiguracionEjemplar> buscarListaEjemplares(int conf_dia_semana_)
        {
            List<ConfiguracionEjemplar> listr = new List<ConfiguracionEjemplar>();
            var listtcDatos = from ce in context.ConfiguracionEjemplares
                              join s in context.Stocks on ce.stock_id equals s.stock_id
                              join cd in context.CodigoGeneralDetalles on ce.conf_transaccion equals cd.codigodetalle_id
                              join cd2 in context.CodigoGeneralDetalles on ce.conf_ejemplar equals cd2.codigodetalle_id
                              where ce.conf_dia_semana == conf_dia_semana_
                              && cd.codigogeneral_id == 2
                              && cd2.codigogeneral_id == 4
                              select new
                              {
                                  ce.conf_ejemplares_id,
                                  ce.conf_dia_semana,
                                  ce.stock_id,
                                  ce.conf_transaccion,
                                  ce.conf_ejemplar,
                                  s.stock_nombre,
                                  cd.codigodetalle_descrip,
                                  nombre_ejemplar = cd2.codigodetalle_descrip
                              };



            foreach (var ts_ in listtcDatos)
            {
                ConfiguracionEjemplar ju = new ConfiguracionEjemplar();
                ju.conf_ejemplares_id = ts_.conf_ejemplares_id;
                ju.conf_dia_semana = ts_.conf_dia_semana;
                ju.stock_id = ts_.stock_id;
                ju.conf_transaccion = ts_.conf_transaccion;
                ju.conf_ejemplar = ts_.conf_ejemplar;
                ju.stock_nombre = ts_.stock_nombre;
                ju.codigodetalle_descrip = ts_.codigodetalle_descrip;
                ju.nombre_ejemplar = ts_.nombre_ejemplar;
                listr.Add(ju);
            }
            return listr;
        }
        public int contarEjemplares(int conf_dia_semana_)
        {
            var listtcDatos = (from ce in context.ConfiguracionEjemplares
                               where ce.conf_dia_semana == conf_dia_semana_
                               group ce by ce.conf_ejemplar into newGroup
                               select newGroup).Count();
            return listtcDatos;
        }
        public int contarTransacciones(int conf_dia_semana_)
        {
            var listtcDatos = (from ce in context.ConfiguracionEjemplares
                               where ce.conf_dia_semana == conf_dia_semana_
                               group ce by ce.conf_transaccion into newGroup
                               select newGroup).Count();
            return listtcDatos;
        }

        public List<ConfiguracionEjemplar> listarEjemplares(int conf_dia_semana_)
        {
            List<ConfiguracionEjemplar> listr = new List<ConfiguracionEjemplar>();
            var listtcDatos = from ce in context.ConfiguracionEjemplares
                              where ce.conf_dia_semana == conf_dia_semana_
                              group ce by ce.conf_ejemplar into g
                              select new
                              {
                                  conf_ejemplar = g.Key,

                              };
            foreach (var ts_ in listtcDatos)
            {
                ConfiguracionEjemplar ju = new ConfiguracionEjemplar();
                ju.conf_ejemplar = ts_.conf_ejemplar;

                listr.Add(ju);
            }
            return listr;
        }
        public List<ConfiguracionEjemplar> crearTablaEjemplare(int conf_dia_semana_)
        {
            List<ConfiguracionEjemplar> listr = new List<ConfiguracionEjemplar>();
            var listtcDatos = from ce in context.ConfiguracionEjemplares
                              join s in context.Stocks on ce.stock_id equals s.stock_id
                              join cd2 in context.CodigoGeneralDetalles on ce.conf_ejemplar equals cd2.codigodetalle_id
                              where ce.conf_dia_semana == conf_dia_semana_
                              && cd2.codigogeneral_id == 4
                              select new
                              {
                                  ce.conf_ejemplares_id,
                                  ce.conf_dia_semana,
                                  ce.stock_id,
                                  ce.conf_transaccion,
                                  ce.conf_ejemplar,
                                  s.stock_nombre,
                                  nombre_ejemplar = cd2.codigodetalle_descrip,
                                  s.stock_precio,
                                  s.stock_comision_canilla,
                                  s.stock_comision_distribuidor
                              };



            foreach (var ts_ in listtcDatos)
            {
                ConfiguracionEjemplar ju = new ConfiguracionEjemplar();
                ju.conf_ejemplares_id = ts_.conf_ejemplares_id;
                ju.conf_dia_semana = ts_.conf_dia_semana;
                ju.stock_id = ts_.stock_id;
                ju.conf_transaccion = ts_.conf_transaccion;
                ju.conf_ejemplar = ts_.conf_ejemplar;
                ju.stock_nombre = ts_.stock_nombre;
                ju.nombre_ejemplar = ts_.nombre_ejemplar;
                ju.stock_precio = ts_.stock_precio;
                ju.stock_comision_canilla = ts_.stock_comision_canilla;
                ju.stock_comision_distribuidor = ts_.stock_comision_distribuidor;
                listr.Add(ju);
            }
            return listr;
        }

        public List<Stock> ListatablaProductoStock(int stock_tipomercaderia, DateTime stock_fechaventa)
        {
            List<Stock> listr = new List<Stock>();
            var listtcDatos = from j in context.Stocks
                              where j.stock_tipomercaderia == stock_tipomercaderia
                                && j.stock_fechaventa == stock_fechaventa
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

        public void grabarEjemplares(ConfiguracionEjemplar ConfiguracionEjemplares)
        {      
                context.ConfiguracionEjemplares.Add(ConfiguracionEjemplares);
                context.SaveChanges(); 
        }

        public void borrarEjemplares(ConfiguracionEjemplar ConfiguracionEjemplares)
        {
            var borrarDatos = (from j in context.ConfiguracionEjemplares
                               where j.conf_ejemplares_id == ConfiguracionEjemplares.conf_ejemplares_id
                               select j).Single();
            context.ConfiguracionEjemplares.Remove(borrarDatos);
            context.SaveChanges();
        }
        public ConfiguracionEjemplar buscarEjemplarStock(int conf_ejemplares_id_)
        {

            var ts_ = (from ce in context.ConfiguracionEjemplares
                       join s in context.Stocks on ce.stock_id equals s.stock_id
                       where ce.conf_ejemplares_id == conf_ejemplares_id_

                       select new
                       {


                           ce.conf_transaccion,
                           ce.stock_id,
                           s.stock_precio,
                           s.stock_comision_canilla,
                           s.stock_comision_distribuidor
                       }).Single();

            ConfiguracionEjemplar ju = new ConfiguracionEjemplar();




            ju.stock_id = ts_.stock_id;
            ju.conf_transaccion = ts_.conf_transaccion;
            ju.stock_precio = ts_.stock_precio;
            ju.stock_comision_canilla = ts_.stock_comision_canilla;
            ju.stock_comision_distribuidor = ts_.stock_comision_distribuidor;


            return ju;
        }

    }


}
