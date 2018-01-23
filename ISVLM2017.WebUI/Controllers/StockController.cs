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
    public class StockController : Controller
    {
        //// GET: Stock
        const int cons_g_tipomarca = 5, cons_g_tipomercaderia = 3;
        private IStockRepository repository;
        private IProveedorRepository ProveedorRepository;
        private ICodigoRepository CodigoRepository;
        private List<Stock> lineCollection = new List<Stock>();
        public StockController(IStockRepository StockRepository,
                                IProveedorRepository ProveedorRepository,
                              ICodigoRepository CodigoRepository)
        {
            this.repository = StockRepository;
            this.ProveedorRepository = ProveedorRepository;
            this.CodigoRepository = CodigoRepository;
        }
        public ViewResult List()
        {
            var model = new StockViewModel();
            CodigoGeneralDetalle tc = new CodigoGeneralDetalle();
            tc.codigogeneral_id = cons_g_tipomarca;
            model.TipoMarca = CodigoRepository.buscarListaCodigoDetalle(tc);
            tc.codigogeneral_id = cons_g_tipomercaderia;
            model.TipoMercaderia = CodigoRepository.buscarListaCodigoDetalle(tc);
            model.ListaProveedor = ProveedorRepository.buscarListaProveedor();
            model.ListaStock = repository.buscarListaStock();
            return View(model);
            
           // return View(repository.Stocks );
        }

        [HttpPost]
        public JsonResult GuardarStock(Stock nuevoStock, string accion)
        {
            if (accion == "Agregar")
            {
                repository.grabarStock(nuevoStock);
            }
            else if (accion == "Modificar")
            {
                repository.modificarStock(nuevoStock);
            }
            else if (accion == "Eliminar")
            {
                repository.borrarStock(nuevoStock);
            }

            lineCollection = repository.buscarListaStock();

            return Json(lineCollection);
        }

    }
}