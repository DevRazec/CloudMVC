//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CloudMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ShipperID { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> SortShipper { get; set; }
        public Nullable<int> SortProduct { get; set; }
        public Nullable<double> DefaultPrice { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<double> Increase { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<double> TotalCustomer { get; set; }
        public string Observation { get; set; }
    
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }
        public virtual Shippers Shippers { get; set; }
    }
}
