(function(){
    "use strict";

    angular.module("app.common", [
        "ui.bootstrap",
        "validation",
        "validation.rule"
    ]).config(config);

    config.$inject = ["$validationProvider"];

    function config($validationProvider) {
        $validationProvider.setErrorHTML(function (msg) {
            return "<label style='color:red;'>" + msg + "</label>";
        });

        $validationProvider.setSuccessHTML(function (msg, element, attrs) {
        });
    }

})();