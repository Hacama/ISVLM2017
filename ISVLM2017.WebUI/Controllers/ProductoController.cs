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
    public class ProductoController : Controller
    {
        private IConfiguracionEjemplarRepository repositoryConfiguracionEjemplar;
        private IStockRepository repositoryStock;
        private IStockTransaccionRepository repositoryStockTransaccion;
        private DateTime dt_fechamaestra;
        const int cons_d_venta = 1, cons_d_devolucion = 2;
        public ProductoController(IConfiguracionEjemplarRepository ConfiguracionEjemplarRepository,
                                     IStockRepository StockRepository,
                                     IStockTransaccionRepository StockTransaccionRepository)
        {
           
            this.repositoryConfiguracionEjemplar = ConfiguracionEjemplarRepository;
            this.repositoryStock= StockRepository;
             this.repositoryStockTransaccion = StockTransaccionRepository;
        }
        public ViewResult List()
        {
            var model = new ProductoViewModel();
             dt_fechamaestra = DateTime.Now;

            model.listtcProd = repositoryConfiguracionEjemplar.ListatablaProductoStock(2, Convert.ToDateTime(dt_fechamaestra.ToShortDateString()));    
            return View(model);
        }
        public JsonResult GuardarProducto(List<ProductoViewModel> nuevoProductos, DateTime fecha_maestra)
        {
            string mensaje;
            StockTransaccion st = new StockTransaccion();
          

            foreach (ProductoViewModel element in nuevoProductos)
            {
           
                Stock ts = new Stock();
                ts.stock_id = Convert.ToInt32(element.codigo_prod);

                ts = repositoryStock.buscarStock(ts);
                st.stocktransaccion_fecha = fecha_maestra;
                st.stocktransaccion_transaccion = cons_d_venta;
                st.stocktransaccion_cantidad = Convert.ToInt32(element.cantidad_venta);
                st.stock_id = ts.stock_id;
                st.stock_precio = ts.stock_precio;
                st.stock_comision_canilla = ts.stock_comision_canilla;
                st.stock_comision_distribuidor = ts.stock_comision_distribuidor;
                repositoryStockTransaccion.grabarEjemplares(st);

                ts = repositoryStock.buscarStock(ts);
                st.stocktransaccion_fecha = fecha_maestra;
                st.stocktransaccion_transaccion = cons_d_devolucion;
                st.stocktransaccion_cantidad = Convert.ToInt32(element.cantidad_dev);
                st.stock_id = ts.stock_id;
                st.stock_precio = ts.stock_precio;
                st.stock_comision_canilla = ts.stock_comision_canilla;
                st.stock_comision_distribuidor = ts.stock_comision_distribuidor;
                repositoryStockTransaccion.grabarEjemplares(st);

            }
            mensaje = "Los archivos se han guardado";
            return Json(mensaje);
        }
    }
}