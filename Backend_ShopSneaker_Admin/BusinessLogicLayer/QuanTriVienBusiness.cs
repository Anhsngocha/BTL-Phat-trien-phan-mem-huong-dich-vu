using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class QuanTriVienBusiness : IQuanTriVienBusiness
    {
        private IQuanTriVienRepository _res;
        public QuanTriVienBusiness(IQuanTriVienRepository res)
        {
            _res = res;
        }

        public QuanTriVienModel GetQTVBySDT(string sdt)
        {
            return _res.GetQTVBySDT(sdt);
        }

        public List<QuanTriVienModel> GetAllQuanTriVien()
        {
            return _res.GetAllQuanTriVien();
        }

        public bool Create(QuanTriVienModel model)
        {
            return _res.Create(model);
        }
        public bool Update(QuanTriVienModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        
    }
}