(function() {
    "use strict";

    angular.module("app.common")
        .controller("previewBoxCtrl", previewBoxCtrl);

    previewBoxCtrl.$inject = ["$scope", "$uibModalInstance", "$sce", "templateName", "previewUrl", "css"];

    function previewBoxCtrl($scope, $uibModalInstance, $sce, templateName, previewUrl, css) {
        var vm = $scope;
        vm.tempplateName = templateName;
        vm.givenUrl = $sce.trustAsResourceUrl(previewUrl);
        vm.css = css;

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