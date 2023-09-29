using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class TinhThanhPhoBusiness : ITinhThanhPhoBusiness
    {
        private ITinhThanhPhoRepository _res;
        public TinhThanhPhoBusiness(ITinhThanhPhoRepository res)
        {
            _res = res;
        }

        public bool Create(TinhThanhPhoModel model)
        {
            return _res.Create(model);
        }
        public bool Update(TinhThanhPhoModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

       
    }
}