using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccess.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using SF.API.Models;

namespace SF.API.Controllers
{
    public class ProductController : ApiController
    {
        private ProductLocationDAL _dal = new ProductLocationDAL();

        // GET api/product/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(_dal.GetProductLocations(id));
        }
        
        [CustomAuthorize]
        public string GetProductLists(string userId)
        {
            return
                JsonConvert.SerializeObject(
                    _dal.GetProductLists(userId).Select(i => new {ListName = i.Key, Products = i.Value}));
        }

        [HttpPost]
        [CustomAuthorize]
        [Route("savelist/{userId}")]
        public void SaveProductList(ProductListModel model)
        {
            _dal.SaveProductList(model.UserId, model.ListName, model.ProductIds);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}