using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ISVLM2017.Domain.Concrete
{
    public class EFProveedorRepository : IProveedorRepository
    {
        private EFDbContext context = new EFDbContext();
        public List<Proveedor> buscarListaProveedor()
        {
            List<Proveedor> listr = new List<Proveedor>();
            var listtcDatos = from j in context.Proveedores
                              select j;
            foreach (Proveedor ts_ in listtcDatos)
            {
                Proveedor ju = new Proveedor();
                ju.proveedor_id = ts_.proveedor_id;
                ju.proveedor_descripcion = ts_.proveedor_descripcion;
                ju.proveedor_ruc = ts_.proveedor_ruc;
                ju.proveedor_direccion = ts_.proveedor_direccion;
                listr.Add(ju);
            }
            return listr;

        }      
    }
}
