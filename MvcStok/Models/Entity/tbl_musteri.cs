//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_musteri()
        {
            this.tbl_satıs = new HashSet<tbl_satıs>();
        }
    
        public int MUSTERİID { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez !!!")]
        [StringLength(20,ErrorMessage ="En Fazla 20 Karakterlik İsim Girişi Yapılabilir !!!")]
        public string MUSTERİAD { get; set; }
        public string MUSTERİSOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_satıs> tbl_satıs { get; set; }
    }
}
