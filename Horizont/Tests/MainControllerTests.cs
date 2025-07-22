using System.Collections.Generic;
using Horizont.Connection;
using Horizont.Controllers;
using Horizont.Models;
using Horizont.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Horizont.Tests
{
    public class MainControllerTests
    {
        [Fact]
        public void GetDataMessage()
        {
            var mockDocs = new Mock<IBaseRepository<Contrpartner>>();
            var mockAssortments = new Mock<IBaseRepository<Assortment>>();
            var mockService = new Mock<ISaleService>();
            var document = new Contrpartner{Id =1};
            
            mockDocs.Setup(x => x.GetAll()).Returns(new List<Contrpartner> { document });
            var assortment = new Assortment { Id = 1 };
            mockAssortments.Setup(x => x.GetAll()).Returns(new List<Assortment> { assortment });

            using (ApplicationContext context = new ApplicationContext())
            {
                // Arrange
              //  HomeController controller = new HomeController(context);

                // Act
                //JsonResult result = controller.GetContrpartners() as JsonResult;
                // Assert
               // Assert.Equal(new List<Contrpartner> { document }, result?.Value);
            }

            
        }



    }
}
