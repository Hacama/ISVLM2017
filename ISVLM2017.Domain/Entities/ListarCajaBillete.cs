using System;
using System.Collections.Generic;

namespace ISVLM2017.Domain.Entities
{
    public partial class ListarCajaBillete
    {
        public System.DateTime cajadetalle_fecha { get; set; }
        public Nullable<int> cantidad { get; set; }
        public string cajadetalle_descripcion { get; set; }
    }
}
