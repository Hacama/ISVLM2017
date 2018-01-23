using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISVLM2017.Domain.Entities
{
     [Table("TB_PROVEEDOR")]
    public partial class Proveedor
    {
          [Key]
        public int proveedor_id { get; set; }
        public string proveedor_descripcion { get; set; }
        public string proveedor_ruc { get; set; }
        public string proveedor_direccion { get; set; }
    
    }
}
