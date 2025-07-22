using System.Collections.Generic;
using Horizont.Models;
using Microsoft.AspNetCore.Mvc;
using Horizont.Connection;
using Horizont.Services;

namespace Horizont.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private ISaleService SaleService { get; set; }

        private IBaseRepository<Contrpartner> Contrpartners { get; set; }
        private IBaseRepository<Assortment> Assortments { get; set; }


        public MainController(ISaleService saleService, IBaseRepository<Contrpartner> contrpartners, IBaseRepository<Assortment> assortments)
        {
            SaleService = saleService;
            Contrpartners = contrpartners;
            Assortments = assortments;
        }

        [HttpGet]
        public JsonResult GetContrpartners()
        {
            return new JsonResult(Contrpartners.GetAll());
        }

        [HttpGet]
        public JsonResult GetAssortments()
        {
            return new JsonResult(Assortments.GetAll());
        }

        [HttpGet]
        public JsonResult GetAssortmentApriori(List<long> ids)
        {
            return new JsonResult(SaleService.GetAprioriAssortment(ids));
        }

        [HttpPost]
        public JsonResult Post()
        {
            //
            return new JsonResult("Work was successfully done");
        }

     /*   [HttpPut]
        public JsonResult Put(Sale sale)
        {
            bool success = true;
            var document = Sales.Get(sale.Id);
            try
            {
                if (document != null)
                {
                    document = Sales.Update(sale);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update successful {document.Id}") : new JsonResult("Update was not successful");
        }*/

     /*   [HttpDelete]
        public JsonResult Delete(long id)
        {
            bool success = true;
            var document = Sales.Get(id);

            try
            {
                if (document != null)
                {
                    Sales.Delete(document.Id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }*/
    }
}
