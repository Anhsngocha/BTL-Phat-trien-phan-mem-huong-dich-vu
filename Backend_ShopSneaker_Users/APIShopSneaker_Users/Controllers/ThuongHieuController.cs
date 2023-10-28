using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuongHieuController : ControllerBase
    {
        private IThuongHieuBusiness _thuongHieuBusiness;
        public ThuongHieuController(IThuongHieuBusiness thuongHieuBusiness)
        {
            _thuongHieuBusiness = thuongHieuBusiness;
        }

        [Route("get-sp-by-thuonghieu/{name}")]
        [HttpGet]
        public ThuongHieuModel GetSanPhamByThuongHieu(string name)
        {
            return _thuongHieuBusiness.GetSanPhamByThuongHieu(name);
        }


        [Route("get-all")]
        [HttpGet]
        public List<ThuongHieuModel> GetAllThuongHieu()
        {
            return _thuongHieuBusiness.GetAllThuongHieu();
        }

        
    }
}
