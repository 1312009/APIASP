namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TUKHOAQUANHUYEN")]
    public partial class TUKHOAQUANHUYEN
    {
        [Key]
        public int MaTuKhoaQuanHuyen { get; set; }

        [Column("TuKhoaQuanHuyen")]
        [StringLength(64)]
        public string TuKhoaQuanHuyen1 { get; set; }

        public int? MaQuanHuyen { get; set; }

        public virtual QUANHUYEN QUANHUYEN { get; set; }
    }
}
