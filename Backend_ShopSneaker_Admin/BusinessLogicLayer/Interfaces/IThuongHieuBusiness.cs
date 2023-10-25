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
        List<ThuongHieuModel> GetAllThuongHieu();
        bool Create(ThuongHieuModel model);
        bool Update(ThuongHieuModel model);
        bool Delete(string id);

    }
}
