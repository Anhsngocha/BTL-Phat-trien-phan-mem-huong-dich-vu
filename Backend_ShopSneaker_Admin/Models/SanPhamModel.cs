namespace Models
{
    public class SanPhamModel
    {
        public int MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public string AnhDaiDien { get; set; }


        public Decimal GiaTien { get; set; }

        public Decimal GiamGia { get; set; }

        public string MoTa { get; set; }

        public int DaBan { get; set; }

        public int MaDanhMuc { get; set; }

        public int MaThuongHieu { get; set; }

        public string TenDanhMuc { get; set; }

        public string TenThuongHieu { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }
    }
}