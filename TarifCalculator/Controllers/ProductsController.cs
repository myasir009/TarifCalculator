using Microsoft.AspNetCore.Mvc;
using TarifCalculator.Entities;
using Microsoft.AspNetCore.Cors;

namespace TarifCalculator.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductsController :ControllerBase
    {

        private readonly ITarifCollection tarifCollection;

        public ProductsController(ITarifCollection tarifCollection)
        {
            this.tarifCollection = tarifCollection;
        }

        [HttpGet("{id}")]
        public ActionResult<List<TarifResultDto>> GetProducts(int consumption)
        {

            var tarifs = tarifCollection.GetTarifs();

            if (tarifs != null && tarifs.Count > 1)
            {
                var tarifList = new List<TarifResultDto>();
                foreach (var tarif in tarifs)
                {
                    tarifList.Add(new TarifResultDto(tarif.Name, tarif.GetRates(consumption)));
                }
                return Ok(tarifList.OrderBy(x => x.AnnualCost));
            }
            else
            {
                return NotFound();
            }

        }

    }
}
