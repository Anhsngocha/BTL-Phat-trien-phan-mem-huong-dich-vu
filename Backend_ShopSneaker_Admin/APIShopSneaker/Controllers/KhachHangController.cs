using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace Api.BTL.Controllers
{
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
                string ten_khachhang = "";
                if (formData.Keys.Contains("ten_khachhang") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khachhang"]))) { ten_khachhang = Convert.ToString(formData["ten_khachhang"]); }
                string diachi = "";
                if (formData.Keys.Contains("diachi") && !string.IsNullOrEmpty(Convert.ToString(formData["diachi"]))) { diachi = Convert.ToString(formData["diachi"]); }
                long total = 0;
                var data = _khachHangBusiness.Search(page, pageSize, out total, ten_khachhang, diachi);
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
