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
    
    public partial class Tbl_Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Doctor()
        {
            this.Tbl_MedicalAssistance = new HashSet<Tbl_MedicalAssistance>();
        }
    
        public int DoctorID { get; set; }
        public string Doctor_Name { get; set; }
        public string Phone_No { get; set; }
        public string Email { get; set; }
        public string DoctorAddress { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string Qualification { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MedicalAssistance> Tbl_MedicalAssistance { get; set; }
    }
}