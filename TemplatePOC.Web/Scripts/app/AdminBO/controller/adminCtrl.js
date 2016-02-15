(function () {
    "use strict";

    angular.module("app.admin.bo")
               .controller("adminCtrl", adminCtrl);

    adminCtrl.$inject = ["lobbyDesignSvc", "$log", "$state", "messageBoxSvc"];

    function adminCtrl(lobbyDesignSvc, $log, $state, messageBoxSvc) {
        var vm = this;
        vm.Templates = [];

        vm.UpdateTemplate = updateTemplate;
        vm.StatusChangeEvent = statusChangeEvent;

        function updateTemplate(id) {
            $state.go("updateLobbyDesign", { id: id });
        }

        function statusChangeEvent(id, name, onChanged) {
            onChanged = onChanged || function () { $log.info("StatusChange is success"); }

            //var modalInstance = $uibModal.open({
            //    animation: true,
            //    templateUrl: '/Scripts/app/_Common/service/messageBox/messageBox.html',
            //    controller: 'messageBoxCtrl',
            //    resolve: {
            //        questionString: function () {
            //            return "Are you sure?";
            //        }
            //    }
            //});
            var modalInstance = messageBoxSvc.openMessageBox("Are u sure?");
            modalInstance.result.then(onOk, onCancel);

            function onOk() {
                lobbyDesignSvc.modify({ id: id, status: name }, onChanged, function(err) { alert(err); });
            }

            function onCancel() {
                $log.info("StatusChange is canceled");
            }
        }

        lobbyDesignSvc.query({ limit: 5, index: 1 },
            function (data) {
                vm.Templates = data;
            },
            function (err) {
                $log.info(err);
            });
        }

})();