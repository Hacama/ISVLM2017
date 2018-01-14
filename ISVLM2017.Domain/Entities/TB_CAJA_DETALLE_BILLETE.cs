using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISVLM2017.Domain.Entities
{
    public partial class TB_CAJA_DETALLE_BILLETE
    {
        public int cajadetallebillete_id { get; set; }
        public int cajadetalle_id { get; set; }
        public int cajadetallebillete_tipo { get; set; }
        public string cajadetallebillete_serie { get; set; }
        public string cajadetallebillete_descripcion { get; set; }

        public virtual TB_CAJA_DETALLE TB_CAJA_DETALLE { get; set; }
    }
}
