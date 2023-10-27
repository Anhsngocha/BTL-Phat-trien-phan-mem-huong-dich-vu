var app = angular.module('SanphamApp',[])
app.controller("SanphamCtrl", function ($scope, $http) {
	$scope.listSanPham
    $scope.listDanhMuc
    $scope.listThuongHieu

    var tenSP = document.querySelector('#enter-tensp');
    var motaSP = document.querySelector('#enter-des');
    var imgSP = document.querySelector('#enter-img');
    var soLuongSP = document.querySelector('#enter-quantity');
    var giaSP = document.querySelector('#enter-price');

    $scope.GetDanhMuc = function() {
        $http({
            method: 'GET',
            // headers: { "Authorization": 'Bearer ' + _user.token },
            data: {
                page: $scope.page,
                pageSize: $scope.pageSize
            },
            url: current_url + '/api/DanhMuc/get-all',
        }).then(function (response) {  
            $scope.listDanhMuc = response.data
            console.log(response);
        }).catch(function (error) {
            console.error('Lỗi :', error);
        });
    }

    $scope.GetDanhMuc();

    $scope.GetThuongHieu = function() {
        $http({
            method: 'GET',
            // headers: { "Authorization": 'Bearer ' + _user.token },
            data: {
                page: $scope.page,
                pageSize: $scope.pageSize
            },
            url: current_url + '/api/ThuongHieu/get-all',
        }).then(function (response) {  
            $scope.listThuongHieu = response.data
            console.log(response);
        }).catch(function (error) {
            console.error('Lỗi :', error);
        });
    }
    $scope.GetThuongHieu();

	$scope.GetAllSanPham= function () {
        $http({
            method: 'GET',
            // headers: { "Authorization": 'Bearer ' + _user.token },
            data: {
                page: $scope.page,
                pageSize: $scope.pageSize
            },
            url: current_url + '/api/SanPham/get-all-sp',
        }).then(function (response) {  
            $scope.listSanPham = response.data
            console.log(response);
        }).catch(function (error) {
            console.error('Lỗi :', error);
        });
    };   
	$scope.GetAllSanPham()

    $scope.AddProduct = function() {
        $scope.tenSP = ''
        $scope.motaSP = ''
        $scope.soLuongSP = ''
        $scope.giaSP = ''
        $scope.maDanhMuc = ''
        $scope.maThuongHieu = ''

        $http({
            method: 'POST',
            data: {
                TenSanPham: $scope.tenSP,
                MoTa: $scope.motaSP,
                SoLuong: $scope.soLuongSP,
                GiaTien: $scope.giaSP,
                MaDanhMuc: $scope.maDanhMuc,
                MaThuongHieu: $scope.maThuongHieu
            },
            url: current_url + '/api/SanPham/create-sanpham',
            // headers: {'Content-Type': 'application/json',"Authorization": 'Bearer ' + _user.token }
        }).then(function (response) {
            alert('Thêm thành công');
        })
        .catch(function (error) {
            console.error('Lỗi khi thêm sản phẩm:', error);
        });
    }

})