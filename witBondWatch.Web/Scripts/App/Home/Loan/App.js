var app = angular.module('loanApp', []);

var loanCtrl = app.controller('loanCtrl', function ($scope, $http,$interval) {
  $scope.InputLoan = 2569000;
  $scope.bondName = "2,5%-2047 (u. afdrag):";
  $scope.bond = {};
  $scope.loanCorrected = $scope.InputLoan;
  $scope.updateScreen = function () {


    //console.log("click");
    $http({ method: "GET", url: "/Home/getTheBond", params: { bondName: $scope.bondName } }).
      success(function (data) {
        $scope.bond = data;
        $scope.loanCorrected = ($scope.InputLoan * ($scope.bond.Value / 100));
        $scope.updateTime = Date();

        //console.dir(data);
      }).
      error(function (data) {
        console.log("Error");
      });
  };
  $interval(function () {
    $scope.updateScreen();
  }, 50000);
  $scope.updateScreen();

});