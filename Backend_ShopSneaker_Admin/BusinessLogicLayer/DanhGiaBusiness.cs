using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class DanhGiaBusiness : IDanhGiaBusiness
    {
        private IDanhGiaRepository _res;
        public DanhGiaBusiness(IDanhGiaRepository res)
        {
            _res = res;
        }

       

        public bool Create(DanhGiaModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DanhGiaModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public List<DanhGiaModel> Search(int pageIndex, int pageSize, out long total, string TieuDe)
        {
            return _res.Search(pageIndex, pageSize, out total, TieuDe);
        }
    }
}