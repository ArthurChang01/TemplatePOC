(function () {
    angular.module("app.common")
        .value("codeMirrorInstance", { instance: null })
        .directive("cssEditor", cssEditor);

    function cssEditor() {
        return {
            restrict: "EA",
            replace: true,
            scope: {
                content: "="
            },
            template:
                "<div>" +
                "   <button title='format text' ng-click='AutoFormatting()'><span class='fa fa-bars'>F</span></button>" +
                "   <button title='undo' ng-click='Undo()'><span class='fa fa-undo'></span></button>" +
                "   <button title='redo' ng-click='Redo()'><span class='fa fa-repeat'></span></button>" +
                "   <textarea class='form-control' rows='5' ng-model='content' ui-codemirror='{ onLoad : LoadCodeMirror }' ui-codemirror-opts='editorOptions'></textarea>" +
                "</div>",
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
                undoDepth: 50,
                showHint: true,
                inputStyle: 'textarea',
                theme: 'elegant',
                extraKeys: { "Ctrl-Z": "autocomplete" },
                keyMap: 'sublime',
                mode: 'css'
            };

            vm.LoadCodeMirror = loadCodeMirror;
            vm.AutoFormatting = autoFormatting;
            vm.Undo = undo;
            vm.Redo = redo;

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

            function autoFormatting() {
                var totalLines = codeMirrorInstance.instance.lineCount();
                var totalChars = codeMirrorInstance.instance.getTextArea().value.length;

                codeMirrorInstance.instance.autoFormatRange({ line: 0, ch: 0 }, { line: totalLines });
            }

            function undo() {
                codeMirrorInstance.instance.undo();
            }

            function redo() {
                codeMirrorInstance.instance.redo();
            }
        }
    }
})();