using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using Microsoft.AspNetCore.Authorization;

namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanBusiness _taiKhoanBusiness;
        public TaiKhoanController(ITaiKhoanBusiness quanTriVienBusiness)
        {
            _taiKhoanBusiness = quanTriVienBusiness;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var account = _taiKhoanBusiness.Login(model.Username, model.Password);
            if (account == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { username = account.TenTaiKhoan, maquyen = account.MaQuyen,  token = account.token });
        }

        [Route("get-by-id/{maTK}")]
        [HttpGet]
        public TaiKhoanModel GetByID(string maTK)
        {
            return _taiKhoanBusiness.GetByID(maTK);
        }

        [Route("get-by-name/{username}")]
        [HttpGet]
        public TaiKhoanModel GetByName(string username)
        {
            return _taiKhoanBusiness.GetByName(username);
        }

        [Route("get-all")]
        [HttpGet]
        public List<TaiKhoanModel> GetAllTaiKhoan()
        {
            return _taiKhoanBusiness.GetAllTaiKhoan();
        }


        [Route("create-taikhoan")]
        [HttpPost]
        public TaiKhoanModel CreateTaiKhoan([FromBody] TaiKhoanModel model)
        {
            _taiKhoanBusiness.Create(model);
            return model;
        }

        [Route("update-taikhoan")]
        [HttpPut]
        public TaiKhoanModel UpdateTaiKhoan([FromBody] TaiKhoanModel model)
        {
            _taiKhoanBusiness.Update(model);
            return model;
        }

        [Route("delete-taikhoan")]
        [HttpDelete]
        public IActionResult DeleteTaiKhoan([FromBody] Dictionary<string, object> formData)
        {
            string MaQTV = "";
            if (formData.Keys.Contains("MaQTV") && !string.IsNullOrEmpty(Convert.ToString(formData["MaQTV"]))) { MaQTV = Convert.ToString(formData["MaQTV"]); }
            _taiKhoanBusiness.Delete(MaQTV);
            return Ok();
        }


        
       


    }
}
