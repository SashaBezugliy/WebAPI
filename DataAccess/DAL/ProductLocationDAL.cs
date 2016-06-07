using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ProductLocationDAL
    {
        public List<ProductLocation> GetProductLocations(int supermarketId)
        {
            using (var sf = new SimplyFindEntities())
            {
                return sf.ProductLocation.Where(pl => pl.SupermarketId == supermarketId).ToList();
            }
        }

        public Dictionary<string, List<ProductLocation>> GetProductLists(string userId)
        {
            using (var sf = new SimplyFindEntities())
            {

                //var lists = sf.ProductList.Where(pl => pl.UserToList.Any(utl => utl.UserId == userId)).ToList();
                var productLists = new Dictionary<string, List<ProductLocation>>();

                //foreach (var list in lists)
                //{
                //    var productIds = new List<long>();
                //    list.ProductIds.Split(',').ToList().ForEach(i => productIds.Add(Convert.ToInt64(i)));

                //    var productLocations = sf.ProductLocation.Where(pl => productIds.Contains(pl.ProductId)).ToList();
                //    productLists[list.ListName] = productLocations;
                //}

                return productLists;
            }
        }


        public void SaveProductList(string userId, string listName, List<long> productIds)
        {
            using (var sf = new SimplyFindEntities())
            {
                //var productList = new ProductList {ListId = 1, ListName = listName, ProductIds = string.Join(",", productIds.ToArray()) };
                //sf.UserToList.Add(new UserToList {UserId = userId, ProductList = productList});
                //sf.ProductList.Add(productList);

                try
                {
                    sf.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            }
        }
    }
}
