using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class ThuVienBusiness : IThuVienBusiness
    {
        private IThuVienRepository _res;
        public ThuVienBusiness(IThuVienRepository res)
        {
            _res = res;
        }

        

        public List<ThuVienModel> GetAllThuVien()
        {
            return _res.GetAllThuVien();
        }

        public bool Create(ThuVienModel model)
        {
            return _res.Create(model);
        }
        public bool Update(ThuVienModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public List<ThuVienModel> Search(int pageIndex, int pageSize, out long total, int ma_sanpham)
        {
            return _res.Search(pageIndex, pageSize, out total, ma_sanpham);
        }
    }
}