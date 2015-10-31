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
    public class StaffController : TableController<Staff>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Staff>(context, Request, Services);
        }

        // GET tables/Staff
        public IQueryable<Staff> GetAllStaff()
        {
            return Query(); 
        }

        // GET tables/Staff/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Staff> GetStaff(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Staff/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Staff> PatchStaff(string id, Delta<Staff> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Staff
        public async Task<IHttpActionResult> PostStaff(Staff item)
        {
            Staff current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Staff/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteStaff(string id)
        {
             return DeleteAsync(id);
        }

    }
}