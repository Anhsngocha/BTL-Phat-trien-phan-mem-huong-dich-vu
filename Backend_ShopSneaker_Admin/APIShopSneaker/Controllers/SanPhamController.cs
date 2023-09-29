using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanPhamBusiness;
        public SanPhamController(ISanPhamBusiness sanPhamBusiness)
        {
            _sanPhamBusiness = sanPhamBusiness;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPhamModel GetSanPhamByID(string id)
        {
            return _sanPhamBusiness.GetSanPhamByID(id);
        }

        [Route("get-all-sp")]
        [HttpGet]
        public List<SanPhamModel> GetAllSanPham()
        {
            return _sanPhamBusiness.GetAllSanPham();
        }


        [Route("create-sanpham")]
        [HttpPost]
        public SanPhamModel CreateSanPham([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Create(model);
            return model;
        }

        [Route("update-sanpham")]
        [HttpPost]
        public SanPhamModel UpdateItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Update(model);
            return model;
        }

        [Route("delete-sanpham")]
        [HttpDelete]
        public IActionResult DeleteSanPham([FromBody] Dictionary<string, object> formData)
        {
            string MaSanPham = "";
            if (formData.Keys.Contains("MaSanPham") && !string.IsNullOrEmpty(Convert.ToString(formData["MaSanPham"]))) { MaSanPham = Convert.ToString(formData["MaSanPham"]); }
            _sanPhamBusiness.Delete(MaSanPham);
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
                string ten_sanpham = "";
                if (formData.Keys.Contains("ten_sanpham") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_sanpham"]))) { ten_sanpham = Convert.ToString(formData["ten_sanpham"]); }

                int gia_tien = formData.ContainsKey("gia_tien") && int.TryParse(formData["gia_tien"].ToString(), out var giaTienValue) ? giaTienValue : 0;

                //int gia_tien = 0;
                //if (formData.Keys.Contains("gia_tien") && !string.IsNullOrEmpty(Convert.ToString(formData["gia_tien"]))) { gia_tien = Convert.ToInt32(formData["gia_tien"]); }
                long total = 0;
                var data = _sanPhamBusiness.Search(page, pageSize, out total, ten_sanpham, gia_tien);
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
