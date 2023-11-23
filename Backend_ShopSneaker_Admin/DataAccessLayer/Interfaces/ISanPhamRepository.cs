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

        List<SanPhamModel> GetNewSanPham();

        List<SanPhamModel> GetAllSanPham(int pageIndex, int pageSize, out long total);

        bool Create(SanPhamModel model);

        bool Update(SanPhamModel model);

        bool Delete(string id);

        List<SanPhamModel> SearchTheoTen(int pageIndex, int pageSize, out long total, string ten_sanpham);

        List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, decimal fr_gia, decimal to_gia);
    }
}
