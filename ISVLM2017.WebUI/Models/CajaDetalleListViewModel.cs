using System.Collections.Generic;
using ISVLM2017.Domain.Entities;

namespace ISVLM2017.WebUI.Models
{
    public class CajaDetalleListViewModel
    {
        public IEnumerable<CajaDetalle> CajaDetalles { get; set; }
      //  public PagingInfo PagingInfo { get; set; }
        public string Monto { get; set; }
    }
}