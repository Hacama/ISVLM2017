using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ISVLM2017.Domain.Concrete
{
    public class EFTipoEjemplarStockRepository : ITipoEjemplarStockRepository
    {
        private EFDbContext context = new EFDbContext();
        public bool existeTipoEjemplar(int stock_id)
        {
            bool existe = (from j in context.TipoEjemplarStocks
                           where j.stock_id == stock_id
                            && j.tipoejemplares_ejemplar >= 1
                              && j.tipoejemplares_ejemplar <= 3

                           select j).FirstOrDefault() != null;


            return existe;

        }
    }
}
