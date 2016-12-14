namespace CityTravelService.Models
{
    public class DiaDiem
    {
        public int MaDuLieu { get; set; }

        public TenDiaDiem ten;
        public DichVu dichvu;
        public string SoNha { get; set; }

        public Duong duong;
        public Phuong phuong;
        public QuanHuyen quanhuyen;
        public TinhThanh tinhthanh;

        public double KinhDo { get; set; }

        public double ViDo { get; set; }

        public string ChuThich { get; set; }

        public float DanhGia { get; set; }

        public DiaDiem()
        {

            ten = new TenDiaDiem();
            dichvu = new DichVu();
            duong = new Duong();
            phuong = new Phuong();
            quanhuyen = new QuanHuyen();
            tinhthanh = new TinhThanh();
        }
        //~DiaDiem()
        //{
        //    if (ten != null)
        //    {
        //        ten = null;
        //        duong = null;
        //        phuong = null;
        //        quanhuyen = null;
        //        tinhthanh = null;
        //    }
        //}
    }
}