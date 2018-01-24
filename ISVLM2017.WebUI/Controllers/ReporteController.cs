using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using ISVLM2017.Domain.Model;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.ComponentModel;

namespace ISVLM2017.WebUI.Controllers
{
    public class ReporteController : Controller
    {
 
        private ICodigoRepository repository;
        private IListarEjemplarVentaPorTipoRepository repositoryListarEjemplarVentaPorTipo;   

      //  private List<Stock> lineCollection = new List<Stock>();
        const int cons_g_tipomarca = 5;
        public ReporteController(ICodigoRepository CodigoRepository,
            IListarEjemplarVentaPorTipoRepository ListarEjemplarVentaPorTipoRepository)
        {
            this.repository = CodigoRepository;
            this.repositoryListarEjemplarVentaPorTipo = ListarEjemplarVentaPorTipoRepository;      
        }
        public ViewResult List()
        {
            var model = new ReporteViewModel();
            CodigoGeneralDetalle tc = new CodigoGeneralDetalle();
            tc.codigogeneral_id = cons_g_tipomarca;
            model.Marcas = repository.buscarListaCodigoDetalle(tc);
          
            return View(model);
        }
        public ActionResult ExportEjemplarVentaPorTipo()
        {
       
            List<ListarEjemplarVentaPorTipo> allEjemplarVentaPorTipo = new List<ListarEjemplarVentaPorTipo>();
            allEjemplarVentaPorTipo = repositoryListarEjemplarVentaPorTipo.MostrarReporteEjemplarVentaPorTipo();


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CR_ReporteEjemplarVentaPorTipo.rpt"));

            rd.SetDataSource(allEjemplarVentaPorTipo);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "EjemplarVentaPorTipo.pdf");
        }
        public ActionResult ExportVentaPorMarca(Nullable<int> i_marca, Nullable<int> i_mes)
        {

            List<ListarVentaPorMarca> allVentaPorMarca = new List<ListarVentaPorMarca>();
            allVentaPorMarca = repositoryListarEjemplarVentaPorTipo.MostrarReporteVentaPorMarca(i_marca, i_mes);

            List<ListarCajaBillete> allCajaBillete = new List<ListarCajaBillete>();
            allCajaBillete = repositoryListarEjemplarVentaPorTipo.MostrarReporteCajaBillete(i_marca, i_mes);

            List<ListarCajaMoneda> allCajaMoneda = new List<ListarCajaMoneda>();
            allCajaMoneda = repositoryListarEjemplarVentaPorTipo.MostrarReporteCajaMoneda(i_marca, i_mes);


            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "CR_ReporteVentaPorMarca.rpt"));

            DataSet ds = new DataSet();
            DataTable dt, dB, dM = new DataTable();

            dt = ConvertToDataTable(allVentaPorMarca, "SP_LISTAR_VENTA_PORMARCA");
            ds.Tables.Add(dt);
            //dB = ConvertToDataTable(allCajaBillete, "SP_LISTAR_CAJA_BILLETE");
            //ds.Tables.Add(dB);
            //dM = ConvertToDataTable(allCajaMoneda, "SP_LISTAR_CAJA_MONEDA");
            //ds.Tables.Add(dM);

            rd.SetDataSource(ds);         

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "VentaPorMarca.pdf");
        }

        public DataTable ConvertToDataTable<T>(IList<T> data, string name)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable(name);
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
    
}