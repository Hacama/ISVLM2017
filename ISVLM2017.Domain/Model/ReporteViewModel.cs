using System;
using System.Collections.Generic;
using ISVLM2017.Domain.Entities;

namespace ISVLM2017.Domain.Model
{
    public class ReporteViewModel
    {
        public int selectedItem { get; set; }
        public List<CodigoGeneralDetalle> Marcas { get; set; }
    }
}
