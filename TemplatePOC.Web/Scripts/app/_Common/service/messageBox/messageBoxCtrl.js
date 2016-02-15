(function() {
    "use strict";

    angular.module("app.common")
        .controller("messageBoxCtrl", messageBoxCtrl);

    messageBoxCtrl.$inject = ["$scope", "$uibModalInstance","questionString"];

    function messageBoxCtrl($scope, $uibModalInstance, questionString) {
        var vm = $scope;
        vm.message = questionString;

        vm.OK = ok;
        vm.Cancel = cancel;

        function ok() {
            $uibModalInstance.close();
        }

        function cancel() {
            $uibModalInstance.dismiss();
        }
    }
})();