using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonNhapController : ControllerBase
    {
        private IHoaDonNhapBusiness _hoaDonNhapBusiness;
        public HoaDonNhapController(IHoaDonNhapBusiness hoaDonNhapBusiness)
        {
            _hoaDonNhapBusiness = hoaDonNhapBusiness;
        }

        [Route("create-hoaDonNhap")]
        [HttpPost]
        public HoaDonNhapModel CreateItem([FromBody] HoaDonNhapModel model)
        {
            _hoaDonNhapBusiness.Create(model);
            return model;
        }

        //[Route("update-hoaDonNhap")]
        //[HttpPost]
        //public HoaDonNhapModel Update([FromBody] HoaDonNhapModel model)
        //{
        //    _hoaDonNhapBusiness.Update(model);
        //    return model;
        //}
    }
}
