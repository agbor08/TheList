(function () {
    var app = angular.module('List', ['ngRoute']);
    app.config(['$controllerProvider', '$provide', function ($controllerProvider, $provide) {
        app.register =
            {
                controller: $controllerProvider.register,
                service: $provide.service
            };
    }]);
})();