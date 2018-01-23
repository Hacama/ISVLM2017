using System.Collections.Generic;
using ISVLM2017.Domain.Entities;
using System;

namespace ISVLM2017.Domain.Abstract
{
    public interface IListarEjemplarVentaPorTipoRepository
    {
        List<ListarEjemplarVentaPorTipo> MostrarReporteEjemplarVentaPorTipo();
        List<ListarVentaPorMarca> MostrarReporteVentaPorMarca(Nullable<int> stock_marca, Nullable<int> stock_mes);
        List<ListarCajaBillete> MostrarReporteCajaBillete(Nullable<int> stock_marca, Nullable<int> stock_mes);
        List<ListarCajaMoneda> MostrarReporteCajaMoneda(Nullable<int> stock_marca, Nullable<int> stock_mes);
    }
}
