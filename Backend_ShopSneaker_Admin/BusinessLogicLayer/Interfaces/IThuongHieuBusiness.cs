using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IThuongHieuBusiness
    {
        DanhMucModel GetSanPhamByThuongHieu(string name);

        List<DanhMucModel> GetAllThuongHieu();
        bool Create(DanhMucModel model);
        bool Update(DanhMucModel model);
        bool Delete(string id);

    }
}
