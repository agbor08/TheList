angular.module("List").config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "Views/Home/Index.html"
        });
});