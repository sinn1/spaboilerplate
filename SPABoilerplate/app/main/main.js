angular.module('spaBoilerplate')
    .config(['$stateProvider',
        function($stateProvider) {

            $stateProvider
                .state('main', {
                    url: '/',
                    templateUrl: 'app/main/main.html',
                    controller: 'MainController'
                });
        }])
    .controller('MainController', ['$scope',
        function ($scope) {
            
            $scope.item = "mainItem";
            
        }]);