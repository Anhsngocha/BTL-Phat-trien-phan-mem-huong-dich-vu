var app = angular.module('ThuonghieuApp',[])
app.controller("ThuonghieuCtrl", function ($scope, $http) {
	$scope.listDistributor
	$scope.GetDistributor= function () {
        $http({
            method: 'GET',
            // headers: { "Authorization": 'Bearer ' + _user.token },
            data: {
                page: $scope.page,
                pageSize: $scope.pageSize
            },
            url: current_url + '/api/ThuongHieu/get-all',
        }).then(function (response) {  
            $scope.listDistributor = response.data
            console.log(response);
        }).catch(function (error) {
            console.error('Lỗi :', error);
        });

		// $http({
        //     method: 'POST',
        //     // headers: { "Authorization": 'Bearer ' + _user.token },
        //     data: {
        //         page: $scope.page,
        //         pageSize: $scope.pageSize
        //     },
        //     url: current_url + '/api/Product/create-all',
        // }).then(function (response) {  
        //     $scope.listDistributor = response.data
        //     console.log(response);
        // }).catch(function (error) {
        //     console.error('Lỗi :', error);
        // });
    };   
	$scope.GetDistributor()


})