using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class ThuongHieuBusiness : IThuongHieuBusiness
    {
        private IThuongHieuRepository _res;
        public ThuongHieuBusiness(IThuongHieuRepository res)
        {
            _res = res;
        }

        public ThuongHieuModel GetSanPhamByThuongHieu(string name)
        {
            return _res.GetSanPhamByThuongHieu(name);
        }

        public List<ThuongHieuModel> GetAllThuongHieu()
        {
            return _res.GetAllThuongHieu();
        }

        public bool Create(ThuongHieuModel model)
        {
            return _res.Create(model);
        }
        public bool Update(ThuongHieuModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

       
    }
}