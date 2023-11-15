using BusinessLogicLayer;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;

namespace BusinessLogicLayer
{
    public class TaiKhoanBusiness : ITaiKhoanBusiness
    {
        private ITaiKhoanRepository _res;
        private string secret;
        public TaiKhoanBusiness(ITaiKhoanRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }

        public TaiKhoanModel Login(string taikhoan, string matkhau)
        {
            var quantrivien_account = _res.Login(taikhoan, matkhau);
            if (quantrivien_account == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, quantrivien_account.TenTaiKhoan.ToString()),
                    new Claim(ClaimTypes.Email, quantrivien_account.Email),
                    new Claim(ClaimTypes.MobilePhone, quantrivien_account.SDT.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            quantrivien_account.token = tokenHandler.WriteToken(token);
            return quantrivien_account;
        }

        public TaiKhoanModel GetQTVBySDT(string sdt)
        {
            return _res.GetQTVBySDT(sdt);
        }

        public List<TaiKhoanModel> GetAllQuanTriVien()
        {
            return _res.GetAllQuanTriVien();
        }

        public bool Create(TaiKhoanModel model)
        {
            return _res.Create(model);
        }
        public bool Update(TaiKhoanModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        
    }
}