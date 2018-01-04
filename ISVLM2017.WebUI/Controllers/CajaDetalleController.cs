using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;

namespace ISVLM2017.WebUI.Controllers
{
    public class CajaDetalleController : Controller
    {
        // GET: CajaDetalle
        private ICajaDetalleRepository repository;
        private List<CajaDetalle> lineCollection = new List<CajaDetalle>();
        public CajaDetalleController(ICajaDetalleRepository CajaDetalleRepository)
        {
            this.repository = CajaDetalleRepository;
        }
        public ViewResult List()
        {
            
            return View(repository.CajaDetalles );
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost]
        public JsonResult GuardarCajaDetalle(CajaDetalle nuevoBilletes, string accion)
        {
            if (accion == "Agregar")
            {
                repository.SaveCajaDetalles(nuevoBilletes);
            }
            else if (accion == "Modificar")
            {
                repository.UpdateDetalles(nuevoBilletes);
            }
            else if (accion == "Eliminar")
            {
                repository.DeleteDetalles(nuevoBilletes);
            }

            lineCollection=repository.ShowListaDetalle();

            return Json(lineCollection);
        }
    }
}