namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TINHTHANH")]
    public partial class TINHTHANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TINHTHANH()
        {
            DULIEUx = new HashSet<DULIEU>();
            TUKHOATINHTHANHs = new HashSet<TUKHOATINHTHANH>();
        }

        [Key]
        public int MaTinhThanh { get; set; }

        [StringLength(64)]
        public string TenTinhThanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DULIEU> DULIEUx { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUKHOATINHTHANH> TUKHOATINHTHANHs { get; set; }
    }
}
