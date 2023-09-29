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

        public List<SanPhamModel> GetAllSanPham()
        {
            return _res.GetAllSanPham();
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

        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string TenSanPham, int GiaTien)
        {
            return _res.Search(pageIndex, pageSize, out total, TenSanPham, GiaTien);
        }
    }
}