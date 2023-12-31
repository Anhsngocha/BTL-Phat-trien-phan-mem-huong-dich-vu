﻿//using DataAccessLayer.Interfaces;
//using Models;

//namespace DataAccessLayer
//{
//    public class HoaDonDatHangRepository : IHoaDonDatHangRepository
//    {
//        private IDatabaseHelper _dbHelper;
//        public HoaDonDatHangRepository(IDatabaseHelper dbHelper)
//        {
//            _dbHelper = dbHelper;
//        }

//        //public ChiTietHDBModel GetChiTietHDByID(string id)
//        //{
//        //    string msgError = "";
//        //    try
//        //    {
//        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_get_HDB_byid",
//        //             "@MaSanPham", id);
//        //        if (!string.IsNullOrEmpty(msgError))
//        //            throw new Exception(msgError);
//        //        return dt.ConvertTo<HoaDonDatHangModel>().FirstOrDefault();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}


//        public bool Create(SanPhamModel model)
//        {
//            string msgError = "";
//            try
//            {
//                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_them_sanpham",
//                    "@TenSanPham", model.TenSanPham,
//                    "@Size", model.Size,
//                    "@GiaTien", model.GiaTien,
//                    "@GiamGia", model.GiamGia,
//                    "@LinkAnh", model.LinkAnh,
//                    "@MoTa", model.MoTa,
//                    "@SoLuong", model.SoLuong,
//                    "@DaBan", model.DaBan,
//                    "@MaDanhMuc", model.MaDanhMuc,
//                    "@MaThuongHieu", model.MaThuongHieu);
//                if ((result != null && string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
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
//        public bool Update(SanPhamModel model)
//        {
//            string msgError = "";
//            try
//            {
//                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_sanpham",
//                    "@MaSanPham", model.MaSanPham,
//                    "@TenSanPham", model.TenSanPham,
//                    "@Size", model.Size,
//                    "@GiaTien", model.GiaTien,
//                    "@GiamGia", model.GiamGia,
//                    "@LinkAnh", model.LinkAnh,
//                    "@MoTa", model.MoTa,
//                    "@SoLuong", model.SoLuong,
//                    "@DaBan", model.DaBan,
//                    "@MaDanhMuc", model.MaDanhMuc,
//                    "@MaThuongHieu", model.MaThuongHieu);
//                if ((result != null && string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
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

//        public bool Delete(string id)
//        {
//            string msgError = "";
//            try
//            {
//                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_sanpham",
//                "@MaSanPham", id);
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

//        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string ten_sanpham, int gia_tien)
//        {
//            string msgError = "";
//            total = 0;
//            try
//            {
//                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_search_sanpham",
//                    "@page_index", pageIndex,
//                    "@page_size", pageSize,
//                    "@ten_sanpham", ten_sanpham,
//                    "@gia_tien", gia_tien);
//                if (!string.IsNullOrEmpty(msgError))
//                    throw new Exception(msgError);
//                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
//                return dt.ConvertTo<SanPhamModel>().ToList();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}
