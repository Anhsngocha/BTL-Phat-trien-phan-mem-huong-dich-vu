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

        bool SignUp(TaiKhoanModel model);
        TaiKhoanModel GetByID(string id);

        TaiKhoanModel GetByName(string username);

        List<TaiKhoanModel> GetAllTaiKhoan();
        bool Create(TaiKhoanModel model);
        bool Update(TaiKhoanModel model);
        bool Delete(string id);


    }
}
