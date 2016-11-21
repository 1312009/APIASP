namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TUKHOADIADIEM")]
    public partial class TUKHOADIADIEM
    {
        [Key]
        public int MaTuKhoaTenDiaDiem { get; set; }

        [StringLength(128)]
        public string TuKhoaTenDiaDiem { get; set; }

        public int? MaTenDiaDiem { get; set; }

        public virtual TENDIADIEM TENDIADIEM { get; set; }
    }
}
