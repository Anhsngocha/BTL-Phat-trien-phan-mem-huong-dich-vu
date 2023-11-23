namespace Models
{
    public class DanhMucModel
    {
        public int MaThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }

        public List<SanPhamModel> list_json_sanpham_by_thuonghieu { get; set; }

    }
}