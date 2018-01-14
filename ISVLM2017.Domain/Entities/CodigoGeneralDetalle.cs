using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISVLM2017.Domain.Entities
{
     [Table("TB_CODIGO_GENERAL_DETALLE")]
    public partial class CodigoGeneralDetalle
    {
          [Key, Column(Order = 0)]
        public int codigogeneral_id { get; set; }
          [Key, Column(Order = 1)]
         
        public int codigodetalle_id { get; set; }
        public string codigodetalle_descrip { get; set; }

        public virtual CodigoGeneral CodigoGeneral { get; set; }
    }
}
