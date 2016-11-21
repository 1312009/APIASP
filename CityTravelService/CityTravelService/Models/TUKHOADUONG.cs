namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("TUKHOADUONG")]
    public partial class TUKHOADUONG
    {
        [Key]
        public int MaTuKhoaDuong { get; set; }

        [Column("TuKhoaDuong")]
        [StringLength(64)]
        public string TuKhoaDuong1 { get; set; }

        public int? MaDuong { get; set; }

        public virtual DUONG DUONG { get; set; }
    }
}
