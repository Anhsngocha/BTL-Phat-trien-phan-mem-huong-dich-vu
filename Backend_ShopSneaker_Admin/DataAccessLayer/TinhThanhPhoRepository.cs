using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer
{
    public class TinhThanhPhoRepository : ITinhThanhPhoRepository
    {
        private IDatabaseHelper _dbHelper;
        public TinhThanhPhoRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }



        public bool Create(TinhThanhPhoModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_tinhthanhpho",
                    "@TenTinhTP", model.TenTinhTP);
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

        public bool Update(TinhThanhPhoModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_tinhthanhpho",
                    "@MaTinhTP", model.MaTinhTP,
                    "@TenTinhTP", model.TenTinhTP);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_tinhthanhpho",
                "@MaTinhTP", id);
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
