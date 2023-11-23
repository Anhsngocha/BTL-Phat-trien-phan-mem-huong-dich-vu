using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface IThuongHieuRepository
    {
        DanhMucModel GetSanPhamByThuongHieu(string name);
        List<DanhMucModel> GetAllThuongHieu();
        bool Create(DanhMucModel model);
        bool Update(DanhMucModel model);
        bool Delete(string id);

    }
}
