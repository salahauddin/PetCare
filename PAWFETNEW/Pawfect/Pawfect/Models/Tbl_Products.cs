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
    
    public partial class Tbl_Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Products()
        {
            this.Tbl_purchased_products = new HashSet<Tbl_purchased_products>();
        }
    
        public int ProductID { get; set; }
        public string Product_Name { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public string Manufacturer { get; set; }
        public Nullable<System.DateTime> Manufacture_Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_purchased_products> Tbl_purchased_products { get; set; }
    }
}
