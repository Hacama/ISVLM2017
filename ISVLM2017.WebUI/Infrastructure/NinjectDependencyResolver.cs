using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Moq;
using Ninject;
using ISVLM2017.Domain.Concrete;
using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;

namespace ISVLM2017.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //Mock<ICajaDetalleRepository> mock = new Mock<ICajaDetalleRepository>();
            //mock.Setup(m => m.CajaDetalles).Returns(new List<TB_CAJA_DETALLE> {
            //new TB_CAJA_DETALLE { cajadetalle_fecha = DateTime.Now  , cajadetalle_billete_docientos = 25 },
            //new TB_CAJA_DETALLE { cajadetalle_fecha =  DateTime.Now, cajadetalle_billete_docientos = 179 },
            //new TB_CAJA_DETALLE { cajadetalle_fecha =  DateTime.Now, cajadetalle_billete_docientos = 95 }
            //});
            //kernel.Bind<ICajaDetalleRepository>().ToConstant(mock.Object);

            kernel.Bind<ICajaDetalleRepository>().To<EFCajaDetalleRepository>();
            kernel.Bind<IStockRepository>().To<EFStockRepository>();
            kernel.Bind<ICodigoRepository>().To<EFCodigoRepository>();
            kernel.Bind<IConfiguracionEjemplarRepository>().To<EFConfiguracionEjemplarRepository>();
        }
    }
}