using System.Collections.Generic;
using ISVLM2017.Domain.Entities;

namespace ISVLM2017.Domain.Abstract
{
    public interface ICajaDetalleRepository
    {
        IEnumerable<CajaDetalle> CajaDetalles { get; }
        void SaveCajaDetalles(CajaDetalle CajaDetalles);
        void UpdateDetalles(CajaDetalle cd);
        void DeleteDetalles(CajaDetalle cd);
         List<CajaDetalle> ShowListaDetalle();
    }
}
