using System.Collections.Generic;
using ISVLM2017.Domain.Entities;
using System;


namespace ISVLM2017.Domain.Abstract
{
    public interface IConfiguracionEjemplarRepository
    {
        List<ConfiguracionEjemplar> buscarListaEjemplares(int conf_dia_semana_);
        int contarEjemplares(int conf_dia_semana_);
        int contarTransacciones(int conf_dia_semana_);
        List<ConfiguracionEjemplar> listarEjemplares(int conf_dia_semana_);
        List<ConfiguracionEjemplar> crearTablaEjemplare(int conf_dia_semana_);
        List<Stock> ListatablaProductoStock(int stock_tipomercaderia, DateTime stock_fechaventa);
    }
   
}
