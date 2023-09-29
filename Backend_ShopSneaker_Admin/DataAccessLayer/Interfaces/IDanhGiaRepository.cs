using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface IDanhGiaRepository
    {
        //DanhGiaModel GetByID(string id);
        bool Create(DanhGiaModel model);
        bool Update(DanhGiaModel model);
        bool Delete(string id);

        List<DanhGiaModel> Search(int pageIndex, int pageSize, out long total, string tieu_de);

    }
}
