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
    
    public partial class ProductListToProduct
    {
        public int ProductListToProductId { get; set; }
        public int ProductListId { get; set; }
        public int ProductId { get; set; }
    
        public virtual ProductList ProductList { get; set; }
        public virtual ProductLocation ProductLocation { get; set; }
    }
}