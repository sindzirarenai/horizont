using System.Collections.Generic;
using System.Linq;
using Horizont.Connection;
using Horizont.Models;

namespace Horizont.Services
{
    public class SaleService:ISaleService
    {
       private IBaseRepository<Sale> Sales { get; set; }
        private IBaseRepository<SaleDocument> SaleDocuments { get; set; }
        private IBaseRepository<Contrpartner> Contrpartners { get; set; }
        private IBaseRepository<Assortment> Assortments { get; set; }



        public List<Contrpartner> GetContrpartners()
        {
            return Contrpartners.GetAll();
        }

  

        public List<SaleDocument> GetSaleDocumentsByContrpartner(Contrpartner contrpartner)
        {
            return contrpartner.SaleDocuments.ToList();
        }

        public List<Assortment> GetAprioriAssortment(List<long> ids)
        {
            return new List<Assortment>();
            /*var dictionary = SaleDocuments.Linq()
                .Where(x => x.GetAssortments().Count(y => ids.Contains(y.Id)) == ids.Count)
                .ToDictionary(y => y, x => x.Sales.Select(z => z.Assortment).OrderBy(z => z.Id).ToList());
            var dictionaryFrequently = dictionary.SelectMany(x => x.Value).GroupBy(z => z)
                .ToDictionary(y => y.ToList(), z => z.Count()).OrderByDescending(t => t.Value);
            return dictionaryFrequently.Select(z=>z.Key)*/
        }
    }
}
