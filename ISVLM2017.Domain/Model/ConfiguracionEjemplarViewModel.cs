using System;
using System.Collections.Generic;
using ISVLM2017.Domain.Entities;

namespace ISVLM2017.Domain.Model
{
    public class ConfiguracionEjemplarViewModel
    {
       
         public List<CodigoGeneralDetalle> Semanas { get; set; }
         public List<CodigoGeneralDetalle> Transacciones { get; set; }
         public List<CodigoGeneralDetalle> Ejemplares { get; set; }
         public List<Stock> Stockconf { get; set; }
         public List<ConfiguracionEjemplar> ConfEjemplares { get; set; }      
         public int selectedItem { get; set; }
    }
}
