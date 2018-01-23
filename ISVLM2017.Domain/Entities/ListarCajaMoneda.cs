using System;
using System.Collections.Generic;


namespace ISVLM2017.Domain.Entities
{
    public partial class ListarCajaMoneda
    {
        public System.DateTime cajadetallemoneda_fecha { get; set; }
        public decimal cajadetallemoneda_monto { get; set; }
        public string cajadetallemoneda_descripcion { get; set; }
    }
}
