namespace CityTravelService.Models
{
    public class DiaDiem
    {
        public DichVu dichvu;
        public TenDiaDiem ten;
        public Duong duong;
        public Phuong phuong;
        public QuanHuyen quanhuyen;
        public TinhThanh tinhthanh;

        public DiaDiem()
        {
            dichvu = new DichVu();
            ten = new TenDiaDiem();
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