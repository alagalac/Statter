angular.module('statter.controllers', [])

.controller('StatisticListController', function ($scope, $state, popupService, $window, Statistic) {

    $scope.searchText = "";
    $scope.searchResults = Statistic.query();

    $scope.deleteStatistic = function (stat) {
        if (popupService.showPopup('Really delete this?')) {
            stat.$delete(function () {
                $window.location.href = '';
            });
        }
    }

    $scope.search = function () {
        $scope.searchResults = Statistic.query({ searchText: $scope.searchText });
    }

}).controller('StatisticViewController', function ($scope, $stateParams, Statistic, Value) {

    $scope.stat = Statistic.get({ id: $stateParams.id });

    $scope.statValues = Value.read({ statisticId: $stateParams.id, count: 10 })

}).controller('StatisticCreateController', function ($scope, $state, $stateParams, Statistic) {

    $scope.stat = new Statistic();

    $scope.addStatistic= function () {
        $scope.stat.$save(function () {
            $state.go('stats');
        });
    }

}).controller('StatisticEditController', function ($scope, $state, $stateParams, Statistic) {

    $scope.updateMovie = function () {
        $scope.stat.$update(function () {
            $state.go('stats');
        });
    };

    $scope.loadStatistic = function () {
        $scope.stat = Statistic.get({ id: $stateParams.id });
    };

    $scope.loadStatistic();
});