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
            var account = _res.Login(taikhoan, matkhau);
            if (account == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, account.TenTaiKhoan.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            account.token = tokenHandler.WriteToken(token);
            return account;
        }

        public TaiKhoanModel GetByID(string maTK)
        {
            return _res.GetByID(maTK);
        }

        public bool SignUp(TaiKhoanModel model)
        {
            return _res.SignUp(model);
        }

        public TaiKhoanModel GetByName(string username)
        {
            return _res.GetByName(username);
        }

        public List<TaiKhoanModel> GetAllTaiKhoan()
        {
            return _res.GetAllTaiKhoan();
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