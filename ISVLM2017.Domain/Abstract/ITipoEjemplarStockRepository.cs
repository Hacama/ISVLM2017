using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISVLM2017.Domain.Abstract
{
    public interface ITipoEjemplarStockRepository
    {
        bool existeTipoEjemplar(int stock_id);
    }
}
