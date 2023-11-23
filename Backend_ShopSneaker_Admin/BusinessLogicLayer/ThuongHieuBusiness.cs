using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class ThuongHieuBusiness : IThuongHieuBusiness
    {
        private IDanhMucRepository _res;
        public ThuongHieuBusiness(IDanhMucRepository res)
        {
            _res = res;
        }

        public DanhMucModel GetSanPhamByThuongHieu(string name)
        {
            return _res.GetSanPhamByThuongHieu(name);
        }

        public List<DanhMucModel> GetAllThuongHieu()
        {
            return _res.GetAllThuongHieu();
        }

        public bool Create(DanhMucModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DanhMucModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

       
    }
}