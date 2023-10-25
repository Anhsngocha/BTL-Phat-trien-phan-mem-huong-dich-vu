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
        List<ThuongHieuModel> GetAllThuongHieu();
        bool Create(ThuongHieuModel model);
        bool Update(ThuongHieuModel model);
        bool Delete(string id);

    }
}
