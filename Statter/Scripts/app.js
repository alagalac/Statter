'use strict';


// Declare app level module which depends on views, and components
angular.module('statter', ['statter.controllers', 'statter.services'])

.config(['$resourceProvider', function ($resourceProvider) {
    // Don't strip trailing slashes from calculated URLs
    $resourceProvider.defaults.stripTrailingSlashes = false;
}]);

// Our dependencies...

angular.module('statter.services', ['ngResource']).factory('Statistic', function ($resource) {

    var header = { 'Authorization': 'Basic ' + btoa('testuser:Pass1word') };

    return $resource('/api/statistics/:id/', { Id: '@id' },
        {
            'create': { method: 'POST', headers: header },
            'index': { method: 'GET', isArray: true },
            'view': { method: 'GET', isArray: false },
            'update': { method: 'PUT', headers: header },
            'destroy': { method: 'DELETE', headers: header },
            'poll': { method: 'GET', url: '/api/statistics/:id/values/', headers: header },
            'push': { method: 'POST', url: '/api/statistics/:id/values/' }
        });
});


// sort the controllers
angular.module('statter.controllers', [])
 
.controller('searchController', function ($scope, Statistic) {

    $scope.searchResults = [];
    $scope.searchText = "";

    $scope.search = function () {
        $scope.searchResults = Statistic.index({ searchText: $scope.searchText});
    }
})
.controller('createController', function ($scope, Statistic) {

    $scope.stat = new Statistic();

    $scope.create = function () {
        Statistic.create($scope.stat)
    }


});