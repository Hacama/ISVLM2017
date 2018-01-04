using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ISVLM2017.Domain.Abstract;
using ISVLM2017.Domain.Entities;
using ISVLM2017.WebUI.Controllers;
using System.Web;
using System.Web.Mvc;

namespace ISVLM2017.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange


            Mock<ICajaDetalleRepository> mock = new Mock<ICajaDetalleRepository>();
            mock.Setup(m => m.CajaDetalles).Returns(new CajaDetalle[] {
            new CajaDetalle {cajadetalle_id = 1, cajadetalle_descripcion = "P1"},
            new CajaDetalle {cajadetalle_id = 2, cajadetalle_descripcion = "P2"},
            new CajaDetalle {cajadetalle_id = 3, cajadetalle_descripcion = "P3"},
            new CajaDetalle {cajadetalle_id = 4, cajadetalle_descripcion = "P4"},
            new CajaDetalle {cajadetalle_id = 5, cajadetalle_descripcion = "P5"}
            });
            CajaDetalleController controller = new CajaDetalleController(mock.Object);
           
            //controller. = 3;
            //// Act
            JsonResult result = controller.GuardarCajaDetalle(1) as JsonResult;
            //Assert
           // List<CajaDetalle> result_ = result.Data as List<CajaDetalle>;
            CajaDetalle result_ = result.Data as CajaDetalle;
            //Assert.AreEqual("test", result.Data);
            Assert.AreEqual(result_, result.Data);
            Assert.IsNotNull(result_.cajadetalle_id,
                    "JSON record does not contain \"cajadetalle_id\" required property.");
            
      
        }
    }
}
