using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISVLM2017.Domain.Entities
{
    [Table("TB_STOCK")]
    public partial class Stock
    {
        //public Stock()
        //{
        //    //this.TB_CONF_EJEMPLAR = new HashSet<TB_CONF_EJEMPLAR>();
        //    //this.TB_STOCK_TRANSACCION_CAJA = new HashSet<TB_STOCK_TRANSACCION_CAJA>();
        //    //this.TB_STOCK_TRANSACCION = new HashSet<TB_STOCK_TRANSACCION>();
        //    //this.TB_TIPOEJEMPLAR_STOCK = new HashSet<TB_TIPOEJEMPLAR_STOCK>();
        //}
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stock_id { get; set; }
        public string stock_nombre { get; set; }
        public decimal stock_precio { get; set; }
        public decimal stock_comision_canilla { get; set; }
        public decimal stock_comision_distribuidor { get; set; }
        public int stock_tipomercaderia { get; set; }
        public System.DateTime stock_fechaventa { get; set; }
        public int proveedor_id { get; set; }
        public Nullable<int> stock_marca { get; set; }
    }
}
