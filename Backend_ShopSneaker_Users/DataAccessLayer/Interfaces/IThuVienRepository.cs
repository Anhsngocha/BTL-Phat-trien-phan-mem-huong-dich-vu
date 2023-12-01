using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface IThuVienRepository
    {

        List<ThuVienModel> GetAllThuVien();
        bool Create(ThuVienModel model);
        bool Update(ThuVienModel model);
        bool Delete(string id);

        List<ThuVienModel> Search(int pageIndex, int pageSize, out long total, int ma_sanpham);
    }
}
