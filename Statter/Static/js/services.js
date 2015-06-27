
angular.module('statter.services', [])
    .factory('Statistic', function ($resource) {

        var header = { 'Authorization': 'Basic ' + btoa('testuser:Pass1word') };

        return $resource('/api/statistics/:id/', { id: '@Id' },
            {
                'create': { method: 'POST', headers: header },
                'index': { method: 'GET', isArray: true },
                'view': { method: 'GET', isArray: false },
                'update': { method: 'PUT', headers: header },
                'destroy': { method: 'DELETE', headers: header },
                'read': { method: 'GET', url: '/api/statistics/:id/read' },
                'write': { method: 'POST', url: '/api/statistics/:id/write', headers: header }
            });
    })
    .factory('Value', function ($resource) {

        var header = { 'Authorization': 'Basic ' + btoa('testuser:Pass1word') };

        return $resource('/api/values/', {},
            {
                'read': { method: 'GET' },
                'write': { method: 'POST', headers: header }
            });
    })
    .service('popupService', function ($window) {
    this.showPopup = function (message) {
        return $window.confirm(message);
    }
});