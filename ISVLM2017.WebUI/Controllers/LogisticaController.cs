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
    public class LogisticaController : Controller
    {
        // GET: Logistica
        public ViewResult List()
        {
            var model = new LogisticaViewModel();

            return View(model);
        }
    }
}