﻿namespace Models
{
    public class SanPhamModel
    {
        public int MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public int GiaTien { get; set; }

        public int GiamGia { get; set; }

        public string LinkAnh { get; set; }

        public string MoTa { get; set; }

        public int SoLuong { get; set; }

        public int DaBan { get; set; }

        public int MaDanhMuc { get; set; }

        public int MaThuongHieu { get; set; }

        public string TenDanhMuc { get; set; }

        public string TenThuongHieu { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }
    }
}