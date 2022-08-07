
namespace MyWebApiApp.Data
{
    public enum Tinhtrangdonhang
    {
        New = 0, Payment = 1, Complete =2 , Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDH { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? ngaygiao { get; set; }
        public Tinhtrangdonhang TinhTrangDonHang { get; set; }
        public string nguoinhan { get; set; }
        public string DiaChiGiao { get; set; }
        public string SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
     
}
