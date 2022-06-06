namespace TarifCalculator.Entities
{

    public interface ITarifCollection
    {
        public List<Tarif> GetTarifs();
    }

    internal class TarifCollection : ITarifCollection
    {
        public List<Tarif> GetTarifs()
        {
            var tarifs = new List<Tarif>();
            tarifs.Add(new BasicTarif(5, 22));
            tarifs.Add(new PackagedTarif(4000, 800, 30));
            return tarifs;
        }
    }
}
