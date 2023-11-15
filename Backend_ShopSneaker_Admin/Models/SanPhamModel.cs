namespace Models
{
    public class SanPhamModel
    {
        public int MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public string AnhDaiDien { get; set; }

        public decimal GiaTien { get; set; }

        public decimal GiamGia { get; set; }

        public int DaBan { get; set; }

        public int MaThuongHieu { get; set; }

        public string TenDanhMuc { get; set; }

        public string TenThuongHieu { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public List<ChiTietSanPhamModel> list_json_chitietSP { get; set; }
    }
}