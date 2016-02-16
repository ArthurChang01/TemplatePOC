(function () {
    "use strict";

    angular.module("app.reseller.bo")
               .config(config)
               .run(run);

    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/BO/reseller');

        $stateProvider
            .state('reseller', {
                url: '/BO/Reseller',
                views:{
                    'sideMenu': { templateUrl: '/_resellerMenu.html' },
                    'content':{templateUrl:'/ResellerBO/Reseller'}
                }
            })
            .state('addLobby', {
                url: '/BO/reseller/lobby/',
                views: {
                    'sideMenu': { templateUrl: '/_resellerMenu.html' },
                    'content': { templateUrl: '/ResellerBO/Lobby' }
                }
            })
            .state('updateLobby', {
                url: '/BO/reseller/lobby/:id',
                views: {
                    'sideMenu': { templateUrl: '/_resellerMenu.html' },
                    'content': { templateUrl: '/ResellerBO/Lobby' }
                }
            });
    }

    run.$inject = ["$state"];

    function run($state) {
        $state.go("reseller");
    }

})();