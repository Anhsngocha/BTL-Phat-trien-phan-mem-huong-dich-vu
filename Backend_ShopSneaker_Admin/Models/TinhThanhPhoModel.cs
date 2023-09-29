namespace Models
{
    public class TinhThanhPhoModel
    {
        public int MaTinhTP { get; set; }
        public string TenTinhTP { get; set; }

    }
    public class QuanHuyenModel
    {
        public int MaQuanHuyen { get; set; }
        public string TenQuanHuyen { get; set; }
        public int MaTinhTP { get; set; }

    }

    public class XaPhuongModel
    {
        public int MaXaPhuong { get; set; }
        public string TenXaPhuong { get; set; }
        public int MaQuanHuyen { get; set; }

    }
}