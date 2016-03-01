(function () {
    angular.module("components")
        .value("codeMirrorInstance", { instance: null })
        .directive("cssEditor", cssEditor);

    function cssEditor() {
        return {
            restrict: "EA",
            replace: true,
            scope: {
                content: "="
            },
            template: "<textarea class='form-control' rows='5' ng-model='content' ui-codemirror='{ onLoad : LoadCodeMirror }' ui-codemirror-opts='editorOptions'></textarea>",
            controller: ["$scope", "codeMirrorInstance", fnCtrl]
        };

        function fnCtrl($scope, codeMirrorInstance) {
            var vm = $scope;
            vm.editorOptions = {
                lineNumbers: true,
                gutters: ["CodeMirror-lint-markers"],
                height: 128,
                lint: true,
                indentUnit: 4,
                showHint: true,
                inputStyle: 'textarea',
                theme: 'elegant',
                extraKeys: { "Ctrl-Z": "autocomplete" },
                keyMap: 'sublime',
                mode: 'css'
            };

            vm.LoadCodeMirror = loadCodeMirror;

            function loadCodeMirror(target) {
                codeMirrorInstance.instance = target;
                var timeouts = [];

                target.on("change", function (editor, change) {

                    if (change.origin === '+input') {
                        var text = change.text.toString();

                        if (!text.match(/[\s()\[\]{};:@."'\r\n\t]/))
                            timeouts.push(setTimeout(function () {
                                editor.execCommand("autocomplete");
                            }, 50));
                        else
                            timeouts.splice(0, timeouts.length);
                    }
                });
            }
        }
    }
})();