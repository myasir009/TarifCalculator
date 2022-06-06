using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifCalculator.Entities;

namespace TarifCalculator.Tests
{
    public class BasicTarifTest
    {
        private BasicTarif basicTarif;
        private PackagedTarif packagedTarif;

        [Theory]
        [InlineData(5, 22, 830, 3500)]
        [InlineData(5, 22, 1050, 4500)]
        [InlineData(5, 22, 1380, 6000)]
        public void GetRate_Basic_Test(float monthlyRate, float perUnitRate, float finalRate, int consumption)
        {
            //Arrange
            basicTarif = new BasicTarif(monthlyRate, perUnitRate);

            //Act
            var rate = basicTarif.GetRates(consumption);

            //Assert
            Assert.Equal(finalRate, rate);

        }

        [Theory]
        [InlineData(4000, 800, 30, 800, 3500)]
        [InlineData(4000, 800, 30, 950, 4500)]
        [InlineData(4000, 800, 30, 1400, 6000)]
        public void GetRate_Packaged_Test(int packageUpperRate, float fixYearlyRate, float perUnitRate, float finalRate, int consumption)
        {
            //Arrange
            packagedTarif = new PackagedTarif(packageUpperRate, fixYearlyRate, perUnitRate);

            //Act
            var rate = packagedTarif.GetRates(consumption);

            //Assert
            Assert.Equal(finalRate, rate);

        }


    }
}
