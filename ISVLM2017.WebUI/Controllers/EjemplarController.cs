using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using ISVLM2017.Domain.Model;

namespace ISVLM2017.WebUI.Controllers
{
    public class EjemplarController : Controller
    {
        private IConfiguracionEjemplarRepository repositoryConfiguracionEjemplar;
        private ITipoEjemplarStockRepository repositoryTipoEjemplarStock;
        private IStockTransaccionRepository repositoryStockTransaccion;
        private IStockTransaccionCajaRepository repositoryStockTransaccionCaja;
        private int int_fechamaestra;
        public EjemplarController(IConfiguracionEjemplarRepository ConfiguracionEjemplarRepository,
            ITipoEjemplarStockRepository TipoEjemplarStockRepository,
             IStockTransaccionRepository StockTransaccionRepository,
             IStockTransaccionCajaRepository StockTransaccionCajaRepository)
        {
           
            this.repositoryConfiguracionEjemplar = ConfiguracionEjemplarRepository;
            this.repositoryTipoEjemplarStock = TipoEjemplarStockRepository;
            this.repositoryStockTransaccion = StockTransaccionRepository;
            this.repositoryStockTransaccionCaja = StockTransaccionCajaRepository;
        }
        public ViewResult List()
        {
            var model = new EjemplarViewModel();
            int_fechamaestra = Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d")) + 1;
            model.i_filas = repositoryConfiguracionEjemplar.contarEjemplares(int_fechamaestra);
            model. i_colum = repositoryConfiguracionEjemplar.contarTransacciones(int_fechamaestra) + 6;
            model.listtcEjemplares = repositoryConfiguracionEjemplar.listarEjemplares(int_fechamaestra);
            model.listtcTablaEjemplares = repositoryConfiguracionEjemplar.crearTablaEjemplare(int_fechamaestra);      
            return View(model);
        }
        public JsonResult GuardarEjemplar(List<EjemplarViewModel> nuevoEjemplares, DateTime fecha_maestra)
        {
            string mensaje;
              ConfiguracionEjemplar ce, listtcTablaEjemplares = new ConfiguracionEjemplar();
              StockTransaccion st = new StockTransaccion();
              StockTransaccionCaja stc = new StockTransaccionCaja();

            foreach (EjemplarViewModel element in nuevoEjemplares)
            {

                ce = repositoryConfiguracionEjemplar.buscarEjemplarStock(Convert.ToInt32(element.codigo_venta));
                st.stocktransaccion_fecha =fecha_maestra;
                st.stocktransaccion_transaccion = ce.conf_transaccion;
                st.stocktransaccion_cantidad = Convert.ToInt32(  element.cantidad_venta);
                st.stock_id = ce.stock_id  ;
                st.stock_precio = ce.stock_precio;
                st.stock_comision_canilla = ce.stock_comision_canilla;
                st.stocktransaccion_cero = 0 ;
                st.stock_comision_distribuidor = ce.stock_comision_distribuidor;
                repositoryStockTransaccion.grabarEjemplares(st);

                ce = repositoryConfiguracionEjemplar.buscarEjemplarStock(Convert.ToInt32(element.codigo_dev));
                st.stocktransaccion_fecha = fecha_maestra.AddDays(-1);
                st.stocktransaccion_transaccion = ce.conf_transaccion;
                st.stocktransaccion_cantidad = Convert.ToInt32( element.cantidad_dev);
                st.stock_id = ce.stock_id;
                st.stock_precio = ce.stock_precio;
                st.stock_comision_canilla = ce.stock_comision_canilla;
                st.stock_comision_distribuidor = ce.stock_comision_distribuidor;
                st.stocktransaccion_cero = Convert.ToInt32( element.ceros_venta); ;
               repositoryStockTransaccion.grabarEjemplares(st);

                if (repositoryTipoEjemplarStock.existeTipoEjemplar(ce.stock_id) == true)
                {
                    ce = repositoryConfiguracionEjemplar.buscarEjemplarStock(Convert.ToInt32(element.codigo_venta));
                    stc.stocktransaccioncaja_fecha =fecha_maestra;
                    stc.stocktransaccioncaja_transaccion = ce.conf_transaccion;
                    stc.stocktransaccioncaja_cantidad = 1;
                    stc.stock_id = ce.stock_id;
                    stc.stock_precio = ce.stock_precio;
                    stc.stock_comision_canilla = ce.stock_comision_canilla;
                    stc.stocktransaccioncaja_descripcion = "Policia";
                    stc.stocktransaccioncaja_estado = 1;

                    repositoryStockTransaccionCaja.grabarTransaccion(stc);
                }
               
            }
            mensaje = "Los archivos se han guardado";
            return Json(mensaje);
        }
    }
}