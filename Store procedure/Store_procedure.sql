--Bảng sản phẩm
--lấy ra sản phẩm từ id
create proc sp_get_sanpham_byid
(
	@MaSanPham int
)
as
begin
	select s.MaSanPham, TenSanPham, AnhDaiDien, GiaTien, GiamGia, DaBan, TenThuongHieu, MoTa from SanPham s
	inner join ChiTietSanPham c on s.MaSanPham = c.MaSanPham
	inner join ThuongHieu t on s.MaThuongHieu = t.MaThuongHieu
	where s.MaSanPham = @MaSanPham
end
go

--lấy ra các sản phẩm mới
create proc sp_get_new_sanpham
as
begin
	select top 8 * from SanPham
	order by NgayTao desc
end
go

--lấy toàn bộ sản phẩm theo phân trang
create proc sp_get_sanpham_pagination
(
	@page_size int,
	@page_index int
)
as
begin
	DECLARE @RecordCount bigint;
	if (@page_size <> 0)
	BEGIN
		set NOCOUNT ON;
			select(ROW_NUMBER() OVER(order by MaSanPham asc)) as RowNumber,
			s.MaSanPham, TenSanPham, AnhDaiDien, GiaTien, GiamGia, DaBan, TenThuongHieu
			into #Results1
			from SanPham as s inner join ThuongHieu as t on s.MaThuongHieu = t.MaThuongHieu
			select @RecordCount = COUNT(*)
			from #Results1;
			SELECT *, @RecordCount as RecordCount
			from #Results1
			WHERE ROWNUMBER BETWEEN(@page_index - 1) * @page_size + 1 and (((@page_index - 1) * @page_size + 1) + @page_size) - 1
				or @page_index = -1;
			drop TABLE #Results1;
	END
	ELSE
	BEGIN
		
		set NOCOUNT ON;
			select(ROW_NUMBER() OVER(order by MaSanPham asc)) as RowNumber,
			s.MaSanPham, TenSanPham, AnhDaiDien, GiaTien, GiamGia, DaBan, TenThuongHieu
			into #Results2
			from SanPham as s inner join ThuongHieu as t on s.MaThuongHieu = t.MaThuongHieu
			select @RecordCount = COUNT(*)
			from #Results2;
			SELECT *, @RecordCount as RecordCount
			from #Results2
			drop TABLE #Results2;
	END
end
go

--thêm sản phẩm
create proc sp_them_sanpham
(
	@TenSanPham nvarchar(500),
	@AnhDaiDien varchar(500),
	@GiaTien decimal(18, 0),
	@GiamGia decimal(18, 0),
	@DaBan int,
	@MaThuongHieu int,
	@list_json_chitietsp nvarchar(MAX)
)
as
begin
	declare @MaSanPham int;
	insert into SanPham
	(
		TenSanPham,
		AnhDaiDien,
		GiaTien,
		GiamGia,
		DaBan,
		MaThuongHieu
	)
	values
	(
		@TenSanPham,
		@AnhDaiDien,
		@GiaTien,
		@GiamGia,
		@DaBan,
		@MaThuongHieu
	)
	set @MaSanPham = (select SCOPE_IDENTITY())
	if(@list_json_chitietsp is not null)
	begin
		insert into ChiTietSanPham
		(
			MaSanPham,
			MoTa
		)
		select @MaSanPham,
				JSON_VALUE(l.value, '$.maSanPham')
		from openjson(@list_json_chitietsp) as l
	end
	select '';
end
go

--sửa sản phẩm
create proc sp_sua_sanpham
(
	@MaSanPham int,
	@TenSanPham nvarchar(500),
	@GiaTien decimal(18, 0),
	@GiamGia decimal(18, 0), 
	@LinkAnh varchar(500),
	@DaBan int,
	@MaThuongHieu int,
	@list_json_chitietsp nvarchar(MAX)
)

AS
BEGIN 
	update SanPham
	set
		TenSanPham = CASE WHEN @TenSanPham IS NOT NULL AND @TenSanPham <> 'null' AND @TenSanPham <> 'string' THEN @TenSanPham ELSE TenSanPham END,
		GiaTien = CASE WHEN @GiaTien IS NOT NULL AND @GiaTien <> 'null' AND @GiaTien <> 'string' THEN @GiaTien ELSE GiaTien END,
		GiamGia = CASE WHEN @GiamGia IS NOT NULL AND @GiamGia <> 'null' AND @GiamGia <> 'string' THEN @GiamGia ELSE GiamGia END,
		DaBan = CASE WHEN @DaBan IS NOT NULL AND @DaBan <> 'null' AND @DaBan <> 'string' THEN @DaBan ELSE DaBan END,
		MaThuongHieu = CASE WHEN @MaThuongHieu IS NOT NULL AND @MaThuongHieu <> 'null' AND @MaThuongHieu <> 'string' THEN @MaThuongHieu ELSE MaThuongHieu END,
		NgayCapNhat = cast(GETDATE() as date)
	where MaSanPham = @MaSanPham
	if(@list_json_chitietsp is not null)
	begin
		select
			JSON_VALUE(l.value, '$.maChiTietSP') as	maChiTietSP,
			JSON_VALUE(l.value, '$.maSanPham') as maSanPham,
			JSON_VALUE(l.value, '$.moTa') as moTa,
			JSON_VALUE(l.value, '$.status') as status
		into #Results
		from openjson(@list_json_chitietsp) as l
		
		--insert nếu status = 1
		insert into ChiTietSanPham
		(
			MaSanPham,
			MoTa
		)
		select
			@MaSanPham,
			#Results.moTa
		from #Results
		where #Results.status = '1'

		--update nếu status = 2
		update ChiTietSanPham
		set
			MoTa = #Results.moTa
		from #Results
		where ChiTietSanPham.MoTa = #Results.moTa and #Results.status = '2'

		--delete nếu status = 3
		delete c
		from ChiTietSanPham c
		inner join #Results r on c.MaChiTietSP = r.maChiTietSP
		where r.status = '3'
		drop table #Results
	end
	select '';
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
create PROCEDURE [dbo].[sp_search_sanpham_by_tensp] (@page_index  INT, 
                                       @page_size   INT,
									   @ten_sanpham nvarchar(500))
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
							  sp.AnhDaiDien,
							  sp.GiaTien,
							  sp.GiamGia,
							  sp.DaBan,
							  TenThuongHieu
                        INTO #Results1
                        FROM [SanPham] AS sp inner join ThuongHieu as t on sp.MaThuongHieu = t.MaThuongHieu
					    WHERE (@ten_sanpham = '' or sp.TenSanPham like N'%' + @ten_sanpham +'%');                   
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
							  sp.AnhDaiDien,
							  sp.GiaTien,
							  sp.GiamGia,
							  sp.DaBan,
							  TenThuongHieu
                        INTO #Results2
                        FROM [SanPham] AS sp inner join ThuongHieu as t on sp.MaThuongHieu = t.MaThuongHieu
					    WHERE (@ten_sanpham = '' or sp.TenSanPham like N'%' + @ten_sanpham +'%');                   
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
