(function () {
    "use strict";

    angular.module("app.reseller.bo")
              .controller("resellerCtrl", resellerCtrl);

    resellerCtrl.$inject = ["lobbySvc", "$log", "$state", "messageBoxSvc"];

    function resellerCtrl(lobbySvc, $log, $state, messageBoxSvc) {
        var vm = this;
        vm.Templates = [];

        vm.UpdateLobby = updateLobby;
        vm.StatusChangeEvent = statusChangeEvent;

        function updateLobby(id) {
            $state.go("updateLobby", { id: id });
        }

        function statusChangeEvent(id, name, onChanged) {
            onChanged = onChanged || function() { $log.info("StatusChange is success"); }

            var modalInstance = messageBoxSvc.openMessageBox("Are u sure?");
            modalInstance.result.then(onOk, onCancel);

            function onOk() {
                lobbySvc.modify({ id: id, status: name }, onChanged, function(err) { alert(err); });
            }

            function onCancel() {
                $log.info("StatusChange is canceled");
            }
        }

        vm.lobbies = lobbySvc.query({ limit: 5, index: 1 },
            function(data) {
                vm.Templates = data;
            },
            function(err) {
                $log.info(err);
            });
    }
})();