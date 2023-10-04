using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces;

namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhiVanChuyenController : ControllerBase
    {
        private IPhiVanChuyenBusiness _phiVanChuyenBusiness;
        public PhiVanChuyenController(IPhiVanChuyenBusiness phiVanChuyenBusiness)
        {
            _phiVanChuyenBusiness = phiVanChuyenBusiness;
        }



        [Route("create-phivanchuyen")]
        [HttpPost]
        public PhiVanChuyenModel CreatePhiVanChuyen([FromBody] PhiVanChuyenModel model)
        {
            _phiVanChuyenBusiness.Create(model);
            return model;
        }

        [Route("update-phivanchuyen")]
        [HttpPost]
        public PhiVanChuyenModel UpdatePhiVanChuyen([FromBody] PhiVanChuyenModel model)
        {
            _phiVanChuyenBusiness.Update(model);
            return model;
        }

        [Route("delete-phivanchuyen")]
        [HttpPost]
        public IActionResult DeletePhiVanChuyen([FromBody] Dictionary<string, object> formData)
        {
            string MaPhiVC = "";
            if (formData.Keys.Contains("MaPhiVC") && !string.IsNullOrEmpty(Convert.ToString(formData["MaPhiVC"]))) { MaPhiVC = Convert.ToString(formData["MaPhiVC"]); }
            _phiVanChuyenBusiness.Delete(MaPhiVC);
            return Ok();
        }

    }
}
