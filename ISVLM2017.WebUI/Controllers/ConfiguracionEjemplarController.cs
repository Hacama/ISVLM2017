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
    public class ConfiguracionEjemplarController : Controller
    {

        private ICodigoRepository repository;
        private IStockRepository repositoryStock;
        private IConfiguracionEjemplarRepository repositoryConfiguracionEjemplar;

      //  private List<Stock> lineCollection = new List<Stock>();
        const int cons_g_semana = 1, cons_g_transaccion = 2, cons_g_tipomercaderia = 3, cons_g_ejemplar = 4;
        public ConfiguracionEjemplarController(ICodigoRepository CodigoRepository,
                                                IStockRepository StockRepository,
                                                 IConfiguracionEjemplarRepository ConfiguracionEjemplarRepository)
        {
            this.repository = CodigoRepository;
            this.repositoryStock = StockRepository;
            this.repositoryConfiguracionEjemplar = ConfiguracionEjemplarRepository;
        }
        public ViewResult List()
        {
            var model = new ConfiguracionEjemplarViewModel();
            CodigoGeneralDetalle tc = new CodigoGeneralDetalle();
            tc.codigogeneral_id = cons_g_semana;
            model.Semanas = repository.buscarListaCodigoDetalle(tc);
            tc.codigogeneral_id = cons_g_transaccion;
            model.Transacciones  = repository.buscarListaCodigoDetalle(tc);
            tc.codigogeneral_id = cons_g_ejemplar;
            model.Ejemplares = repository.buscarListaCodigoDetalle(tc);
            model.Stockconf = repositoryStock.buscarListaStock();
            model.ConfEjemplares = repositoryConfiguracionEjemplar.buscarListaEjemplares( 0);
            return View(model);
        }
        [HttpPost]
        public JsonResult MostrarListaEjemplares(int conf_dia_semana_)
        {
            return Json(repositoryConfiguracionEjemplar.buscarListaEjemplares(conf_dia_semana_));
        }
        [HttpPost]
        public JsonResult AgregarStckConf(ConfiguracionEjemplar nuevoConfiguracionEjemplar)
        {
            repositoryConfiguracionEjemplar.grabarEjemplares(nuevoConfiguracionEjemplar);
            return Json(repositoryConfiguracionEjemplar.buscarListaEjemplares(nuevoConfiguracionEjemplar.conf_dia_semana));
        }

        [HttpPost]
        public JsonResult EliminarStckConf(ConfiguracionEjemplar nuevoConfiguracionEjemplar)
        {
            repositoryConfiguracionEjemplar.borrarEjemplares(nuevoConfiguracionEjemplar);
            return Json(repositoryConfiguracionEjemplar.buscarListaEjemplares(nuevoConfiguracionEjemplar.conf_dia_semana));
        }
    }
}