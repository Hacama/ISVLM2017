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
    public class ReporteController : Controller
    {
 
        private ICodigoRepository repository;     

      //  private List<Stock> lineCollection = new List<Stock>();
        const int cons_g_tipomarca = 5;
        public ReporteController(ICodigoRepository CodigoRepository)
        {
            this.repository = CodigoRepository;           
        }
        public ViewResult List()
        {
            var model = new ReporteViewModel();
            CodigoGeneralDetalle tc = new CodigoGeneralDetalle();
            tc.codigogeneral_id = cons_g_tipomarca;
            model.Marcas = repository.buscarListaCodigoDetalle(tc);
          
            return View(model);
        }
    }
    
}