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


        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_danhmuc = "";
                if (formData.Keys.Contains("ten_danhmuc") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_danhmuc"]))) { ten_danhmuc = Convert.ToString(formData["ten_danhmuc"]); }
                long total = 0;
                var data = _danhMucBusiness.Search(page, pageSize, out total, ten_danhmuc);
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
