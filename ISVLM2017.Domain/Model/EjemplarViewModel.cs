using System;
using System.Collections.Generic;
using ISVLM2017.Domain.Entities;
namespace ISVLM2017.Domain.Model
{
    public  class EjemplarViewModel
    {
        public int i_filas { get; set; }
        public int i_colum { get; set; }
        public List<ConfiguracionEjemplar> listtcEjemplares { get; set; }
        public List<ConfiguracionEjemplar> listtcTablaEjemplares { get; set; }
        public int codigo_venta { get; set; }
        public int codigo_dev { get; set; }
        public int cantidad_venta { get; set; }
        public int cantidad_dev { get; set; }
        public int ceros_venta { get; set; }
    }
}
