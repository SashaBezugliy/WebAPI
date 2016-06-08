using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ProductLocationDAL
    {
        public List<ProductLocation> GetProductLocations(int supermarketId)
        {
            List<ProductLocation> result;
            using (var sf = new SimplyFindEntities())
            {
                result = sf.ProductLocation.Where(pl => pl.SupermarketId == supermarketId).ToList();
            }
            return result;
        }

        public List<ProductListDTO> GetProductLists(string userId)
        {
            var result = new List<ProductListDTO>();
            using (var sf = new SimplyFindEntities())
            {
                var records = (from ep in sf.ProductListSet
                    join e in sf.ProductListToProduct on ep.ProductListId equals e.ProductListId
                    join t in sf.ProductLocation on e.ProductId equals t.ProductId
                    where ep.UserId == userId
                    select new
                    {
                        ep.ProductListId,
                        ListName = ep.Name,
                        t.ProductId,
                        t.ProductName,
                        t.Latitude,
                        t.Longitude
                    }).ToList();

                var grouped = records.GroupBy(g => g.ProductListId);

                foreach (var group in grouped)
                {
                    result.Add(new ProductListDTO
                    {
                        ListId = group.Key,
                        ListName = group.Select(g => g.ListName).First(),
                        Products = group.Select(v => new {v.ProductId, v.ProductName, v.Latitude, v.Longitude})
                            .ToList<object>()
                    });
                }
                return result;
            }
        }


        public int SaveProductList(string userId, string listName, List<long> productIds)
        {
            using (var sf = new SimplyFindEntities())
            {
                var productList = new ProductList {Name = listName, UserId = userId };

                foreach (var productId in productIds)
                {
                    sf.ProductListToProduct.Add(new ProductListToProduct
                    {
                        ProductId = (int) productId,
                        ProductList = productList
                    });
                }

                try
                {
                    sf.SaveChanges();
                    return productList.ProductListId;
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
