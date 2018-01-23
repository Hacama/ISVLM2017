using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ISVLM2017.Domain.Entities
{
      [Table("TB_STOCK_TRANSACCION_CAJA")]
    public partial  class StockTransaccionCaja
    {
            [Key]
        public int stocktransaccioncaja_id { get; set; }
        public System.DateTime stocktransaccioncaja_fecha { get; set; }
        public int stocktransaccioncaja_transaccion { get; set; }
        public int stocktransaccioncaja_cantidad { get; set; }
        public int stock_id { get; set; }
        public decimal stock_precio { get; set; }
        public decimal stock_comision_canilla { get; set; }
        public string stocktransaccioncaja_descripcion { get; set; }
        public int stocktransaccion_transaccion { get; set; }
        public int stocktransaccioncaja_estado { get; set; }
    }
}
