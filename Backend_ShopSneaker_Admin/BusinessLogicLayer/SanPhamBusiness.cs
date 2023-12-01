using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class SanPhamBusiness : ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        }

        public SanPhamModel GetSanPhamByID(string id)
        {
            return _res.GetSanPhamByID(id);
        }

        public List<SanPhamModel> GetAllSanPham(int pageIndex, int pageSize, out long total)
        {
            return _res.GetAllSanPham(pageIndex, pageSize, out total);
        }

        public List<SanPhamModel> GetNewSanPham()
        {
            return _res.GetNewSanPham();
        }

        public bool Create(SanPhamModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public List<SanPhamModel> SearchTheoTen(int pageIndex, int pageSize, out long total, string ten_sanpham)
        {
            return _res.SearchTheoTen(pageIndex, pageSize, out total, ten_sanpham);
        }

        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, decimal fr_price, decimal to_price)
        {
            return _res.SearchTheoGia(pageIndex, pageSize, out total, fr_price, to_price);
        }
    }
}