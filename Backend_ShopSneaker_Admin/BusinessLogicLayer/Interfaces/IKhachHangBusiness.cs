using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IKhachHangBusiness
    {
        KhachHangModel GetKhachHangByID(string id);

        List<KhachHangModel> GetAllKhachHang();
        bool Create(KhachHangModel model);
        bool Update(KhachHangModel model);
        bool Delete(string id);

        List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string TenKhachHang, string SDT);

    }
}
