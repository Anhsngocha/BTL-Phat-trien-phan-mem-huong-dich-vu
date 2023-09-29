using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class GiamGiaBusiness : IGiamGiaBusiness
    {
        private IGiamGiaRepository _res;
        public GiamGiaBusiness(IGiamGiaRepository res)
        {
            _res = res;
        }

       
        public List<GiamGiaModel> GetAllGiamGia()
        {
            return _res.GetAllGiamGia();
        }

        public bool Create(GiamGiaModel model)
        {
            return _res.Create(model);
        }
        public bool Update(GiamGiaModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

       
    }
}