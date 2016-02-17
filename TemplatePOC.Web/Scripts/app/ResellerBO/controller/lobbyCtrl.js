(function () {
    "use strict";

    angular.module("app.reseller.bo")
              .controller("lobbyCtrl", lobbyCtrl);

    lobbyCtrl.$inject = ["lobbySvc", "gameGroupBoxSvc","previewBoxSvc", "$log", "$state", "$stateParams"];

    function lobbyCtrl(lobbySvc, gameGroupBoxSvc, previewBoxSvc, $log, $state, $stateParams) {
        var vm = this;
        vm.IsAdd = !$stateParams.id;
        vm.model = {
            Name: '',
            Description: '',
            Type: null,
            PreviewUrl: '',
            TemplateId: '',
            CSS: '',
            GameGroups: gameGroupBoxSvc.DataModel.gameGroups
        };

        vm.AddGameGroup = gameGroupBoxSvc.AddGameGroup;
        vm.UpdateGameGroup = gameGroupBoxSvc.UpdateGameGroup;
        vm.RemoveGameGroup = gameGroupBoxSvc.RemoveGameGroup;
        vm.OnPreview = onPreview;
        vm.OnSave = onSave;

        function onPreview() {
            var template = vm.model.Templates.filter(function (val) { return val.Id === vm.model.TemplateId; })[0];
            previewBoxSvc.OpenPreviewBox(template.Name, template.PreviewUrl, vm.model.CSS);
        }

        function onSave() {

            if (vm.IsAdd) //add version
                lobbySvc.save(vm.model, onComplete, onFail);
            else { //edite version
                var dto = {
                    Lobby: vm.model,
                    Removed: gameGroupBoxSvc.DataModel.removed,
                    Updated: gameGroupBoxSvc.DataModel.updated
                };
                lobbySvc.update(dto, onComplete);
            }

            function onComplete() {
                $state.go("reseller");
                gameGroupBoxSvc.FlushData();
            }

            function onFail() {
                $log.info("lobby saving is fail!");
            }
        }

        if (vm.IsAdd) //add version
            lobbySvc.getTemplateItems(null, function (data) {
                vm.model.Templates = data;
            }, function (err) {
                $log.info(err);
            });
        else
            lobbySvc.get({ id: $stateParams.id },
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