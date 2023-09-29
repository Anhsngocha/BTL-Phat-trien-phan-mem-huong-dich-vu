using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IDanhGiaBusiness
    {
        
        bool Create(DanhGiaModel model);
        bool Update(DanhGiaModel model);
        bool Delete(string id);

        List<DanhGiaModel> Search(int pageIndex, int pageSize, out long total, string TieuDe);

    }
}
