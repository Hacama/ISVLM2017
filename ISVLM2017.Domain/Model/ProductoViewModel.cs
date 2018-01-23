using System;
using System.Collections.Generic;
using ISVLM2017.Domain.Entities;

namespace ISVLM2017.Domain.Model
{
    public class ProductoViewModel
    {
        public List<Stock> listtcProd { get; set; }
        public int codigo_prod { get; set; }
        public int cantidad_venta { get; set; }
        public int cantidad_dev { get; set; }
    }
}
