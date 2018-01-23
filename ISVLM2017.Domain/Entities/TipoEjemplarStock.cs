using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ISVLM2017.Domain.Entities
{
    [Table("TB_TIPOEJEMPLAR_STOCK")]
     public partial class TipoEjemplarStock
    {
        [Key]
        public int tipoejemplares_stock_id { get; set; }
        public int tipoejemplares_ejemplar { get; set; }
        public int stock_id { get; set; }
    
    }
}
