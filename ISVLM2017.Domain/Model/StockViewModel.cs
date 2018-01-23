using System;
using System.Collections.Generic;
using ISVLM2017.Domain.Entities;

namespace ISVLM2017.Domain.Model
{
    public class StockViewModel
    {
        public List<CodigoGeneralDetalle> TipoMercaderia { get; set; } 
         public List<CodigoGeneralDetalle> TipoMarca { get; set; }
         public List<Proveedor> ListaProveedor { get; set; }
         public List<Stock> ListaStock { get; set; } 
        
        
    }
}
