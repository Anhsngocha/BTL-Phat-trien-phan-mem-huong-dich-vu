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
        public DanhMucModel GetSanPhamByThuongHieu(string name)
        {
            return _thuongHieuBusiness.GetSanPhamByThuongHieu(name);
        }


        [Route("get-all")]
        [HttpGet]
        public List<DanhMucModel> GetAllThuongHieu()
        {
            return _thuongHieuBusiness.GetAllThuongHieu();
        }

        [Route("create-thuonghieu")]
        [HttpPost]
        public DanhMucModel CreateThuongHieu([FromBody] DanhMucModel model)
        {
            _thuongHieuBusiness.Create(model);
            return model;
        }

        [Route("update-thuonghieu")]
        [HttpPost]
        public DanhMucModel UpdateThuongHieu([FromBody] DanhMucModel model)
        {
            _thuongHieuBusiness.Update(model);
            return model;
        }

        [Route("delete-thuonghieu")]
        [HttpPost]
        public IActionResult DeleteThuongHieu([FromBody] Dictionary<string, object> formData)
        {
            string MaThuongHieu = "";
            if (formData.Keys.Contains("MaThuongHieu") && !string.IsNullOrEmpty(Convert.ToString(formData["MaThuongHieu"]))) { MaThuongHieu = Convert.ToString(formData["MaThuongHieu"]); }
            _thuongHieuBusiness.Delete(MaThuongHieu);
            return Ok();
        }

    }
}
