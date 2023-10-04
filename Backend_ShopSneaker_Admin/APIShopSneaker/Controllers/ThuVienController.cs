using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuVienController : ControllerBase
    {
        private IThuVienBusiness _thuVienBusiness;
        public ThuVienController(IThuVienBusiness thuVienBusiness)
        {
            _thuVienBusiness = thuVienBusiness;
        }

      
        [Route("get-all")]
        [HttpGet]
        public List<ThuVienModel> GetAllThuVien()
        {
            return _thuVienBusiness.GetAllThuVien();
        }


        [Route("create-thuvien")]
        [HttpPost]
        public ThuVienModel CreateThuVien([FromBody] ThuVienModel model)
        {
            _thuVienBusiness.Create(model);
            return model;
        }

        [Route("update-thuvien")]
        [HttpPost]
        public ThuVienModel UpdateThuVien([FromBody] ThuVienModel model)
        {
            _thuVienBusiness.Update(model);
            return model;
        }

        [Route("delete-thuvien")]
        [HttpPost]
        public IActionResult DeleteDanhMuc([FromBody] Dictionary<string, object> formData)
        {
            string MaThuVien = "";
            if (formData.Keys.Contains("MaThuVien") && !string.IsNullOrEmpty(Convert.ToString(formData["MaThuVien"]))) { MaThuVien = Convert.ToString(formData["MaThuVien"]); }
            _thuVienBusiness.Delete(MaThuVien);
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
                int ma_sanpham = formData.ContainsKey("ma_sanpham") && int.TryParse(formData["ma_sanpham"].ToString(), out var maSanPhamValue) ? maSanPhamValue : 0;

                
                long total = 0;
                var data = _thuVienBusiness.Search(page, pageSize, out total, ma_sanpham);
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
