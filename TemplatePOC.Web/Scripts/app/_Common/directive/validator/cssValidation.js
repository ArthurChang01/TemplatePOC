(function () {
    'use strict';

    angular
        .module('app.common')
        .directive('cssValidation', function () {
            return {
                restrict: 'A',
                require: 'ngModel',
                link: function (scope, elem, attrs, ctrl) {
                    var cssRegex = /^(([a-z0-9\[\]=:]+\s?)|((div|span)?(#|\.){1}[a-z0-9\-_\s?:]+\s?)+)(\{[\s\S][^}]*})$/mi;
                    ctrl.$validators.cssValidation = function (modelValue, viewValue) {
                        if (!modelValue) return true;

                        var newVal = modelValue.replace(/\n/im, '');
                        if (newVal.trim() === '' || cssRegex.test(newVal))
                            return true;

                        return false;
                    }
                }
            }
        });
})();