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