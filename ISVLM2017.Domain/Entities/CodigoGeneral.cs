using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ISVLM2017.Domain.Entities
{
     [Table("TB_CODIGO_GENERAL")]
    public partial class CodigoGeneral
    {
        public CodigoGeneral()
        {
            this.CodigoGeneralDetalle = new HashSet<CodigoGeneralDetalle>();
        }

          [Key]
        public int codigogeneral_id { get; set; }
        public string codigogeneral_descrip { get; set; }

        public virtual ICollection<CodigoGeneralDetalle> CodigoGeneralDetalle { get; set; }
    }
}
