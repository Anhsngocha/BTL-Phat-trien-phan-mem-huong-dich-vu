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

        [Route("get-sanpham-new")]
        [HttpGet]
        public List<SanPhamModel> GetNewSanPham()
        {
            return _sanPhamBusiness.GetNewSanPham();
        }



        [Route("get-all-sp")]
        [HttpGet]
        public IActionResult GetAllSanPham([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                
                long total = 0;
                var data = _sanPhamBusiness.GetAllSanPham(page, pageSize, out total);
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


        [Route("create-sanpham")]
        [HttpPost]
        public SanPhamModel CreateSanPham([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Create(model);
            return model;
        }

        [Route("update-sanpham")]
        [HttpPut]
        public SanPhamModel UpdateSanPham([FromBody] SanPhamModel model)
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


        [Route("search-by-ten")]
        [HttpPost]
        public IActionResult SearchTheoTen([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_sanpham = "";
                if (formData.Keys.Contains("ten_sanpham") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_sanpham"]))) { ten_sanpham = Convert.ToString(formData["ten_sanpham"]); }

                long total = 0;
                var data = _sanPhamBusiness.SearchTheoTen(page, pageSize, out total, ten_sanpham);
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

        [Route("search-by-gia")]
        [HttpPost]
        public IActionResult SearchTheoGia([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_sanpham = "";
                if (formData.Keys.Contains("ten_sanpham") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_sanpham"]))) { ten_sanpham = Convert.ToString(formData["ten_sanpham"]); }
                decimal fr_price = formData.ContainsKey("fr_price") && int.TryParse(formData["fr_price"].ToString(), out var fr_priceValue) ? fr_priceValue : 0;
                decimal to_price = formData.ContainsKey("to_price") && int.TryParse(formData["to_price"].ToString(), out var to_priceValue) ? to_priceValue : 0;


                long total = 0;
                var data = _sanPhamBusiness.SearchTheoGia(page, pageSize, out total, fr_price, to_price);
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
