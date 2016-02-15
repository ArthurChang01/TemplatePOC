(function() {
    "use strickt";

    angular.module("app.common")
        .controller("gameGroupBoxCtrl", gameGroupBoxCtrl);

    gameGroupBoxCtrl.$inject = ["$scope", "gameGroup", "$uibModalInstance"];

    function gameGroupBoxCtrl($scope, gameGroup, $uibModalInstance) {
        $scope.model = gameGroup || {};

        $scope.OnSave = onSave;

        function onSave() {
            $uibModalInstance.close($scope.model);
        }
    }

})();