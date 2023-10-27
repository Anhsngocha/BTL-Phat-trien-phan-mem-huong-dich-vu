namespace Models
{
    public class DanhMucModel
    {
        public int MaDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }

        public List<SanPhamModel> list_json_sanpham_by_danhmuc { get; set; }

    }
}