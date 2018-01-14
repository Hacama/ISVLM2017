using ISVLM2017.Domain.Entities;
using System.Data.Entity;
namespace ISVLM2017.Domain.Concrete
{
    class EFDbContext: DbContext
    {
        public DbSet<CajaDetalle> CajaDetalles { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<CodigoGeneralDetalle> CodigoGeneralDetalles { get; set; }
        public DbSet<ConfiguracionEjemplar> ConfiguracionEjemplares { get; set; }
    }
}
