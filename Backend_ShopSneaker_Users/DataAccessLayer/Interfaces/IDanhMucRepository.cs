using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface IDanhMucRepository
    {
        DanhMucModel GetDanhMucByID(string id);

        //DanhMucModel GetSanPhamByDanhMuc(string name);

        List<DanhMucModel> GetAllDanhMuc();
        bool Create(DanhMucModel model);
        bool Update(DanhMucModel model);
        bool Delete(string id);

    }
}
