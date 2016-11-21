namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TUKHOATINHTHANH")]
    public partial class TUKHOATINHTHANH
    {
        [Key]
        public int MaTuKhoaTinhThanh { get; set; }

        [Column("TuKhoaTinhThanh")]
        [StringLength(64)]
        public string TuKhoaTinhThanh1 { get; set; }

        public int? MaTinhThanh { get; set; }

        public virtual TINHTHANH TINHTHANH { get; set; }
    }
}
