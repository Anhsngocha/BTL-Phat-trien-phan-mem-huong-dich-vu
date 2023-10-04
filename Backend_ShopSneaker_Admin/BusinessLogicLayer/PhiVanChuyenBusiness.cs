using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class PhiVanChuyenBusiness : IPhiVanChuyenBusiness
    {
        private IPhiVanChuyenRepository _res;
        public PhiVanChuyenBusiness(IPhiVanChuyenRepository res)
        {
            _res = res;
        }

        public bool Create(PhiVanChuyenModel model)
        {
            return _res.Create(model);
        }
        public bool Update(PhiVanChuyenModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

       
    }
}