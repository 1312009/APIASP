namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("QUANHUYEN")]
    public partial class QUANHUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUANHUYEN()
        {
            DULIEUx = new HashSet<DULIEU>();
            TUKHOAQUANHUYENs = new HashSet<TUKHOAQUANHUYEN>();
        }

        [Key]
        public int MaQuanHuyen { get; set; }

        [StringLength(64)]
        public string TenQuanHuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DULIEU> DULIEUx { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUKHOAQUANHUYEN> TUKHOAQUANHUYENs { get; set; }
    }
}
