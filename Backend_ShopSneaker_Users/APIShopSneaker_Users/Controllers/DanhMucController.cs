using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private IDanhMucBusiness _danhMucBusiness;
        public DanhMucController(IDanhMucBusiness danhMucBusiness)
        {
            _danhMucBusiness = danhMucBusiness;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public DanhMucModel GetDanhMucByID(string id)
        {
            return _danhMucBusiness.GetDanhMucByID(id);
        }

        [Route("get-sp-by-danhmuc/{name}")]
        [HttpGet]
        public DanhMucModel GetSanPhamByDanhMuc(string name)
        {
            return _danhMucBusiness.GetSanPhamByDanhMuc(name);
        }

        [Route("get-all")]
        [HttpGet]
        public List<DanhMucModel> GetAllDanhMuc()
        {
            return _danhMucBusiness.GetAllDanhMuc();
        }

            }
}
