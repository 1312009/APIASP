namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DUONG")]
    public partial class DUONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DUONG()
        {
            DULIEUx = new HashSet<DULIEU>();
            TUKHOADUONGs = new HashSet<TUKHOADUONG>();
        }

        [Key]
        public int MaDuong { get; set; }

        [StringLength(64)]
        public string TenDuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DULIEU> DULIEUx { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TUKHOADUONG> TUKHOADUONGs { get; set; }
    }
}
