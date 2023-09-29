using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class KhachHangBusiness : IKhachHangBusiness
    {
        private IKhachHangRepository _res;
        public KhachHangBusiness(IKhachHangRepository res)
        {
            _res = res;
        }

        public KhachHangModel GetKhachHangByID(string id)
        {
            return _res.GetKhachHangByID(id);
        }

        public List<KhachHangModel> GetAllKhachHang()
        {
            return _res.GetAllKhachHang();
        }

        public bool Create(KhachHangModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhachHangModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public List<KhachHangModel> Search(int pageIndex, int pageSize, out long total, string TenKhachHang, string SDT)
        {
            return _res.Search(pageIndex, pageSize, out total, TenKhachHang, SDT);
        }
    }
}