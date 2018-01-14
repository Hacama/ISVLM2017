using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ISVLM2017.Domain.Concrete
{
    public class EFCodigoRepository : ICodigoRepository
    {
        private EFDbContext context = new EFDbContext();
        public List<CodigoGeneralDetalle> buscarListaCodigoDetalle(CodigoGeneralDetalle tsb_)
        {
            List<CodigoGeneralDetalle> listr = new List<CodigoGeneralDetalle>();
            var listtcDatos = from j in context.CodigoGeneralDetalles
                              where j.codigogeneral_id == tsb_.codigogeneral_id
                              select j;
            foreach (CodigoGeneralDetalle ts_ in listtcDatos)
            {
                CodigoGeneralDetalle ju = new CodigoGeneralDetalle();
                ju.codigogeneral_id = ts_.codigogeneral_id;
                ju.codigodetalle_id = ts_.codigodetalle_id;
                ju.codigodetalle_descrip = ts_.codigodetalle_descrip;

                listr.Add(ju);
            }
            return listr;
        }
    }
}
