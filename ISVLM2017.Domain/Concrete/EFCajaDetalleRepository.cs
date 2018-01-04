using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
namespace ISVLM2017.Domain.Concrete
{
    public class EFCajaDetalleRepository : ICajaDetalleRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<CajaDetalle> CajaDetalles
        {
            get { return context.CajaDetalles; }
        }

        public void SaveCajaDetalles(CajaDetalle CajaDetalles)
        {
            if (CajaDetalles.cajadetalle_id == 0)
            {
                context.CajaDetalles.Add(CajaDetalles);
            }
            else
            {
                CajaDetalle dbEntry = context.CajaDetalles.Find(CajaDetalles.cajadetalle_id);
                if (dbEntry != null)
                {
                    dbEntry.cajadetalle_fecha = CajaDetalles.cajadetalle_fecha;
                    dbEntry.cajadetalle_billete_docientos = CajaDetalles.cajadetalle_billete_docientos;
                    dbEntry.cajadetalle_billete_cien = CajaDetalles.cajadetalle_billete_cien;
                    dbEntry.cajadetalle_billete_cincuenta = CajaDetalles.cajadetalle_billete_cincuenta;
                    dbEntry.cajadetalle_billete_veinte = CajaDetalles.cajadetalle_billete_veinte;
                    dbEntry.cajadetalle_billete_diez = CajaDetalles.cajadetalle_billete_diez;
                    dbEntry.cajadetalle_descripcion = CajaDetalles.cajadetalle_descripcion;
                }
            }
            context.SaveChanges();
        }
        public void UpdateDetalles(CajaDetalle cd)
        {
            var modificarDatos = (from j in context.CajaDetalles
                                  where j.cajadetalle_id == cd.cajadetalle_id
                                  select j).SingleOrDefault();
            modificarDatos.cajadetalle_fecha = cd.cajadetalle_fecha;
            modificarDatos.cajadetalle_billete_docientos = cd.cajadetalle_billete_docientos;
            modificarDatos.cajadetalle_billete_cien = cd.cajadetalle_billete_cien;
            modificarDatos.cajadetalle_billete_cincuenta = cd.cajadetalle_billete_cincuenta;
            modificarDatos.cajadetalle_billete_veinte = cd.cajadetalle_billete_veinte;
            modificarDatos.cajadetalle_billete_diez = cd.cajadetalle_billete_diez;
            modificarDatos.cajadetalle_billete_diez = cd.cajadetalle_billete_diez;
            modificarDatos.cajadetalle_descripcion = cd.cajadetalle_descripcion;
            context.SaveChanges();         

        }

        public void DeleteDetalles(CajaDetalle cd)
        {
            var borrarDatos = (from j in context.CajaDetalles
                               where j.cajadetalle_id == cd.cajadetalle_id
                               select j).Single();
            context.CajaDetalles.Remove(borrarDatos);
            context.SaveChanges();
        }

        public List<CajaDetalle> ShowListaDetalle()
        {
            List<CajaDetalle> listr = new List<CajaDetalle>();
            var listtcDatos = from j in context.CajaDetalles
                              select j;
            foreach (CajaDetalle cd in listtcDatos)
            {
                CajaDetalle ju = new CajaDetalle();
                ju.cajadetalle_id = cd.cajadetalle_id;
                ju.cajadetalle_fecha = cd.cajadetalle_fecha;
                ju.cajadetalle_billete_docientos = cd.cajadetalle_billete_docientos;
                ju.cajadetalle_billete_cien = cd.cajadetalle_billete_cien;
                ju.cajadetalle_billete_cincuenta = cd.cajadetalle_billete_cincuenta;
                ju.cajadetalle_billete_veinte = cd.cajadetalle_billete_veinte;
                ju.cajadetalle_billete_diez = cd.cajadetalle_billete_diez;
                ju.cajadetalle_descripcion = cd.cajadetalle_descripcion;
                listr.Add(ju);
            }
            return listr;
        }
    }
}
