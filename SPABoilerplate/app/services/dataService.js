angular.module('spaBoilerplate')
    .factory('DataService', ['$resource',
        function($resource) {
            return $resource('/api/data/:id', { id: '@id' }, { update: { method: 'PUT' } });
        }]);
