using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;

namespace ISVLM2017.WebUI.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //public string Menu()
        //{
        //    return "Hello from NavController";
        //}
        private ICajaDetalleRepository repository;
        public NavController(ICajaDetalleRepository repo)
        {
        repository = repo;
        }
        public PartialViewResult Menu() {
            List<NavMenu> mylist = new List<NavMenu> {
            new NavMenu { Controller = "Home"  , Action = "List",Description="Principal"  },
            new NavMenu { Controller = "Stock"  , Action = "List",Description="Stock"  },
            new NavMenu { Controller =  "ConfiguracionEjemplar" , Action = "List" ,Description="Configuración de ejemplares" },
          //  new NavMenu { Controller =  "CajaDetalle" , Action = "List",Description="Caja detalles"  },
            new NavMenu { Controller =  "Ejemplar" , Action = "List",Description="Ejemplares"  },
            new NavMenu { Controller =  "Producto" , Action = "List",Description="Productos"  },
           // new NavMenu { Controller =  "CajaDetalle" , Action = "List",Description="Clientes incidencias"  },
            new NavMenu { Controller =  "Reporte" , Action = "List",Description="Reportes"  }
            };
        //IEnumerable<string> categories = repository.CajaDetalles
        //.Select(x => x.cajadetalle_descripcion)
        //.Distinct()
        //.OrderBy(x => x);
            return PartialView(mylist);
        }

    }
}