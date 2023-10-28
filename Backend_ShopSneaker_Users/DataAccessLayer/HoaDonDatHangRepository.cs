//using DataAccessLayer.Interfaces;
//using Models;

//namespace DataAccessLayer
//{
//    public class HoaDonNhapRepository : IHoaDonNhapRepository
//    {
//        private IDatabaseHelper _dbHelper;
//        public HoaDonNhapRepository(IDatabaseHelper dbHelper)
//        {
//            _dbHelper = dbHelper;
//        }

//        public bool Create(HoaDonDatHangModel model)
//        {
//            string msgError = "";
//            try
//            {
//                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadondathang_create",
//                "@MaDanhMuc", model.MaDanhMuc,
//                "@TongTien", model.TongTien,
//                "@list_json_chitietHDDH", model.list_json_chitietHDDH != null ? MessageConvert.SerializeObject(model.list_json_chitietHDDH) : null);
//                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
//                {
//                    throw new Exception(Convert.ToString(result) + msgError);
//                }
//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        //public bool Update(HoaDonNhapModel model)
//        //{
//        //    string msgError = "";
//        //    try
//        //    {
//        //        var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoa_don_update",
//        //        "@MaHoaDonNhap", model.MaHoaDonNhap,
//        //        "@MaDanhMuc", model.MaDanhMuc,
//        //        "@NgayNhap", model.NgayNhap,
//        //        "@TongTien", model.TongTien,
//        //        "@list_json_chitietHDN", model.list_json_chitietHDN != null ? MessageConvert.SerializeObject(model.list_json_chitietHDN) : null);
//        //        if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
//        //        {
//        //            throw new Exception(Convert.ToString(result) + msgError);
//        //        }
//        //        return true;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}

//    }
//}
