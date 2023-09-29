using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        private IGiamGiaBusiness _giamGiaBusiness;
        public GiamGiaController(IGiamGiaBusiness giamGiaBusiness)
        {
            _giamGiaBusiness = giamGiaBusiness;
        }

        

        [Route("get-all")]
        [HttpGet]
        public List<GiamGiaModel> GetAllGiamGia()
        {
            return _giamGiaBusiness.GetAllGiamGia();
        }


        [Route("create-magiamgia")]
        [HttpPost]
        public GiamGiaModel CreateGiamGia([FromBody] GiamGiaModel model)
        {
            _giamGiaBusiness.Create(model);
            return model;
        }

        [Route("update-giamgia")]
        [HttpPost]
        public GiamGiaModel UpdateGiamGia([FromBody] GiamGiaModel model)
        {
            _giamGiaBusiness.Update(model);
            return model;
        }

        [Route("delete-giamgia")]
        [HttpPost]
        public IActionResult DeleteGiamGia([FromBody] Dictionary<string, object> formData)
        {
            string MaGiamGia = "";
            if (formData.Keys.Contains("MaGiamGia") && !string.IsNullOrEmpty(Convert.ToString(formData["MaGiamGia"]))) { MaGiamGia = Convert.ToString(formData["MaGiamGia"]); }
            _giamGiaBusiness.Delete(MaGiamGia);
            return Ok();
        }

    }
}
