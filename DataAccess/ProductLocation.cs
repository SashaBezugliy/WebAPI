//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductLocation
    {
        public ProductLocation()
        {
            this.ProductListToProduct = new HashSet<ProductListToProduct>();
        }
    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int SupermarketId { get; set; }
    
        public virtual ICollection<ProductListToProduct> ProductListToProduct { get; set; }
    }
}
