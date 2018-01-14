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
        private int int_fechamaestra;
        public EjemplarController(IConfiguracionEjemplarRepository ConfiguracionEjemplarRepository)
        {
           
            this.repositoryConfiguracionEjemplar = ConfiguracionEjemplarRepository;
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
    }
}