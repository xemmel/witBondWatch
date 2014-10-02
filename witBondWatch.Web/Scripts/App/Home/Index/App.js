var app = angular.module('loanApp', []);
app.controller('loanCtrl', function ($scope, $http, $interval) {
  $scope.x = "Clara";
  $scope.bonds = [];
  $scope.updateTime = null;
  $scope.loaded = false;
  $scope.updateScreen = function () {
    $scope.loaded = false;
    $http({ method: "GET", url: "/Home/getTheBonds" }).
      success(function (data) {
        console.dir(data);
        $scope.bonds = data;
        $scope.updateTime = Date();
        $scope.loaded = true;
      }).
      error(function (data) {
        console.log("error");
        console.dir(data);
      });
  };
  $interval(function () {
    $scope.updateScreen();
  }, 50000);
  $scope.updateScreen();

});
