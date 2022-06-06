namespace TarifCalculator.Entities
{
    internal class BasicTarif : Tarif
    {

        private float monthlyRate;
        private float perUnitRate;

        public BasicTarif(float monthlyRate, float perUnitRate) : base("Basic electricity tarif")
        {

            this.monthlyRate = monthlyRate;
            this.perUnitRate = perUnitRate;
        }

        public override float GetRates(int annualConsumption)
        {
            return (monthlyRate * 12) + ((annualConsumption * perUnitRate) / 100);
        }
    }
}
