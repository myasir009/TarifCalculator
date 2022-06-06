namespace TarifCalculator.Entities
{
    internal class PackagedTarif : Tarif
    {
        private int packageUpperThreshold;
        private float fixYearlyRate;
        private float perUnitRate;

        public PackagedTarif(int packageUpperThreshold, float fixYearlyRate, float perUnitRate) : base("Packaged tarif")
        {
            this.packageUpperThreshold = packageUpperThreshold;
            this.fixYearlyRate = fixYearlyRate;
            this.perUnitRate = perUnitRate;
        }

        public override float GetRates(int annualConsumption)
        {
            if (annualConsumption <= packageUpperThreshold)
            {
                return fixYearlyRate;
            }
            else
            {
                return fixYearlyRate + (((annualConsumption - packageUpperThreshold) * perUnitRate) / 100);
            }
        }
    }
}
