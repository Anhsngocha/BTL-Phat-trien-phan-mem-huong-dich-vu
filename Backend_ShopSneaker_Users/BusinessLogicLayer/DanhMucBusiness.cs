using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class DanhMucBusiness : IDanhMucBusiness
    {
        private IDanhMucRepository _res;
        public DanhMucBusiness(IDanhMucRepository res)
        {
            _res = res;
        }

        public DanhMucModel GetDanhMucByID(string id)
        {
            return _res.GetDanhMucByID(id);
        }

        public DanhMucModel GetSanPhamByDanhMuc(string name)
        {
            return _res.GetSanPhamByDanhMuc(name);
        }

        public List<DanhMucModel> GetAllDanhMuc()
        {
            return _res.GetAllDanhMuc();
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