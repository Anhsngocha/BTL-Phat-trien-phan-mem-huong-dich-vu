using System.Text;

namespace Models
{
    public class TaiKhoanModel
    {
        public int MaTK { get; set; }
        public string TenTaiKhoan { get; set; }

        public string MatKhau { get; set; }

        public int MaQuyen { get; set; }

        public string token { get; set; }

        public List<ChiTietTaiKhoanModel> list_json_chitietTK { get; set; }
    }


    public class ChiTietTaiKhoanModel
    {
        public int MaChiTiet { get; set; }
        public string Ho { get; set; }

        public string Ten { get; set; }

        public string GioiTinh { get; set; }

        public string SDT { get; set; }

        public string DiaChi { get; set; }

        public string Email { get; set; }

        public int MaTK { get; set; }
    }
}