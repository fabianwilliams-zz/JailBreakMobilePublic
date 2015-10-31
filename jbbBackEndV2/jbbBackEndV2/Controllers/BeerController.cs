using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using jbbBackEndV2.DataObjects;
using jbbBackEndV2.Models;

namespace jbbBackEndV2.Controllers
{
    public class BeerController : TableController<Beer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Beer>(context, Request, Services);
        }

        // GET tables/Beer
        public IQueryable<Beer> GetAllBeer()
        {
            return Query(); 
        }

        // GET tables/Beer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Beer> GetBeer(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Beer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Beer> PatchBeer(string id, Delta<Beer> patch)
        {
             return UpdateAsync(id, patch);
        }

        //Fabian Implementing a PUT

        public Task<Beer> PutBeer(string id, Delta<Beer> put)
        {
            return UpdateAsync(id, put);
        }

        // POST tables/Beer
        public async Task<IHttpActionResult> PostBeer(Beer item)
        {
            Beer current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Beer/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBeer(string id)
        {
             return DeleteAsync(id);
        }

    }
}