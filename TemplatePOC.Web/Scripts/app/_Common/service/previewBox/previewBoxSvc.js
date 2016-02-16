(function () {
    "use strick";

    angular.module("app.common")
        .factory("previewBoxSvc", previewBoxSvc);

    previewBoxSvc.$inject = ["$uibModal"];

    function previewBoxSvc($uibModal) {
        return {
            OpenPreviewBox: openPreviewBox
        };

        function openPreviewBox(templateName, previewUrl) {
            return $uibModal.open({
                animation: true,
                templateUrl: '/Scripts/app/_Common/service/previewBox/previewBox.html',
                controller: 'previewBoxCtrl',
                resolve: {
                    templateName: function () {
                        return templateName;
                    },
                    previewUrl: function() {
                        return previewUrl;
                    }
                }
            });
        }
    }
})();