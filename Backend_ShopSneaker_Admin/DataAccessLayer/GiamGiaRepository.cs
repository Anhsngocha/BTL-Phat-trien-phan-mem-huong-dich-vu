using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer
{
    public class GiamGiaRepository : IGiamGiaRepository
    {
        private IDatabaseHelper _dbHelper;
        public GiamGiaRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        
        public List<GiamGiaModel> GetAllGiamGia()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_magiamgia");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiamGiaModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(GiamGiaModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_them_magiamgia",
                    "@TenMaGG", model.TenMaGG,
                    "@BatDau", model.BatDau,
                    "@KetThuc", model.KetThuc,
                    "@SoLuongMa", model.SoLuongMa,
                    "@SoTienGiam", model.SoTienGiam,
                    "@MaCode", model.MaCode,
                    "@TrangThai", model.TrangThai);
                if ((result != null && string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(GiamGiaModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_magiamgia",
                    "@MaGiamGia", model.MaGiamGia,
                    "@TenMaGG", model.TenMaGG,
                    "@BatDau", model.BatDau,
                    "@KetThuc", model.KetThuc,
                    "@SoLuongMa", model.SoLuongMa,
                    "@SoTienGiam", model.SoTienGiam,
                    "@MaCode", model.MaCode,
                    "@TrangThai", model.TrangThai);
                if ((result != null && string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_magiamgia",
                "@MaGiamGia", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
