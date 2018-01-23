using System;
using System.Collections.Generic;

namespace ISVLM2017.Domain.Entities
{
      public partial class ListarEjemplarVentaPorTipo
    {
        public System.DateTime fecha { get; set; }
        public int id { get; set; }
        public string nombre { get; set; }
        public int pauta { get; set; }
        public int dev { get; set; }
        public int stocktransaccion_cero { get; set; }
        public int tipoejemplares_ejemplar { get; set; }
    }
}
