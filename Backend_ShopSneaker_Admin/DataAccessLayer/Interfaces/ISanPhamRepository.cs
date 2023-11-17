using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer.Interfaces
{
    public partial interface ISanPhamRepository
    {
        SanPhamModel GetSanPhamByID(string id);

        List<SanPhamModel> GetAllSanPham(int pageIndex, int pageSize, out long total);

        bool Create(SanPhamModel model);

        bool Update(SanPhamModel model);

        bool Delete(string id);

        List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string ten_sanpham, int gia_tien);
    }
}
