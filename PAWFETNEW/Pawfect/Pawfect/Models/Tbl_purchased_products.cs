//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pawfect.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_purchased_products
    {
        public int Purchase_ID { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Quantity { get; set; }
        public Nullable<System.DateTime> Purchase_Date { get; set; }
    
        public virtual Tbl_Products Tbl_Products { get; set; }
        public virtual Tbl_User Tbl_User { get; set; }
    }
}
