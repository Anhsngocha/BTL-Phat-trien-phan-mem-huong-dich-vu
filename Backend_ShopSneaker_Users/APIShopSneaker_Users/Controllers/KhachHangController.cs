using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Api.BTL.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private IKhachHangBusiness _khachHangBusiness;
        public KhachHangController(IKhachHangBusiness khachHangBusiness)
        {
            _khachHangBusiness = khachHangBusiness;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public KhachHangModel GetKhachHangByID(string id)
        {
            return _khachHangBusiness.GetKhachHangByID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public List<KhachHangModel> GetAllKhachHang()
        {
            return _khachHangBusiness.GetAllKhachHang();
        }


        [Route("create-khachhang")]
        [HttpPost]
        public KhachHangModel CreateKhachHang([FromBody] KhachHangModel model)
        {
            _khachHangBusiness.Create(model);
            return model;
        }

        [Route("update-khachhang")]
        [HttpPost]
        public KhachHangModel UpdateKhachHang([FromBody] KhachHangModel model)
        {
            _khachHangBusiness.Update(model);
            return model;
        }

        [Route("delete-khachhang")]
        [HttpPost]
        public IActionResult DeleteKhachHang([FromBody] Dictionary<string, object> formData)
        {
            string MaKhachHang = "";
            if (formData.Keys.Contains("MaKhachHang") && !string.IsNullOrEmpty(Convert.ToString(formData["MaKhachHang"]))) { MaKhachHang = Convert.ToString(formData["MaKhachHang"]); }
            _khachHangBusiness.Delete(MaKhachHang);
            return Ok();
        }


        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenKhachHang = "";
                if (formData.Keys.Contains("TenKhachHang") && !string.IsNullOrEmpty(Convert.ToString(formData["TenKhachHang"]))) { TenKhachHang = Convert.ToString(formData["TenKhachHang"]); }
                string DiaChi = "";
                if (formData.Keys.Contains("DiaChi") && !string.IsNullOrEmpty(Convert.ToString(formData["DiaChi"]))) { DiaChi = Convert.ToString(formData["DiaChi"]); }
                long total = 0;
                var data = _khachHangBusiness.Search(page, pageSize, out total, TenKhachHang, DiaChi);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
