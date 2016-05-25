using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SF.API.Models
{
    public class ProductListModel
    {
        public string UserId { get; set; }
        public string ListName { get; set; }
        public List<long> ProductIds { get; set; }

    }
}