namespace Models
{
    public class HoaDonDatHangModel
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayTao { get; set; }
        public int MaVanChuyen { get; set; }
        public int MaKhachHang { get; set; }
        public string CodeHoaDon { get; set; }
        public DateTime NgayDat { get; set; }
        public int TrangThai { get; set; }

    }
    public class ChiTietHDModel
    {
        public int MaChiTietHD { get; set; }
        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public int TongTien { get; set; }
        public int MaGiamGia { get; set; }
        public int MaPhiVC { get; set; }

    }
}