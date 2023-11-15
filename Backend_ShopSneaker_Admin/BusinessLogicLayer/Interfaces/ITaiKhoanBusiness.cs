using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ITaiKhoanBusiness
    {
        TaiKhoanModel Login(string taikhoan, string matkhau);
        TaiKhoanModel GetQTVBySDT(string sdt);

        List<TaiKhoanModel> GetAllQuanTriVien();
        bool Create(TaiKhoanModel model);
        bool Update(TaiKhoanModel model);
        bool Delete(string id);


    }
}
