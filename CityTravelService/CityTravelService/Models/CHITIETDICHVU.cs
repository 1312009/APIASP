namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CHITIETDICHVU")]
    public partial class CHITIETDICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHITIETDICHVU()
        {
            DULIEUx = new HashSet<DULIEU>();
        }

        [Key]
        public int MaChiTiet { get; set; }

        [StringLength(255)]
        public string Ten { get; set; }

        public int? GiaTien { get; set; }

        [Column(TypeName = "ntext")]
        public string ChuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DULIEU> DULIEUx { get; set; }
    }
}
