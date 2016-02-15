(function () {
    "use strict";

    angular.module("app.admin.bo")
              .factory("lobbyDesignSvc", lobbyDesignSvc);

    lobbyDesignSvc.$inject = ["$resource", "$cacheFactory"];

    function lobbyDesignSvc($resource, $cacheFactory) {
        var cache = $cacheFactory('lobbyTemplates');
        var interceptor = {
            response: function(response) {
                cache.removeAll();
                return response;
            }
        };

        return $resource('/api/Template/:id', { id: '@id' }, {
            'get': { method: 'GET', cache: cache },
            'query': { method: 'GET', cache: cache, isArray: true },
            'save': {method:'POST', cache:cache, interceptor:interceptor},
            'update': { method: 'PUT', interceptor: interceptor },
            'modify': {method:'PATCH', interceptor:interceptor}
        });
    }
})();