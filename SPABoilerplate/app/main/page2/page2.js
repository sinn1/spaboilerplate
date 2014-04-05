angular.module('spaBoilerplate')
    .config(['$stateProvider',
        function ($stateProvider) {

            $stateProvider
                .state('main.page2', {
                    url: 'page2',
                    templateUrl: 'app/main/page2/page2.html',
                    controller: 'Page2Controller'
                });
        }])

    .controller('Page2Controller', ['$scope',
        function ($scope) {

            $scope.title = "Page 2";

        }]);