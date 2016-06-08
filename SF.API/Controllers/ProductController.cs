using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataAccess;
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
            return
                JsonConvert.SerializeObject(_dal.GetProductLocations(id));
        }
        
        [CustomAuthorize]
        public string GetProductLists(string userId)
        {
            return JsonConvert.SerializeObject(_dal.GetProductLists(userId));
        }

        [HttpPost]
        [CustomAuthorize]
        [Route("savelist/{userId}")]
        public string SaveProductList(ProductListModel model)
        {
            return
                JsonConvert.SerializeObject(
                    new {ProductListId = _dal.SaveProductList(model.UserId, model.ListName, model.ProductIds)});
        }
    }
}