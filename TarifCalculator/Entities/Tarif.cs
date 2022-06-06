namespace TarifCalculator.Entities
{
    public abstract class Tarif
    {
        public string Name { get; }
        public Tarif(string name)
        {
            this.Name = name;
        }
        public abstract float GetRates(int annualConsumption);
    }
}
