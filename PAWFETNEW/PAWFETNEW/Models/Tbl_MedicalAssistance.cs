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

    public partial class Tbl_MedicalAssistance
    {
        public int Medical_id { get; set; }
        public Nullable<int> UserID { get; set; }
    
        [Required(ErrorMessage = "**Required")]


        public string Problem { get; set; }

        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [Required(ErrorMessage = "**Required")]
        [Display(Name = "Appointment Date")]
        public Nullable<System.DateTime> Appointment_Date { get; set; }
        [Required(ErrorMessage = "**Required")]
        [Display(Name = "Doctor Name")]
        public Nullable<int> DoctorId { get; set; }

        public virtual Tbl_Doctor Tbl_Doctor { get; set; }
        public virtual Tbl_User Tbl_User { get; set; }
    }
}
