(function () {
    'use strict'

    angular.module(TOWAPP)
        .factory('companyServices', companyServices)

    companyServices.$inject = ['$http'];

    function companyServices($http) {
        return {
            insertCompanyRecord: _insertCompanyRecord
        };
        
        function _insertCompanyRecord(onSuccess, onError) {
            var settings = {
                url:"api/towing/companies"
                ,method:"POST"
                ,cache:false
                ,responseType: 'application/json; charset=UTF-8'
                , withCredentials: true
                ,data: data
            };
            return $http(settings)
                .then(onSuccess, onError);
        };

    }
})