namespace Models
{
    public class HoaDonDatHangModel
    {
        public int MaHoaDonBan { get; set; }
        public DateTime NgayTao { get; set; }
        public int MaVanChuyen { get; set; }
        public int MaKhachHang { get; set; }
        public string CodeHoaDon { get; set; }
        public DateTime NgayDat { get; set; }
        public int TrangThai { get; set; }

        List<ChiTietHDBModel> list_json_chitietHDBan { get; set; }
    }
   
}