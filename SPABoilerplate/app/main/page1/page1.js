angular.module('spaBoilerplate')
    .config(['$stateProvider',
        function($stateProvider) {

            $stateProvider
                .state('main.page1', {
                    url: 'page1',
                    templateUrl: 'app/main/page1/page1.html',
                    controller: 'Page1Controller'
                })
                .state('main.page1.list', {
                    url: '/list',
                    templateUrl: 'app/main/page1/list/list.html',
                    controller: function($scope, DataService) {
                        $scope.items = DataService.query();
                    }
                });
        }])

    .controller('Page1Controller', ['$scope',
        function($scope) {

            $scope.titel = "Page 1";

        }]);