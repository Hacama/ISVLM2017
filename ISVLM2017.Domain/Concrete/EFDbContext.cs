using ISVLM2017.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
namespace ISVLM2017.Domain.Concrete
{
    class EFDbContext: DbContext
    {
    //    public EFDbContext()
    //        : base("name=EFDbContext")
    //{
    //}
 
    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{
    //    throw new UnintentionalCodeFirstException();
    //}
        public DbSet<CajaDetalle> CajaDetalles { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<CodigoGeneralDetalle> CodigoGeneralDetalles { get; set; }
        public DbSet<ConfiguracionEjemplar> ConfiguracionEjemplares { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<TipoEjemplarStock> TipoEjemplarStocks { get; set; }
        public DbSet<StockTransaccion> StockTransacciones { get; set; }
        public DbSet<StockTransaccionCaja> StockTransaccionCajas { get; set; }

        //public virtual ObjectResult<ListarEjemplarVentaPorTipo> SP_LISTAR_EJEMPLAR_VENTA_PORTIPO()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListarEjemplarVentaPorTipo>("SP_LISTAR_EJEMPLAR_VENTA_PORTIPO");
        //}
    }
}
