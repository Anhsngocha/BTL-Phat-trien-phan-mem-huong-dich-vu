using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer
{
    public class ThuongHieuRepository : IThuongHieuRepository
    {
        private IDatabaseHelper _dbHelper;
        public ThuongHieuRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public bool Create(ThuongHieuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_thuonghieu",
                    "@TenThuongHieu", model.TenThuongHieu);
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

        public bool Update(ThuongHieuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_thuonghieu",
                    "@MaThuongHieu", model.MaThuongHieu,
                    "@TenThuongHieu", model.TenThuongHieu);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_thuonghieu",
                "@MaThuongHieu", id);
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
