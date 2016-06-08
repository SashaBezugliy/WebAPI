using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ProductListDTO
    {
        public string ListName { get; set; }
        public int ListId { get; set; }
        public List<object> Products { get; set; }
    }
}
