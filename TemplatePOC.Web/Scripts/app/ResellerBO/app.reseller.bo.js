﻿(function(){
    "use strict";

    angular.module("app.reseller.bo", [
        "ngResource",
        "ui.router",
        "ui.bootstrap",
        "validation",
        "validation.rule",
        "ui.codemirror",
        "app.common"
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