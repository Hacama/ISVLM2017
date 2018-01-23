using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISVLM2017.Domain.Entities
{
      [Table("TB_STOCK_TRANSACCION")]
     public partial class StockTransaccion
    {
           [Key]
        public int stocktransaccion_id { get; set; }
        public System.DateTime stocktransaccion_fecha { get; set; }
        public int stocktransaccion_transaccion { get; set; }
        public int stocktransaccion_cantidad { get; set; }
        public int stock_id { get; set; }
        public decimal stock_precio { get; set; }
        public decimal stock_comision_canilla { get; set; }
        public decimal stock_comision_distribuidor { get; set; }
        public int stocktransaccion_cero { get; set; }
    }
}
