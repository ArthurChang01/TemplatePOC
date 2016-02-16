(function() {
    "use strict";

    angular.module("app.common")
        .controller("previewBoxCtrl", previewBoxCtrl);

    previewBoxCtrl.$inject = ["$scope", "$uibModalInstance", "$sce", "templateName", "previewUrl"];

    function previewBoxCtrl($scope, $uibModalInstance, $sce, templateName, previewUrl) {
        var vm = $scope;
        vm.tempplateName = templateName;
        vm.givenUrl = $sce.trustAsResourceUrl(previewUrl);

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