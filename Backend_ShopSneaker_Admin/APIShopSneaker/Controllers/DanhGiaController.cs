using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhGiaController : ControllerBase
    {
        private IDanhGiaBusiness _danhGiaBusiness;
        public DanhGiaController(IDanhGiaBusiness danhGiaBusiness)
        {
            _danhGiaBusiness = danhGiaBusiness;
        }

        


        [Route("create-danhgia")]
        [HttpPost]
        public DanhGiaModel CreateDanhGia([FromBody] DanhGiaModel model)
        {
            _danhGiaBusiness.Create(model);
            return model;
        }

        [Route("update-danhgia")]
        [HttpPost]
        public DanhGiaModel UpdateDanhGia([FromBody] DanhGiaModel model)
        {
            _danhGiaBusiness.Update(model);
            return model;
        }

        [Route("delete-danhgia")]
        [HttpPost]
        public IActionResult DeleteDanhGia([FromBody] Dictionary<string, object> formData)
        {
            string MaDanhGia = "";
            if (formData.Keys.Contains("MaDanhGia") && !string.IsNullOrEmpty(Convert.ToString(formData["MaDanhGia"]))) { MaDanhGia = Convert.ToString(formData["MaDanhGia"]); }
            _danhGiaBusiness.Delete(MaDanhGia);
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
                string tieu_de = "";
                long total = 0;
                if (formData.Keys.Contains("tieu_de") && !string.IsNullOrEmpty(Convert.ToString(formData["tieu_de"]))) { tieu_de = Convert.ToString(formData["tieu_de"]); }
                var data = _danhGiaBusiness.Search(page, pageSize, out total, tieu_de);
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
