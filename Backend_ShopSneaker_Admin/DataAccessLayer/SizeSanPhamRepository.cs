using DataAccessLayer.Interfaces;
using Models;

namespace DataAccessLayer
{
    public class SizeSanPhamRepository : ISizeSanPhamRepository
    {
        private IDatabaseHelper _dbHelper;
        public SizeSanPhamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

   

        public bool Create(SizeSanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_them_size",
                    );
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
        public bool Update(DanhGiaModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_danhgia",
                    "@MaDanhGia", model.MaDanhGia,
                    "@Ho", model.Ho,
                    "@Ten", model.Ten,
                    "@Email", model.Email,
                    "@SDT", model.SDT,
                    "@TieuDe", model.TieuDe,
                    "@NoiDungDanhGia", model.NoiDungDanhGia);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_danhgia",
                "@MaDanhGia", id);
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

        public List<DanhGiaModel> Search(int pageIndex, int pageSize, out long total, string tieu_de)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_danhgia",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@TieuDe", tieu_de);
                    
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DanhGiaModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
