using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
namespace ISVLM2017.WebUI.Controllers
{
    public class StockController : Controller
    {
        //// GET: Stock

        private IStockRepository repository;
        private List<Stock> lineCollection = new List<Stock>();
        public StockController(IStockRepository CajaDetalleRepository)
        {
            this.repository = CajaDetalleRepository;
        }
        public ViewResult List()
        {
            
            return View(repository.Stocks );
        }

        [HttpPost]
        public JsonResult GuardarCajaDetalle(Stock nuevoStock, string accion)
        {
            //if (accion == "Agregar")
            //{
            //    repository.SaveCajaDetalles(nuevoBilletes);
            //}
            //else if (accion == "Modificar")
            //{
            //    repository.UpdateDetalles(nuevoBilletes);
            //}
            //else if (accion == "Eliminar")
            //{
            //    repository.DeleteDetalles(nuevoBilletes);
            //}

            //lineCollection = repository.ShowListaDetalle();

            return Json(lineCollection);
        }

    }
}