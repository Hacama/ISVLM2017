using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ISVLM2017.Domain.Entities
{
     [Table("TB_CAJA_DETALLE_BILLETE")]
    public partial class CajaDetalleBillete
    {
       [Key, Column(Order = 0)]
        public int cajadetallebillete_id { get; set; }
        [Key, Column(Order = 1)]
       // [ForeignKey("FK_TB_CAJA_DETALLE_BILLETES_TB_CAJA_DETALLE")]
        public int cajadetalle_id { get; set; }
        public int cajadetallebillete_tipo { get; set; }
        public string cajadetallebillete_serie { get; set; }
        public string cajadetallebillete_descripcion { get; set; }

     //   public virtual CajaDetalle CajaDetalle { get; set; }
    }
}
