angular.module('List').service('apiService', ['$http', function ($http) {

    "use strict";

    this.post = function (data, route, successFunction, errorFunction) {
        $http.post(route, data).then(successFunction, errorFunction);
    }
    this.get = function (route, successFunction, errorFunction) {
        $http.get(route).then(successFunction, errorFunction);
    }
    this.delete = function (route, successFunction, errorFunction) {
        $.ajax({
            type: "DELETE",
            url: route,
            success: successFunction
        })
    }

}]);