--Bảng sản phẩm
--lấy ra sản phẩm từ id
create proc sp_get_sanpham_byid
(
	@MaSanPham int
)
as
begin
	select * from SanPham
	where MaSanPham = @MaSanPham
end
go

--lấy toàn bộ sản phẩm
create proc sp_get_all_sanpham
as
begin
	select sp.MaSanPham, sp.TenSanPham, sp.GiaTien, sp.LinkAnh, sp.MoTa, sp.SoLuong, sp.DaBan, dm.TenDanhMuc, th.TenThuongHieu, NgayTao, NgayCapNhat
	from SanPham sp
	inner join ThuongHieu th on sp.MaThuongHieu = th.MaThuongHieu
	inner join DanhMuc dm on sp.MaDanhMuc = dm.MaDanhMuc
end
go


--lấy sản phẩm theo danh mục
create proc sp_get_sanpham_by_danhmuc
(
	@TenDanhMuc nvarchar(350)
)
as
begin
	SELECT dm.*, 
        (
            SELECT sp.*
            FROM SanPham AS sp
            WHERE dm.MaDanhMuc = sp.MaDanhMuc FOR JSON PATH
        ) AS list_json_sanpham_by_danhmuc
        FROM DanhMuc AS dm
        WHERE  dm.TenDanhMuc = @TenDanhMuc;
end
go

--lấy sản phẩm theo thương hiệu
create proc sp_get_sanpham_by_thuonghieu
(
	@TenThuongHieu nvarchar(100)
)
as
begin
	SELECT th.*, 
        (
            SELECT sp.*
            FROM SanPham AS sp
            WHERE th.MaThuongHieu = sp.MaThuongHieu FOR JSON PATH
        ) AS list_json_sanpham_by_thuonghieu
        FROM ThuongHieu AS th
        WHERE  th.TenThuongHieu = @TenThuongHieu;
end
go

--thêm sản phẩm
create proc sp_them_sanpham
(
	@TenSanPham int,
	@Size int,
	@GiaTien int,
	@GiamGia int,
	@LinkAnh varchar(500),
	@MoTa nvarchar(500),
	@SoLuong int,
	@DaBan int,
	@MaDanhMuc int,
	@MaThuongHieu int
)
as
begin
	insert into SanPham(TenSanPham, GiaTien, GiamGia, LinkAnh, MoTa, SoLuong, DaBan, MaDanhMuc, MaThuongHieu)
	values(@TenSanPham, @GiaTien, @GiamGia, @LinkAnh, @MoTa, @SoLuong, @DaBan, @MaDanhMuc, @MaThuongHieu)
end
go

--sửa sản phẩm
create proc sp_sua_sanpham
(
	@MaSanPham int,
	@TenSanPham nvarchar(250),
	@Size int,
	@GiaTien int,
	@GiamGia int, 
	@LinkAnh varchar(500),
	@MoTa nvarchar(500),
	@SoLuong int,
	@DaBan int,
	@MaDanhMuc int,
	@MaThuongHieu int,
	@NgayTao datetime
)

AS
BEGIN 
	update SanPham
	set
		TenSanPham = CASE WHEN @TenSanPham IS NOT NULL AND @TenSanPham <> 'null' AND @TenSanPham <> 'string' THEN @TenSanPham ELSE TenSanPham END,
		GiaTien = CASE WHEN @GiaTien IS NOT NULL AND @GiaTien <> 'null' AND @GiaTien <> 'string' THEN @GiaTien ELSE GiaTien END,
		GiamGia = CASE WHEN @GiamGia IS NOT NULL AND @GiamGia <> 'null' AND @GiamGia <> 'string' THEN @GiamGia ELSE GiamGia END,
		LinkAnh = CASE WHEN @LinkAnh IS NOT NULL AND @LinkAnh <> 'null' AND @LinkAnh <> 'string' THEN @LinkAnh ELSE LinkAnh END,
		MoTa = CASE WHEN @MoTa IS NOT NULL AND @MoTa <> 'null' AND @MoTa <> 'string' THEN @MoTa ELSE MoTa END,
		SoLuong = CASE WHEN @SoLuong IS NOT NULL AND @SoLuong <> 'null' AND @SoLuong <> 'string' THEN @SoLuong ELSE SoLuong END,
		DaBan = CASE WHEN @DaBan IS NOT NULL AND @DaBan <> 'null' AND @DaBan <> 'string' THEN @DaBan ELSE DaBan END,
		MaDanhMuc = CASE WHEN @MaDanhMuc IS NOT NULL AND @MaDanhMuc <> 'null' AND @MaDanhMuc <> 'string' THEN @MaDanhMuc ELSE MaDanhMuc END,
		MaThuongHieu = CASE WHEN @MaThuongHieu IS NOT NULL AND @MaThuongHieu <> 'null' AND @MaThuongHieu <> 'string' THEN @MaThuongHieu ELSE MaThuongHieu END,
		NgayTao = CASE WHEN @NgayTao IS NOT NULL AND @NgayTao <> 'null' AND @NgayTao <> 'string' THEN @NgayTao ELSE @NgayTao END,
		NgayCapNhat = GETDATE()

	where MaSanPham = @MaSanPham
END
go

--xóa sản phẩm
create proc sp_xoa_sanpham
(
	@MaSanPham int
)
as 
begin
	delete from SanPham where MaSanPham = @MaSanPham
end
go


--tìm kiếm sản phẩm
create PROCEDURE [dbo].[sp_search_sanpham] (@page_index  INT, 
                                       @page_size   INT,
									   @ten_sanpham nvarchar(250),
									   @gia_tien varchar(50))
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY MaSanPham ASC)) AS RowNumber, 
                              sp.MaSanPham,
							  sp.TenSanPham,
							  sp.GiaTien
                        INTO #Results1
                        FROM [SanPham] AS sp
					    WHERE (@ten_sanpham = '' or sp.TenSanPham like N'%' + @ten_sanpham +'%') and
						(@gia_tien is null or sp.GiaTien like N'%' + @gia_tien +'%');                   
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results1;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results1
                        WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 AND(((@page_index - 1) * @page_size + 1) + @page_size) - 1
                              OR @page_index = -1;
                        DROP TABLE #Results1; 
            END;
            ELSE
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY MaSanPham ASC)) AS RowNumber, 
                              sp.MaSanPham,
							  sp.TenSanPham,
							  sp.GiaTien
                        INTO #Results2
                        FROM [SanPham] AS sp
					    WHERE (@ten_sanpham = '' or sp.TenSanPham like N'%' + @ten_sanpham +'%') and
						(@gia_tien is null or sp.GiaTien like N'%' + @gia_tien +'%');                   
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2
                        DROP TABLE #Results2; 
        END;
    END;
go

--bảng khách hàng
--lấy khách hàng theo id
create proc sp_get_khachhang_byid
(
	@MaKhachHang int
)
as
begin
	select * from KhachHang
	where MaKhachHang = @MaKhachHang
end
go

--lấy tất cả khách hàng
create proc sp_get_all_khachhang
as
begin
	select * from KhachHang
end
go

--thêm khách hàng
create proc sp_them_khachhang
(
	@TenKhachHang nvarchar(500),
	@Email varchar(100),
	@DiaChi nvarchar(250),
	@SDT varchar(20)
)
as
begin
	insert into KhachHang(TenKhachHang, Email, DiaChi, SDT)
	values(@TenKhachHang, @Email, @DiaChi, @SDT)
end
go

--sửa khách hàng
create proc sp_sua_khachhang
(
	@MaKhachHang int,
	@TenKhachHang nvarchar(500),
	@Email varchar(100),
	@DiaChi nvarchar(250),
	@SDT varchar(20)
)
as
begin
	update KhachHang
	set
		TenKhachHang = CASE WHEN @TenKhachHang IS NOT NULL AND @TenKhachHang <> 'null' AND @TenKhachHang <> 'string' THEN @TenKhachHang ELSE TenKhachHang END,
		Email = CASE WHEN @Email IS NOT NULL AND @Email <> 'null' AND @Email <> 'string' THEN @Email ELSE Email END,
		DiaChi = CASE WHEN @DiaChi IS NOT NULL AND @DiaChi <> 'null' AND @DiaChi <> 'string' THEN @DiaChi ELSE DiaChi END,
		SDT = CASE WHEN @SDT IS NOT NULL AND @SDT <> 'null' AND @SDT <> 'string' THEN @SDT ELSE SDT END
	where MaKhachHang =@MaKhachHang
end
go

--xóa khách hàng
create proc sp_xoa_khachhang
(
	@MaKhachHang int
)
as
begin
	delete KhachHang
	where MaKhachHang = @MaKhachHang
end
go

--tìm kiếm khách hàng
create PROCEDURE sp_search_khachhang(@page_index  INT, 
                                       @page_size   INT,
									   @TenKhachHang nvarchar(500),
									   @DiaChi nvarchar(255))
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY MaKhachHang ASC)) AS RowNumber, 
                              kh.MaKhachHang,
							  kh.TenKhachHang,
							  kh.Email,
							  kh.DiaChi
                        INTO #Results1
                        FROM [KhachHang] AS kh
					    WHERE (@TenKhachHang = '' or kh.TenKhachHang like N'%' + @TenKhachHang +'%') and
						(@DiaChi = '' or kh.DiaChi like N'%' + @DiaChi +'%');                   
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results1;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results1
                        WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 AND(((@page_index - 1) * @page_size + 1) + @page_size) - 1
                              OR @page_index = -1;
                        DROP TABLE #Results1; 
            END;
            ELSE
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY MaKhachHang ASC)) AS RowNumber, 
                              kh.MaKhachHang,
							  kh.TenKhachHang,
							  kh.Email,
							  kh.DiaChi
                        INTO #Results2
                        FROM [KhachHang] AS kh
					     WHERE (@TenKhachHang = '' or kh.TenKhachHang like N'%' + @TenKhachHang +'%') and
						(@DiaChi = '' or kh.DiaChi like N'%' + @DiaChi +'%');                  
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2
                        DROP TABLE #Results2; 
        END;
    END;
go

--Bảng hóa đơn nhập
--thêm hóa đơn nhập
create PROCEDURE [dbo].[sp_hoadonnhap_create]
(@MaDanhMuc             int, 
 @TongTien          int, 
 @list_json_chitietHDN NVARCHAR(MAX)
)
AS
    BEGIN
		DECLARE @MaHoaDonNhap INT;
        INSERT INTO HoaDonNhap
                (MaDanhMuc, 
                 TongTien               
                )
                VALUES
                (@MaDanhMuc, 
                 @TongTien);

				SET @MaHoaDonNhap = (SELECT SCOPE_IDENTITY());
				DECLARE @TongTienHoaDon DECIMAL(18, 2);
				SET @TongTienHoaDon = 0;
                IF(@list_json_chitietHDN IS NOT NULL)
                    BEGIN
                        INSERT INTO ChiTietHDN
						 (MaThuongHieu, 
						  MaHoaDonNhap,
                          MaSanPham, 
                          SoLuong,
						  GiaNhap,
						  TongTien
                        )
                    SELECT JSON_VALUE(p.value, '$.maThuongHieu'), 
                            @MaHoaDonNhap, 
                            JSON_VALUE(p.value, '$.maSanPham'), 
                            JSON_VALUE(p.value, '$.soLuong'),
                            JSON_VALUE(p.value, '$.giaNhap'),
							CAST(JSON_VALUE(p.value, '$.giaNhap') AS INT) * CAST(JSON_VALUE(p.value, '$.soLuong') AS INT)
                    FROM OPENJSON(@list_json_chitietHDN) AS p;

					SELECT @TongTienHoaDon = SUM(TongTien)
					FROM ChiTietHDN
					WHERE MaHoaDonNhap = @MaHoaDonNhap;

					-- Cập nhật tổng tiền vào hóa đơn nhập
					UPDATE HoaDonNhap
					SET TongTien = @TongTienHoaDon
					WHERE MaHoaDonNhap = @MaHoaDonNhap;
                END;
        SELECT '';
    END;
go

--Bảng danh mục
--lấy danh mục theo id
create proc sp_get_danhmuc_by_id
(
	@MaDanhMuc int
)
as
begin
	select * from DanhMuc
	where MaDanhMuc = @MaDanhMuc
end
go

--lấy toàn bộ danh mục
create proc sp_get_all_danhmuc
as
begin
	select * from DanhMuc
end
go

--thêm danh mục
create proc sp_create_danhmuc
(
	@TenDanhMuc nvarchar(350)
)
as
begin
	insert into DanhMuc(TenDanhMuc)
	values(@TenDanhMuc)
end
go

--sửa danh mục
create proc sp_update_danhmuc
(
	@MaDanhMuc int,
	@TenDanhMuc nvarchar(350)
)
as
begin
	if @TenDanhMuc is not null and @TenDanhMuc <> 'string'
	begin
		update DanhMuc
	set
		TenDanhMuc = CASE WHEN @TenDanhMuc IS NOT NULL AND @TenDanhMuc <> 'null' AND @TenDanhMuc <> 'string' THEN @TenDanhMuc ELSE TenDanhMuc END
		where MaDanhMuc = @MaDanhMuc
	end
end
go

--xóa danh mục
create proc sp_delete_danhmuc
(
	@MaDanhMuc int
)
as
begin
	delete DanhMuc
	where MaDanhMuc = @MaDanhMuc
end
go

--tìm kiếm danh mục
create PROCEDURE sp_search_danhmuc (@page_index  INT, 
                                    @page_size   INT,
									@ten_danhmuc nvarchar(350))
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY MaDanhMuc ASC)) AS RowNumber, 
                              dm.MaDanhMuc,
							  dm.TenDanhMuc
                        INTO #Results1
                        FROM [DanhMuc] AS dm
					    WHERE (@ten_danhmuc = '' or dm.TenDanhMuc like N'%' + @ten_danhmuc +'%');                   
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results1;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results1
                        WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 AND(((@page_index - 1) * @page_size + 1) + @page_size) - 1
                              OR @page_index = -1;
                        DROP TABLE #Results1; 
            END;
            ELSE
            BEGIN
                SET NOCOUNT ON;
                         SELECT(ROW_NUMBER() OVER(
                              ORDER BY MaDanhMuc ASC)) AS RowNumber, 
                              dm.MaDanhMuc,
							  dm.TenDanhMuc
                        INTO #Results2
                        FROM [DanhMuc] AS dm
					    WHERE (@ten_danhmuc = '' or dm.TenDanhMuc like N'%' + @ten_danhmuc +'%');                   
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2
                        DROP TABLE #Results2; 
        END;
    END;
go

--Bảng thương hiệu
--Thêm thương hiệu
create proc sp_getall_thuonghieu
as
begin
	select * from ThuongHieu
end
go

create proc [dbo].[sp_create_thuonghieu]
(
	@TenThuongHieu nvarchar(350)
)
as
begin
	insert into ThuongHieu(TenThuongHieu)
	values(@TenThuongHieu)
end
go

--Sửa thương hiệu
create proc [dbo].[sp_update_thuonghieu]
(
	@MaThuongHieu int,
	@TenThuongHieu nvarchar(350)
)
as
begin
	if @TenThuongHieu is not null and @TenThuongHieu <> 'string'
	begin
		update ThuongHieu
	set
		@TenThuongHieu = CASE WHEN @TenThuongHieu IS NOT NULL AND @TenThuongHieu <> 'null' AND @TenThuongHieu <> 'string' THEN @TenThuongHieu ELSE TenThuongHieu END
		
	where MaThuongHieu = @MaThuongHieu
	end
end
go

--Xóa thương hiệu
create proc [dbo].[sp_delete_thuonghieu]
(
	@MaThuongHieu int
)
as
begin
	delete ThuongHieu
	where MaThuongHieu = @MaThuongHieu
end
go

--Bảng đánh giá
--Thêm đánh giá
create proc [dbo].[sp_them_danhgia]
(
	@Ho nvarchar(50),
	@Ten varchar(50),
	@Email varchar(150),
	@SDT varchar(20),
	@TieuDe nvarchar(100),
	@NoiDungDanhGia nvarchar(500)
)
as
begin
	insert into DanhGia(Ho,Ten, Email, SDT, TieuDe,NoiDungDanhGia)
	values(@Ho,@Ten, @Email, @SDT, @TieuDe,@NoiDungDanhGia)
end
go


--Sửa đánh giá
create proc [dbo].[sp_sua_danhgia]
(
	@MaDanhGia int,
	@Ho nvarchar(50),
	@Ten varchar(50),
	@Email varchar(150),
	@SDT varchar(20),
	@TieuDe nvarchar(100),
	@NoiDungDanhGia nvarchar(500)
)
as
begin
	update DanhGia
	set
		Ho = CASE WHEN @Ho IS NOT NULL AND @Ho <> 'null' AND @Ho <> 'string' THEN @Ho ELSE Ho END,
		Ten = CASE WHEN @Ten IS NOT NULL AND @Ten <> 'null' AND @Ten <> 'string' THEN @Ten ELSE Ten END,
		Email = CASE WHEN @Email IS NOT NULL AND @Email <> 'null' AND @Email <> 'string' THEN @Email ELSE Email END,
		SDT = CASE WHEN @SDT IS NOT NULL AND @SDT <> 'null' AND @SDT <> 'string' AND @SDT NOT LIKE '%[^0-9]%' THEN @SDT ELSE SDT END,
		TieuDe = CASE WHEN @TieuDe IS NOT NULL AND @TieuDe <> 'null' AND @TieuDe <> 'string' THEN @TieuDe ELSE TieuDe END,
		NoiDungDanhGia = CASE WHEN @NoiDungDanhGia IS NOT NULL AND @NoiDungDanhGia <> 'null' AND @NoiDungDanhGia <> 'string' THEN @NoiDungDanhGia ELSE NoiDungDanhGia END
	where MaDanhGia = @MaDanhGia
end
go

--Xóa đánh giá
create proc [dbo].[sp_xoa_danhgia]
(
	@MaDanhGia int
)
as
begin
	delete DanhGia
	where MaDanhGia = @MaDanhGia
end
go

--Tìm kiếm đánh giá
create PROCEDURE [dbo].[sp_search_danhgia] (@page_index  INT, 
                                       @page_size   INT,
									   @tieude nvarchar(100))
AS
    BEGIN
        DECLARE @RecordCount BIGINT;
        IF(@page_size <> 0)
            BEGIN
                SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY MaDanhGia ASC)) AS RowNumber, 
							  dg.*
                        INTO #Results1
                        FROM [DanhGia] AS dg
					    WHERE (@tieude = '' or dg.TieuDe like N'%' + @tieude +'%')              
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results1;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results1
                        WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 AND(((@page_index - 1) * @page_size + 1) + @page_size) - 1
                              OR @page_index = -1;
                        DROP TABLE #Results1; 
            END;
            ELSE
            BEGIN
                 SET NOCOUNT ON;
                        SELECT(ROW_NUMBER() OVER(
                              ORDER BY MaDanhGia ASC)) AS RowNumber, 
							  dg.Ho,
							  dg.Ten,
							  dg.NoiDungDanhGia
                        INTO #Results2
                        FROM [DanhGia] AS dg
					    WHERE (@tieude = '' or dg.TieuDe like N'%' + @tieude +'%')              
                        SELECT @RecordCount = COUNT(*)
                        FROM #Results2;
                        SELECT *, 
                               @RecordCount AS RecordCount
                        FROM #Results2
        
                        DROP TABLE #Results2; 
			end
    END;

go

--Bảng giảm giá
--Lấy về tất cả mã giảm giá
create proc [dbo].[sp_get_all_magiamgia]
as
begin
	select * from GiamGia
end
go


--Thêm mã giảm giá
create proc [dbo].[sp_them_magiamgia]
(
	@TenMaGG nvarchar(250),
	@BatDau datetime,
	@KetThuc datetime,
	@SoLuongMa int,
	@SoTienGiam int,
	@MaCode nvarchar(200),
	@TrangThai bit
)
as
begin
	insert into GiamGia(TenMaGG, BatDau, KetThuc, SoLuongMa, SoTienGiam, MaCode, TrangThai)
	values(@TenMaGG, @BatDau, @KetThuc, @SoLuongMa, @SoTienGiam, @MaCode, @TrangThai)
end
go


--Sửa mã giảm giá
create proc [dbo].[sp_sua_magiamgia]
(
	@MaGiamGia int,
	@TenMaGG nvarchar(250),
	@BatDau datetime,
	@KetThuc datetime,
	@SoLuongMa int,
	@SoTienGiam int,
	@MaCode nvarchar(200),
	@TrangThai bit
)
as
begin
	update GiamGia
	set
		TenMaGG = CASE WHEN @TenMaGG IS NOT NULL AND @TenMaGG <> 'null' AND @TenMaGG <> 'string' THEN @TenMaGG ELSE TenMaGG END,
		BatDau = CASE WHEN @BatDau IS NOT NULL AND @BatDau <> 'null' AND @BatDau <> 'string' THEN @BatDau ELSE BatDau END,
		KetThuc = CASE WHEN @KetThuc IS NOT NULL AND @KetThuc <> 'null' AND @KetThuc <> 'string' THEN @KetThuc ELSE KetThuc END,
		SoLuongMa = CASE WHEN @SoLuongMa IS NOT NULL AND @SoLuongMa <> 'null' AND @SoLuongMa <> 'string' THEN @SoLuongMa ELSE SoLuongMa END,
		SoTienGiam = CASE WHEN @SoTienGiam IS NOT NULL AND @SoTienGiam <> 'null' AND @SoTienGiam <> 'string' THEN @SoTienGiam ELSE SoTienGiam END,
		MaCode = CASE WHEN @MaCode IS NOT NULL AND @MaCode <> 'null' AND @MaCode <> 'string' THEN @MaCode ELSE MaCode END,
		TrangThai = CASE WHEN @TrangThai IS NOT NULL AND @TrangThai <> 'null' AND @TrangThai <> 'string' THEN @TrangThai ELSE TrangThai END
	where MaGiamGia =@MaGiamGia
end
go

--Xóa mã giám giá
create proc [dbo].[sp_xoa_magiamgia]
(
	@MaGiamGia int
)
as
begin
	delete GiamGia
	where MaGiamGia = @MaGiamGia
end
go


--bảng quản trị viên
--đăng nhập
create proc sp_login
(
	@TenTaiKhoan nvarchar(500),
	@MatKhau varchar(50)
)
as
begin
	select * from QuanTriVien
	where TenTaiKhoan = @TenTaiKhoan and MatKhau = @MatKhau
end
go

--lấy tài khoản theo id
create proc sp_get_taiKhoan_byID
(
	@MaQTV int
)
as
begin
	select * from QuanTriVien
	where MaQTV = @MaQTV
end
go


--lấy theo tên tài khoản
create proc sp_get_by_name
(
	@TenTaiKhoan nvarchar(500)
)
as
begin
	select * from QuanTriVien
	where TenTaiKhoan = @TenTaiKhoan
end
go

--thêm quản trị viên
create proc sp_create_admin
(
	@TenTaiKhoan nvarchar(500),
	@Ho nvarchar(50),
	@Ten nvarchar(50),
	@SDT varchar(20),
	@Email varchar(150),
	@MatKhau varchar(50)
)
as
begin
	insert into QuanTriVien
	values(@TenTaiKhoan, @Ho, @Ten, @SDT, @Email, @MatKhau)
end
go
