(function () {
    "use strict";

    angular.module("app.admin.bo")
               .config(config)
               .run(run);

    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/BO/admin');

        $stateProvider
            .state('admin', {
                url: '/BO/admin',
                views:{
                    'sideMenu': { templateUrl: '/_adminMenu.html' },
                    'content':{templateUrl:'/AdminBO/Admin'}
                }
            })
            .state('addLobbyDesign', {
                url: '/BO/admin/lobbyDesign',
                views:{
                    'sideMenu': { templateUrl: '/_adminMenu.html' },
                    'content': { templateUrl: '/AdminBO/LobbyDesign' }
                }
            })
            .state('updateLobbyDesign', {
                url: '/BO/admin/lobbyDesign/:id',
                views:{
                    'sideMenu': { templateUrl: '/_adminMenu.html' },
                    'content': { templateUrl: '/AdminBO/LobbyDesign' }
                }
            });
    }

    run.$inject = ["$state"];

    function run($state) {
        $state.go("admin");
    }

})();