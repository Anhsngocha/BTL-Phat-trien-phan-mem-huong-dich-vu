using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;

namespace BusinessLogicLayer
{
    public class HoaDonNhapBusiness : IHoaDonNhapBusiness
    {
        private IHoaDonNhapRepository _res;

        public HoaDonNhapBusiness(IHoaDonNhapRepository res)
        {
            _res = res;
        }

        public bool Create(HoaDonNhapModel model)
        {
            return _res.Create(model);
        }

        //public bool Update(HoaDonNhapModel model)
        //{
        //    return _res.Update(model);
        //}
    }
}