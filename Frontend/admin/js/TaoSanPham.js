function TaoDoiTuongSanPham(hinhAnh, ten, giaGoc, phanTramGiamGia, KhuVuc, id) {
    var sanPham = new Object();
    sanPham.hinhAnh = hinhAnh;
    sanPham.ten = ten;
    sanPham.giaGoc = giaGoc;
    sanPham.phanTramGiamGia = phanTramGiamGia;
    sanPham.KhuVuc - KhuVuc;

    if (id != null) {
        sanPham.id = id
    } else {
        sanPham.id = taoID;
    }

    sanPham.tinhGiaBan = function() {
        var giaBan = this.giaGoc * (1 - this.phanTramGiamGia);
        return giaBan;
    }

    sanPham.toJSON = function() {
        var json = JSON.stringify(this);
        return json;
    }

    // từ Json chuyển thành 1 đối tượng đầy đủ các phưƠng thức
    // input: json
    // output: đối tượng đầy đủ
    sanPham.fromJSON = function(json) {
        var doiTuongDayDu = new Object();

        // Chuyển từ json thành đối tượng
        var doiTuong = JSON.parse(json)

        // chuyển đối tượng thành đối tượng đầy đủ
        var doiTuongDayDu = TaoDoiTuongSanPham(doiTuong.hinhAnh, doiTuong.ten, doiTuong.giaGoc, doiTuong.phanTramGiamGia, doiTuong.khuVuc)

        return doiTuongDayDu;
    }

    return sanPham;
}