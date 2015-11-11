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
    }
}
