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

    public class ChiTietHDNModel
    {
        public int MaChiTietHDN { get; set; }
        public int MaHoaDonNhap { get; set; }
        public int MaThuongHieu { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public int GiaNhap { get; set; }
        public int TongTien { get; set; }

    }
}