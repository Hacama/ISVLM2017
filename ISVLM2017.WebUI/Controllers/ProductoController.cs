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
        private DateTime dt_fechamaestra;
        public ProductoController(IConfiguracionEjemplarRepository ConfiguracionEjemplarRepository)
        {
           
            this.repositoryConfiguracionEjemplar = ConfiguracionEjemplarRepository;
        }
        public ViewResult List()
        {
            var model = new ProductoViewModel();
             dt_fechamaestra = DateTime.Now;

            model.listtcProd = repositoryConfiguracionEjemplar.ListatablaProductoStock(2, Convert.ToDateTime(dt_fechamaestra.ToShortDateString()));    
            return View(model);
        }
    }
}