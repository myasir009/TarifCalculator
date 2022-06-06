using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarifCalculator.Entities;

namespace TarifCalculator.Tests
{
    internal class TarifCollectionFake : ITarifCollection
    {
        public List<Tarif> GetTarifs()
        {
            var tarifs = new List<Tarif>();
            tarifs.Add(new BasicTarifFake());
            tarifs.Add(new PackagedTarifFake());
            return tarifs;
        }
    }


    internal class BasicTarifFake : Tarif
    {
        public BasicTarifFake() : base(Constants.FakeBasicTarifName)
        { 
        }

        public override float GetRates(int annualConsumption)
        {
            return 1000;
        }
    }
    internal class PackagedTarifFake : Tarif
    {
        public PackagedTarifFake() : base(Constants.FakePackagedTarifName)
        {
        }

        public override float GetRates(int annualConsumption)
        {
            if (annualConsumption < 4000)
            {
                return 800;
            }
            else
            {
                return 1200;
            }
        }
    }



}
