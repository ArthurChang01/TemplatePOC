(function () {
    "use strict";

    angular.module("app.common")
        .value("lobbyStatus", [
                    { name: 'Activate', style: 'btn-success' },
                    { name: 'Inactive', style: 'btn-danger' },
                    { name: 'Maintanance', style: 'btn-warning' },
                    { name: 'Archive', style: 'btn-info' }]);
})();