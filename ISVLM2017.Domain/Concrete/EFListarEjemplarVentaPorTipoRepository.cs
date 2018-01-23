using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ISVLM2017.Domain.Concrete
{
    public class EFListarEjemplarVentaPorTipoRepository : IListarEjemplarVentaPorTipoRepository
    {
        private EFDbContext context = new EFDbContext();

        public List<ListarEjemplarVentaPorTipo> MostrarReporteEjemplarVentaPorTipo()
        {
            var listtcDatos = context.Database.SqlQuery<ListarEjemplarVentaPorTipo>("SP_LISTAR_EJEMPLAR_VENTA_PORTIPO").ToList();       
            return listtcDatos;
        }
        public List<ListarVentaPorMarca> MostrarReporteVentaPorMarca(Nullable<int> stock_marca, Nullable<int> stock_mes)
        {
            var listtcDatos = context.Database.SqlQuery<ListarVentaPorMarca>("SP_LISTAR_VENTA_PORMARCA @stock_marca, @stock_mes",
                  new SqlParameter("stock_marca", stock_marca),
                  new SqlParameter("stock_mes", stock_mes)).ToList();
            return listtcDatos;
        }
        public List<ListarCajaBillete> MostrarReporteCajaBillete(Nullable<int> stock_marca, Nullable<int> stock_mes)
        {       
            var listtcBDatos = context.Database.SqlQuery<ListarCajaBillete>("SP_LISTAR_CAJA_BILLETE @stock_marca, @stock_mes",
                  new SqlParameter("stock_marca", stock_marca),
                  new SqlParameter("stock_mes", stock_mes)).ToList();


            return listtcBDatos;
        }
        public List<ListarCajaMoneda> MostrarReporteCajaMoneda(Nullable<int> stock_marca, Nullable<int> stock_mes)
        {           

            var listtcDatos = context.Database.SqlQuery<ListarCajaMoneda>("SP_LISTAR_CAJA_MONEDA @stock_marca, @stock_mes",
                  new SqlParameter("stock_marca", stock_marca),
                  new SqlParameter("stock_mes", stock_mes)).ToList();
            return listtcDatos;
        }
    }
}
