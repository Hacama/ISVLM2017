using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISVLM2017.Domain.Entities
{
        [Table("TB_CONF_EJEMPLAR")]
      public partial class ConfiguracionEjemplar
    {
        [Key]
        public int conf_ejemplares_id { get; set; }
        public int conf_dia_semana { get; set; }
        public int stock_id { get; set; }
        public int conf_transaccion { get; set; }
        public int conf_ejemplar { get; set; }

        public virtual Stock TB_STOCK { get; set; }



    }
        partial class ConfiguracionEjemplar
        {
            public string stock_nombre { get; set; }
            public string codigodetalle_descrip { get; set; }
            public string nombre_ejemplar { get; set; }
            public decimal stock_precio { get; set; }
            public decimal stock_comision_canilla { get; set; }
            public decimal stock_comision_distribuidor { get; set; }
        }
}
