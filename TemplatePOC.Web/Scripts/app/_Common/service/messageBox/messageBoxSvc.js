(function() {
    "use strick";

    angular.module("app.common")
        .factory("messageBoxSvc", messageBoxSvc);

    messageBoxSvc.$inject = ["$uibModal"];

    function messageBoxSvc($uibModal) {
        return {
            openMessageBox: openMessageBox
        };

        function openMessageBox(questionString) {
            return $uibModal.open({
                animation: true,
                templateUrl: '/Scripts/app/_Common/service/messageBox/messageBox.html',
                controller: 'messageBoxCtrl',
                resolve: {
                    questionString: function () {
                        return questionString;
                    }
                }
            });
        }
    }
})();