var app = angular.module('SanPhamApp',[])
app.controller("SanPhamCtrl", function ($scope, $http, $window) {
	$scope.listSanPham
	$scope.GetDistributor= function () {
        $http({
            method: 'GET',
            // headers: { "Authorization": 'Bearer ' + _user.token },
            data: {
                page: $scope.page,
                pageSize: $scope.pageSize
            },
            url: current_url + '/api/SanPham/get-sanpham-new',
        }).then(function (response) {  
            $scope.listSanPham = response.data
            console.log(response);
        }).catch(function (error) {
            console.error('Lỗi :', error);
        });

    };   
	$scope.GetDistributor()

    $scope.productDetail =function(x){
        // var idProduct = localStorage.getItem('idProduct') ? JSON.parse(localStorage.getItem('idProduct')): null
        // idProduct=x.maSanPham
        localStorage.setItem("idProduct", x.maSanPham)
    }

})