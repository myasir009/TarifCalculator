using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifCalculator.Controllers;

namespace TarifCalculator.Tests
{
    public class ProductsControllerTest
    {
        private readonly TarifCollectionFake tarifCollection;

        public ProductsControllerTest()
        {
            tarifCollection = new TarifCollectionFake();
        }

        [Fact]
        public void GetProductsTest_LowerBasicRate()
        {
            //Arrange
            var productController = new ProductsController(tarifCollection);

            //Act
            var tarifs = productController.GetProducts(4500);
            var okResult = tarifs.Result as OkObjectResult;
            var tarifResultsDto = okResult.Value as IOrderedEnumerable<TarifResultDto>;

            //Assert
            Assert.NotNull(tarifResultsDto);
            Assert.True(tarifResultsDto.Count() > 0);
            Assert.Equal(tarifResultsDto.FirstOrDefault().TarifName, Constants.FakeBasicTarifName);
        }
        [Fact]
        public void GetProductsTest_LowerPackagedRate()
        {
            //Arrange
            var productController = new ProductsController(tarifCollection);

            //Act
            var tarifs = productController.GetProducts(3500);
            var okResult = tarifs.Result as OkObjectResult;
            var tarifResultsDto = okResult.Value as IOrderedEnumerable<TarifResultDto>;

            //Assert
            Assert.NotNull(tarifResultsDto);
            Assert.True(tarifResultsDto.Count() > 0);
            Assert.Equal(tarifResultsDto.FirstOrDefault().TarifName, Constants.FakePackagedTarifName);
        }
    }
}
