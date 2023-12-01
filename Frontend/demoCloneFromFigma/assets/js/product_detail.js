var app = angular.module('ChiTietSanPhamApp',[])
app.controller("ChiTietSanPhamCtrl", function ($scope, $http, $window) {
    var maSanPham = localStorage.getItem('idProduct');
	// $scope.listChiTietSanPham
	$scope.chiTietSanPham;
    console.log(maSanPham)
	$scope.GetChiTietSanPham = function () {
        $http({
            method: 'GET',
            // headers: { "Authorization": 'Bearer ' + _user.token },

            url: current_url + '/api/SanPham/get-by-id/'+ $scope.maSanPham,
        }).then(function (response) {  
            $scope.chiTietSanPham  = response.data
            console.log(response);
        }).catch(function (error) {
            console.error('Lỗi :', error);
        });

    };   
	// $scope.GetChiTietSanPham();

})