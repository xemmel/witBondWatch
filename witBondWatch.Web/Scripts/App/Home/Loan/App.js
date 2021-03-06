﻿var app = angular.module('loanApp', []);

var loanCtrl = app.controller('loanCtrl', function ($scope, $http,$interval) {
  $scope.InputLoan = 2569000;
  $scope.bondName = "DK0009798993";
  $scope.bond = {};
  $scope.loaded = false;
  $scope.loanCorrected = $scope.InputLoan;
  $scope.updateScreen = function () {
    $scope.loaded = false;

    //console.log("click");
    $http({ method: "GET", url: "/Home/getTheBond", params: { bondName: $scope.bondName } }).
      success(function (data) {
        console.dir(data);
        $scope.bond = data;
        $scope.loanCorrected = ($scope.InputLoan * ($scope.bond.OfferValue / 100));
        $scope.updateTime = Date();
        $scope.loaded = true;

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