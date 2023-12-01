namespace Models
{
    public class HoaDonNhapModel
    {
        public int MaHoaDonNhap { get; set; }
        public string MaDanhMuc { get; set; }
        public DateTime NgayNhap { get; set; }
        public int TongTien { get; set; }

        public List<ChiTietHDNModel> list_json_chitietHDN { get; set; }
    }

}