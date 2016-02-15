(function () {
    "use strict";

    angular.module("app.admin.bo")
              .controller("lobbyDesignCtrl", lobbyDesignCtrl);

    lobbyDesignCtrl.$inject = ["lobbyDesignSvc", "gameGroupBoxSvc", "$log", "$stateParams", "$state"];

    function lobbyDesignCtrl(lobbyDesignSvc, gameGroupBoxSvc, $log, $stateParams, $state) {
        var vm = this;
        vm.IsAdd = !$stateParams.id;
        vm.model = {
            Name: '',
            Description: '',
            Type: null,
            PreviewUrl: '',
            GameGroups: gameGroupBoxSvc.DataModel.gameGroups
        };

        vm.AddGameGroup = gameGroupBoxSvc.AddGameGroup;
        vm.UpdateGameGroup = gameGroupBoxSvc.UpdateGameGroup;
        vm.RemoveGameGroup = gameGroupBoxSvc.RemoveGameGroup;
        vm.OnSave = onSave;

        function onSave() {

            if (vm.IsAdd) //add version
                lobbyDesignSvc.save(vm.model, onComplete, onFail);
            else { //edite version
                var dto = {
                    Template: vm.model,
                    Removed: gameGroupBoxSvc.DataModel.removed,
                    Updated: gameGroupBoxSvc.DataModel.updated
                };
                lobbyDesignSvc.update(dto, onComplete, onFail);
            }

            function onComplete() {
                $state.go("admin");
                gameGroupBoxSvc.FlushData();
            }

            function onFail() {
                $log.info("lobby design saving is fail");
            }
        }

        if (!vm.IsAdd) //edite version
            lobbyDesignSvc.get({ id: $stateParams.id },
                function (data) {
                    angular.merge(vm.model, data);
                    gameGroupBoxSvc.DataModel.gameGroups = vm.model.GameGroups;
                    vm.model.Type = vm.model.Type.toString();
                },
                function (err) {
                    $log.info(err);
                });
    }
})();