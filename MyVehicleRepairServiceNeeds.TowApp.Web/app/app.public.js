(function () {
    'use strict';

    window.APP = window.APP || {};
    APP.NAME = 'towApp';

    angular
        .module(APP.NAME, [
            'ui.router'
            , APP.NAME + '.routes'
            , 'toastr'
        ]);
})();


(function () {
    'use strict';

    var app = angular.module(APP.NAME + '.routes', []);

    app.config(_configureStates);

    _configureStates.$inject = ['$stateProvider', '$locationProvider'];

    function _configureStates($stateProvider, $locationProvider) {
        $locationProvider.html5Mode({
            enabled: true
            , requireBase: false
        });

        var initialPublicStates = {
            url: '/'
            , params: {
                role: null
            }, 
            views: {
                'nav': {
                    templateUrl: 'app/public/modules/companyRegister/views/nav.html'
                    , controller: 'splashPageController as splashCtrl'
                }
                , 'splash': {
                    templateUrl: 'app/public/modules/companyRegister/views/splash.html'
                    , controller: 'splashPageController as splashCtrl'
                }
                //, 'footer': {
                //    templateUrl: ''
                //    , controller: ''
                //}
            }
        };
        $stateProvider.state('pub', initialPublicStates);

        //var splashPage = {
        //    url
        //}

        var companyRegister = {
            url: 'register'
            , title: 'Register'
            , templateUrl: '/app/public/modules/companyRegister/views/companyRegister.html'
            , controller: 'registerController as regCtrl'
            , params: {
                companyId: null

            }
        };
        $stateProvider.state('pub.register', companyRegister);

        var companyRecords = {
            url: 'records'
            , title: 'Records'
            , templateUrl: '/app/public/modules/companyRegister/views/companyRecords.html'
            , controller: 'recordsController as recCtrl'
            , params: {
                reload: true
            }

        };
        $stateProvider.state('pub.records', companyRecords);


    }

})();
(function () {
    angular.module(APP.NAME)
        .controller("splashPageController", SplashPageController);

    SplashPageController.$inject = ["$log"]

    function SplashPageController($log) {

        var vm = this;


    }


})();


(function () {
    'use strict'

    angular.module(APP.NAME)
        .controller("recordsController", RecordsController);

    RecordsController.$inject = ['$log', "$stateParams", "$state", 'companyService', 'toastr']


    function RecordsController($log, $stateParams, $state, companyService, toastr) {

        var vm = this;
        vm.$onInit = _onInit;
        vm.getCompanyRecordById = _getCompanyRecordById;
        vm.deleteCompanyData = _deleteCompanyData;

        function _onInit() {
            companyService.getCompanyRecords(_getCompanyDataSuccess, _getCompanyDataError)
            if ($stateParams.companyId == null) {
                vm.editMode = false;
            } else {
                companyService.getCompanyRecordById($stateParams.companyId, _getCompanyRecordByIdSuccess, _getCompanyRecordByIdError)
                vm.editMode = true;
            }
        }
        function _getCompanyRecordById(recordId) {
            companyService.getCompanyRecordById(recordId, _getCompanyRecordByIdSuccess, _getCompanyRecordByIdError)
        }

        function _getCompanyRecordByIdSuccess(response) {
            debugger
            vm.recordId = response.data.item.id
            $log.log("Successful Get By Id")
            if (vm.editMode == true) {
                vm.companyData = response.data.item;
            } else {
                vm.companyId = response.data.item.id;
                $state.go("pub.register", { companyId: vm.companyId })
                toastr.warning("Edit Mode");
            }


        }

        function _getCompanyRecordByIdError(response) {
            $log.log("Get By Id failed")

        }

        function _deleteCompanyData(recordId, index) {
            vm.index = index;
            companyService.deleteRecord(recordId, _deleteCompanyDataSuccess, _deleteCompanyDataError);
        }

        function _getCompanyDataSuccess(response) {
            $log.log("Successful Retrieval")
            vm.companyRecords = response.data.items;
            debugger
        }

        function _getCompanyDataError(response) {
            $log.log("Retrieval failed")

        }

        function _deleteCompanyDataSuccess(response, itemDelete) {
            $log.log("Delete Successful")
            vm.companyRecords.splice(vm.index, 1);
            toastr.success("Delete Successful");

        }

        function _deleteCompanyDataError(response) {
            $log.log("Delete failed")


        }

    }
})();

(function () {
    'use strict'

    angular.module(APP.NAME)
        .controller("registerController", RegisterController);

    RegisterController.$inject = ['$log', "$stateParams", "$state", 'companyService', 'toastr']


    function RegisterController($log, $stateParams, $state, companyService, toastr) {

        var vm = this;
        vm.updateCompanyData = _updateCompanyData;
        vm.addCompanyData = _addCompanyData;
        vm.$onInit = _onInit;


        function _onInit() {
            debugger
            if ($stateParams.companyId == null) {
                vm.editMode = false;
            } else {
                companyService.getCompanyRecordById($stateParams.companyId, _getCompanyRecordByIdSuccess, _getCompanyRecordByIdError)
                vm.editMode = true;
            }
        }

        function _updateCompanyData() {

            companyService.updateCompanyRecord(vm.companyData, vm.recordId, _updateCompanyRecordSuccess, _updateCompanyRecordError)
        }

        function _addCompanyData() {
            companyService.addCompanyRecord(vm.companyData, _addCompanyDataSuccess, _addCompanyDataError);
        }

        function _updateCompanyRecordSuccess(response) {
            $log.log("Successful Update");
            $state.go("pub.records");
            toastr.success("Update Successful");

        }

        function _updateCompanyRecordError(response) {
            $log.log("Update failed")

        }

        function _getCompanyRecordByIdSuccess(response) {
            debugger
            vm.recordId = response.data.item.id
            $log.log("Successful Get By Id")
            if (vm.editMode == true) {
                vm.companyData = response.data.item;
            } else {
                vm.companyId = response.data.item.id;
                $state.go("pub.register", { companyId: vm.companyId })
                toastr.warning("Edit Mode");
            }


        }

        function _getCompanyRecordByIdError(response) {
            $log.log("Get By Id failed")

        }

        function _addCompanyDataSuccess(response) {
            $log.log("Successful addition")
            toastr.success("Submit Successful");
            $state.go("pub.records")

        }

        function _addCompanyDataError(response) {
            $log.log("Addition failed")
            toastr.error("Submit Failed")

        }


    }
})();

(function () {
    angular.module(APP.NAME)
        .factory("companyService", companyService)

    companyService.$inject = ["$http"];

    function companyService($http) {

        return {
            addCompanyRecord: _addCompanyRecord
            , getCompanyRecords: _getCompanyRecords
            , deleteRecord: _deleteRecord
            , getCompanyRecordById: _getCompanyRecordById
            , updateCompanyRecord: _updateCompanyRecord
        }

        function _getCompanyRecords(onSuccess, onError) {
            var settings = {
                url: '/api/towing/companies',
                method: 'GET',
                cache: false,
                withCredentials: true
            };
            return $http(settings)
                .then(onSuccess, onError);
        }

        function _updateCompanyRecord(data, recordId, onSuccess, onError) {
            var settings = {
                url: "/api/towing/companies/" + recordId
                , method: "PUT"
                , cache: false
                , contentType: 'json'
                , withCredentials: true
                , data: data
            };
            return $http(settings)
                .then(onSuccess, onError)
        }


        function _addCompanyRecord(data, onSuccess, onError) {
            var settings = {
                url: "/api/towing/companies"
                , method: "POST"
                , cache: false
                , contentType: 'json'
                , withCredentials: true
                , data: data
            };
            return $http(settings)
                .then(onSuccess, onError)
        }

        function _getCompanyRecordById(recordId, onSuccess, onError) {
            var settings = {
                url: "/api/towing/companies/" + recordId
                , method: "GET"
                , cache: false
                , contentType: 'json'
                , withCredentials: true
            };
            return $http(settings)
                .then(onSuccess, onError)
        }

        function _deleteRecord(recordId, onSuccess, onError) {
            var settings = {
                url: '/api/towing/companies/' + recordId
                , method: 'DELETE'
                , cache: false
                , withCredentials: true
            };
            return $http(settings)
                .then(onSuccess, onError)
        }
    }

})();