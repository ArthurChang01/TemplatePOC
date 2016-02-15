(function () {
    "use strict";

    angular.module("app.reseller.bo")
              .factory("lobbySvc", lobbySvc);

    lobbySvc.$inject = ["$resource","$cacheFactory"];

    function lobbySvc($resource,$cacheFactory) {
        var cache = $cacheFactory('lobby');
        var interceptor = {
            response: function (response) {
                cache.removeAll();
                return response;
            }
        };

        return $resource('/api/Lobby/:id', { id: '@id' }, {
            'get': { method: 'GET', cache: cache },
            'getTemplateItems': {method:'GET',cache:cache, isArray:true},
            'query': { method: 'GET', cache: cache, isArray: true },
            'save': { method: 'POST', cache: cache, interceptor: interceptor },
            'update': { method: 'PUT', interceptor: interceptor },
            'modify': { method: 'PATCH', interceptor: interceptor }
        });
    }
})();