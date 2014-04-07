var app = angular.module('spaBoilerplate', [
    "ngResource",
    "ui.bootstrap",
    "ui.router"
]);

app.config(['$stateProvider', '$urlRouterProvider', '$locationProvider',
    function($stateProvider, $urlRouterProvider, $locationProvider) {

        // For any unmatched url, send to /route1
        $urlRouterProvider.otherwise("/");

        $locationProvider.html5Mode(true);

    }]);