console.log("index");

angular.module("List").controller('IndexController',
    ['$routeParams', '$location', 'apiService', function ($routeParams, $location, apiService) {

        "use strict";

        var vm = this;

        vm.addToList = addToList;
        vm.clearList = clearList;
        vm.listItems = [];
        vm.itemToAdd = "";

        this.initializeController = function () {
            vm.title = "Home Page";
            loadList();
        };

        function loadList() {

            apiService.get('api/List', successCallback, errorCallback);

            function successCallback(response) {
                vm.listItems = response.data;
            }
            function errorCallback(error) {
                //error code
            }
        }

        function addToList() {

            apiService.post(vm.itemToAdd, 'api/List', successCallback, errorCallback);

            function successCallback(response) {
                vm.listItems.push(response.data);
            }
            function errorCallback(error) {
                //error code
            }
        }

        function clearList() {

            apiService.delete("api/List", successCallback);

            function successCallback(response) {
                loadList();
            }
        }

    }]);