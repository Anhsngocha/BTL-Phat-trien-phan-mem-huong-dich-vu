using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;

namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhThanhPhoController : ControllerBase
    {
        private ITinhThanhPhoBusiness _tinhThanhPhoBusiness;
        public TinhThanhPhoController(ITinhThanhPhoBusiness tinhThanhPhoBusiness)
        {
            _tinhThanhPhoBusiness = tinhThanhPhoBusiness;
        }



        [Route("create-tinhthanhpho")]
        [HttpPost]
        public TinhThanhPhoModel CreateTinhThanhPho([FromBody] TinhThanhPhoModel model)
        {
            _tinhThanhPhoBusiness.Create(model);
            return model;
        }

        [Route("update-tinhthanhpho")]
        [HttpPost]
        public TinhThanhPhoModel UpdateTinhThanhPho([FromBody] TinhThanhPhoModel model)
        {
            _tinhThanhPhoBusiness.Update(model);
            return model;
        }

        [Route("delete-tinhthanhpho")]
        [HttpPost]
        public IActionResult DeleteTinhThanhPho([FromBody] Dictionary<string, object> formData)
        {
            string MaTinhTP = "";
            if (formData.Keys.Contains("MaTinhTP") && !string.IsNullOrEmpty(Convert.ToString(formData["MaTinhTP"]))) { MaTinhTP = Convert.ToString(formData["MaTinhTP"]); }
            _tinhThanhPhoBusiness.Delete(MaTinhTP);
            return Ok();
        }

    }
}
