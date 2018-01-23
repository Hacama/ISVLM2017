using System;
using System.Collections.Generic;

namespace ISVLM2017.Domain.Entities
{
    public partial class ListarVentaPorMarca
    {
        public System.DateTime fecha { get; set; }
        public int id { get; set; }
        public string nombre { get; set; }
        public int pauta { get; set; }
        public int dev { get; set; }
        public decimal precio { get; set; }
        public decimal comision_canillla { get; set; }
        public decimal comision_distribuidor { get; set; }
        public int stock_tipomercaderia { get; set; }
        public string proveedor_descripcion { get; set; }
    }
}
