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
                return new Dictionary<string, List<ProductLocation>>()
                {
                    {
                        "List One",
                        new List<ProductLocation>
                        {
                            new ProductLocation
                            {
                                ProductId = 1,
                                ProductName = "P1",
                                Latitude = new decimal(49.77346700001596),
                                Longitude = new decimal(24.00780541000000)
                            },
                            new ProductLocation
                            {
                                ProductId = 2,
                                ProductName = "P2",
                                Latitude = new decimal(49.77346711001596),
                                Longitude = new decimal(24.00780544000000)
                            }
                        }
                    },
                    {
                        "List Two",
                        new List<ProductLocation>
                        {
                            new ProductLocation
                            {
                                ProductId = 3,
                                ProductName = "P3",
                                Latitude = new decimal(49.77326700001596),
                                Longitude = new decimal(24.00780541000000)
                            }
                        }
                    }
                };
            }
        }
    }
}
