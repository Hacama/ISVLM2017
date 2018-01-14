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
    }
}
