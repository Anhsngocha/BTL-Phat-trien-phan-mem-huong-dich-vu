using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer
{
    public class ThuVienRepository : IThuVienRepository
    {
        private IDatabaseHelper _dbHelper;
        public ThuVienRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

       

        public List<ThuVienModel> GetAllThuVien()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_all_thuvien");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThuVienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(ThuVienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_create_thuvien",
                    "@MaSanPham", model.MaSanPham,
                    "@LinkAnhThuVien", model.LinkAnhThuVien);
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
        public bool Update(ThuVienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_update_thuvien",
                    "@MaThuVien", model.MaThuVien,
                    "@MaSanPham", model.MaSanPham,
                    "@LinkAnhThuVien", model.LinkAnhThuVien);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_delete_thuvien",
                "@MaThuVien", id);
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

        public List<ThuVienModel> Search(int pageIndex, int pageSize, out long total, int Ma_SanPham)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_thuvien",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ma_sanpham", Ma_SanPham);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ThuVienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
