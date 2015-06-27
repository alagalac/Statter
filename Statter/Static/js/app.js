angular.module('statter', ['ui.router', 'ngResource', 'statter.controllers', 'statter.services']);

angular.module('statter').config(function ($stateProvider, $httpProvider) {
    $stateProvider.state('stats', {
        url: '/statistics',
        templateUrl: 'partials/stats.html',
        controller: 'StatisticListController'
    }).state('viewStat', {
        url: '/statistics/:id/view',
        templateUrl: 'partials/stat_view.html',
        controller: 'StatisticViewController'
    }).state('newStat', {
        url: '/statistics/new',
        templateUrl: 'partials/stat_create.html',
        controller: 'StatisticCreateController'
    }).state('editStat', {
        url: '/statistics/:id/edit',
        templateUrl: 'partials/stat_edit.html',
        controller: 'StatisticEditController'
    });
}).run(function ($state) {
    $state.go('stats');
});

/*
http://www.sitepoint.com/creating-crud-app-minutes-angulars-resource/

*/