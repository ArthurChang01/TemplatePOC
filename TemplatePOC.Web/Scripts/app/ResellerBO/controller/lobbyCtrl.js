(function () {
    "use strict";

    angular.module("app.reseller.bo")
              .controller("lobbyCtrl", lobbyCtrl);

    lobbyCtrl.$inject = ["lobbySvc", "gameGroupBoxSvc", "$log", "$state", "$stateParams"];

    function lobbyCtrl(lobbySvc, gameGroupBoxSvc, $log, $state, $stateParams) {
        var vm = this;
        vm.IsAdd = !$stateParams.id;
        vm.editorOptions = {
            lineNumbers: true,
            gutters: ["CodeMirror-lint-markers"],
            height: 128,
            lint:true,
            indentUnit:4,
            showHint:true,
            inputStyle: 'textarea',
            theme: 'night',
            extraKeys: {"Ctrl-Z":"autocomplete"},
            keyMap:'sublime',
            mode:'css'
        };
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
        vm.LoadCodeMirror = loadCodeMirror;
        vm.OnPreview = onPreview;
        vm.OnSave = onSave;

        function loadCodeMirror(target) {
            var timeouts = [];
            var singleQuoteFlag = false,
                    quoteFlag = false;

            target.on("change", function (editor, change) {
                
                if (change.origin === '+input') {
                    var text = change.text.toString();

                    if (text.match(/'/))
                        singleQuoteFlag = !singleQuoteFlag;
                    if (text.match(/"/))
                        quoteFlag = !quoteFlag;

                    if (!text.match(/[\s()\[\]{};:@"']/) && !singleQuoteFlag && !quoteFlag)
                        timeouts.push(setTimeout(function() {
                            editor.execCommand("autocomplete");
                        }, 250));             
                    else
                        timeouts.splice(0, timeouts.length);
                }
            });
        }

        function onPreview() { }

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