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


        [Route("create-danhmuc")]
        [HttpPost]
        public DanhMucModel CreateDanhMuc([FromBody] DanhMucModel model)
        {
            _danhMucBusiness.Create(model);
            return model;
        }

        [Route("update-danhmuc")]
        [HttpPost]
        public DanhMucModel UpdateDanhMuc([FromBody] DanhMucModel model)
        {
            _danhMucBusiness.Update(model);
            return model;
        }

        [Route("delete-danhmuc")]
        [HttpPost]
        public IActionResult DeleteDanhMuc([FromBody] Dictionary<string, object> formData)
        {
            string MaDanhMuc = "";
            if (formData.Keys.Contains("MaDanhMuc") && !string.IsNullOrEmpty(Convert.ToString(formData["MaDanhMuc"]))) { MaDanhMuc = Convert.ToString(formData["MaDanhMuc"]); }
            _danhMucBusiness.Delete(MaDanhMuc);
            return Ok();
        }

            }
}
