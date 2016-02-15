(function () {
    "use strict";

    angular.module("app.common")
              .directive("dropDownDir", dropDownDir);

    dropDownDir.$inject = ["lobbyStatus"];

    function dropDownDir(lobbyStatus) {
        return {
            restrict: 'EA',
            templateUrl: '/Scripts/app/_Common/directive/dropDown/dropDownDir.html',
            scope: {
                id: '=',
                selectedItem: '=',
                itemChanged: '=?'
            },
            link: function (scope, ele, attrs) {
                var items = lobbyStatus;

                var vm = scope;
                vm.selectedItem = scope.selectedItem;

                vm.menu = filterItem(vm.selectedItem);
                vm.style = items.filter(function (val) { return val.name === vm.selectedItem })[0].style;

                vm.Dropboxitemselected = dropboxitemselected;

                function dropboxitemselected(name) {
                    if (scope.itemChanged)
                        scope.itemChanged(scope.id, name, function () {
                            vm.selectedItem = name;
                            vm.menu = filterItem(name);
                            vm.style = items.filter(function (val) { return val.name === name })[0].style;
                        });
                }

                function filterItem(name) {
                    return items.filter(function (val) { return val.name !== name });
                }
            }
        };
    }
})();