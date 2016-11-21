namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TUKHOAPHUONG")]
    public partial class TUKHOAPHUONG
    {
        [Key]
        public int MaTuKhoaPhuong { get; set; }

        [Column("TuKhoaPhuong")]
        [StringLength(64)]
        public string TuKhoaPhuong1 { get; set; }

        public int? MaPhuong { get; set; }

        public virtual PHUONG PHUONG { get; set; }
    }
}
