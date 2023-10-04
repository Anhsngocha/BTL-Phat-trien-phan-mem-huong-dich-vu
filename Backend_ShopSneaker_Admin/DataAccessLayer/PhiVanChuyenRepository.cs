using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer
{
    public class PhiVanChuyenRepository : IPhiVanChuyenRepository
    {
        private IDatabaseHelper _dbHelper;
        public PhiVanChuyenRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }


        public bool Create(PhiVanChuyenModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_phivanchuyen",
                    "@MaTinhTP", model.MaTinhTP,
                    "@MaQuanHuyen", model.MaQuanHuyen,
                    "@MaXaPhuong", model.MaXaPhuong,
                    "@PhiVanChuyen", model.PhiVanChuyen);
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

        public bool Update(PhiVanChuyenModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_phivanchuyen",
                    "@MaPhiVC", model.MaPhiVC,
                    "@MaTinhTP", model.MaTinhTP,
                    "@MaQuanHuyen", model.MaQuanHuyen,
                    "@MaXaPhuong", model.MaXaPhuong,
                    "@PhiVanChuyen", model.PhiVanChuyen);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_phivanchuyen",
                "@MaPhiVC", id);
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
