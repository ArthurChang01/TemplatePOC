(function () {
    "use strict";

    angular.module("app.common")
        .directive("cssEditor", cssEditor);

    function cssEditor() {
        return {
            restrict: "EA",
            replace: true,
            scope: {
                content: "="
            },
            templateUrl: "/Scripts/app/_Common/directive/cssEditor/cssEditor.html",
            controller: ["$scope",fnCtrl]
        };

        function fnCtrl($scope) {
            var vm = $scope;
            vm.editorOptions = {
                lineNumbers: true,
                gutters: ["CodeMirror-lint-markers"],
                height: 128,
                lint: true,
                indentUnit: 4,
                showHint: true,
                inputStyle: 'textarea',
                theme: 'night',
                extraKeys: { "Ctrl-Z": "autocomplete" },
                keyMap: 'sublime',
                mode: 'css'
            };

            vm.LoadCodeMirror = loadCodeMirror;

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
                            timeouts.push(setTimeout(function () {
                                editor.execCommand("autocomplete");
                            }, 250));
                        else
                            timeouts.splice(0, timeouts.length);
                    }
                });
            }
        }

    }
})();