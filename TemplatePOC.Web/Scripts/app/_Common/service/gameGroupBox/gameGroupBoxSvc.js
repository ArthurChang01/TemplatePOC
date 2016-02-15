(function() {
    "use strick";

    angular.module("app.common")
        .factory("gameGroupBoxSvc", gameGroupBoxSvc);

    gameGroupBoxSvc.$inject = ["$uibModal","$log"];

    function gameGroupBoxSvc($uibModal, $log) {
        var me = this;
        me.model = {
            gameGroups: [],
            removed: [],
            updated:[]
        };

        return {
            DataModel: me.model,
            FlushData:flushData,
            AddGameGroup:addGameGroup,
            UpdateGameGroup: updateGameGroup,
            RemoveGameGroup: removeGameGroup
        };

        function openGameGroupBox(group) {
            return $uibModal.open({
                animation: true,
                templateUrl: '/Scripts/app/_Common/service/gameGroupBox/gameGroupBox.html',
                controller: 'gameGroupBoxCtrl',
                resolve: {
                    gameGroup: function () {
                        return group;
                    }
                }
            }).result;
        }

        function addGameGroup() {
            if (me.model.gameGroups.length >= 5) {
                alert("已經超過五個了!");
                return;
            }

            openGameGroupBox(null).then(onComplete, onFail);

            function onComplete(group) {
                if (me.model.gameGroups.length >= 5) {
                    alert("已經超過五個了!");
                    return;
                }

                me.model.gameGroups.push(group);
            }

            function onFail() {
                $log.info("Modal fail");
            }
        }

        function updateGameGroup(group) {
            openGameGroupBox(group).then(onComplete, onFail);

            function onComplete() {
                if (me.model.updated.indexOf(group.Id) < 0)
                    me.model.updated.push(group.Id);
                $log.info("Modal Finished");
            }

            function onFail() {
                $log.info("Modal fail");
            }
        }

        function removeGameGroup(group) {
            var idx = me.model.gameGroups.indexOf(group);
            me.model.gameGroups.splice(idx, 1);

            if (me.model.removed.indexOf(group.Id) < 0)
                me.model.removed.push(group.Id);
        }

        function flushData() {
            me.model.gameGroups.splice(0, me.model.gameGroups.length);
            me.model.removed.splice(0, me.model.removed.length);
            me.model.updated.splice(0, me.model.updated.length);
        }
    }
})();