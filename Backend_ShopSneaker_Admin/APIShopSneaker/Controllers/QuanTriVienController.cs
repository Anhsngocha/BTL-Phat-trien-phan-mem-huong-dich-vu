using BusinessLogicLayer;
using Models;
using Microsoft.AspNetCore.Mvc;
using DataModel;
using Microsoft.AspNetCore.Authorization;

namespace Api.BTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanTriVienController : ControllerBase
    {
        private IQuanTriVienBusiness _quanTriVienBusiness;
        public QuanTriVienController(IQuanTriVienBusiness quanTriVienBusiness)
        {
            _quanTriVienBusiness = quanTriVienBusiness;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var quantrivien_account = _quanTriVienBusiness.Login(model.Username, model.Password);
            if (quantrivien_account == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { username = quantrivien_account.TenTaiKhoan, email = quantrivien_account.Email, phone = quantrivien_account.SDT, token = quantrivien_account.token });
        }

        [Route("get-by-sdt/{sdt}")]
        [HttpGet]
        public TaiKhoanModel GetQTVBySDT(string sdt)
        {
            return _quanTriVienBusiness.GetQTVBySDT(sdt);
        }

        [Route("get-all")]
        [HttpGet]
        public List<TaiKhoanModel> GetAllQuanTriVien()
        {
            return _quanTriVienBusiness.GetAllQuanTriVien();
        }


        [Route("create-quantrivien")]
        [HttpPost]
        public TaiKhoanModel CreateQuanTriVien([FromBody] TaiKhoanModel model)
        {
            _quanTriVienBusiness.Create(model);
            return model;
        }

        [Route("update-quantrivien")]
        [HttpPost]
        public TaiKhoanModel UpdateKhachHang([FromBody] TaiKhoanModel model)
        {
            _quanTriVienBusiness.Update(model);
            return model;
        }

        [Route("delete-quantrivien")]
        [HttpPost]
        public IActionResult DeleteKhachHang([FromBody] Dictionary<string, object> formData)
        {
            string MaQTV = "";
            if (formData.Keys.Contains("MaQTV") && !string.IsNullOrEmpty(Convert.ToString(formData["MaQTV"]))) { MaQTV = Convert.ToString(formData["MaQTV"]); }
            _quanTriVienBusiness.Delete(MaQTV);
            return Ok();
        }


        
       


    }
}
