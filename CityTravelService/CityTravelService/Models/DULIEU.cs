namespace CityTravelService.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("DULIEU")]
    public partial class DULIEU
    {
        

        [Key]
        public int MaDuLieu { get; set; }

        public int? MaDichVu { get; set; }

        public int? MaTenDiaDiem { get; set; }

        [StringLength(8)]
        public string SoNha { get; set; }

        public int? MaDuong { get; set; }

        public int? MaPhuong { get; set; }

        public int? MaQuanHuyen { get; set; }

        public int? MaTinhThanh { get; set; }

        public double? KinhDo { get; set; }

        public double? ViDo { get; set; }

        [Column(TypeName = "ntext")]
        public string ChuThich { get; set; }

        public int? DanhGia { get; set; }

        [StringLength(20)]
        public string MaBinhLuan { get; set; }

       
    }
}
