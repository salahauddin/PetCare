//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PAWFETNEW.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Pets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Pets()
        {
            this.animals1 = new HashSet<animals1>();
            this.animals11 = new HashSet<animals1>();
            this.Tbl_Adoption = new HashSet<Tbl_Adoption>();
        }

        public int PetID { get; set; }
        [Required(ErrorMessage = "**Required")]
        [Display(Name = "Pet Category")]
        public string Pet_Category { get; set; }
        [Required(ErrorMessage = "**Required")]
        public string Age { get; set; }
        [Required(ErrorMessage = "**Required")]
        [Display(Name = "Pet Breed")]
        public string Pet_Breed { get; set; }
        [Required(ErrorMessage = "**Required")]
        [Display(Name = "Pet Gender")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "**Required")]
        public string Height { get; set; }
        [Required(ErrorMessage = "**Required")]
        [Display(Name = "Weight")]
        public string Weights { get; set; }
        [Required(ErrorMessage = "**Required")]
        public string Colour { get; set; }
        [Required(ErrorMessage = "**Required")]
        [Display(Name = "Pet Price")]
        public string Pet_Price { get; set; }
        [Required(ErrorMessage = "**Required")]
        public string img_location { get; set; }

        public string taken { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<animals1> animals1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<animals1> animals11 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Adoption> Tbl_Adoption { get; set; }
    }
}
