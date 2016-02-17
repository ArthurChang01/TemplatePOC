(function() {
    "use strick";

    angular.module("app.common")
        .directive("postMessageDir", postMessageDir);

    postMessageDir.$inject = [];

    function postMessageDir() {
        return {
            restrict: "EA",
            replace: true,
            scope: {
                cssString:'=',
                sourceUrl:'='
            },
            templateUrl: '/Scripts/app/_Common/directive/postMessage/postMessageDir.html',
            link: function (scope, ele, attrs) {
                var iframe = $(ele[0]),
                     iframeWindow = iframe[0].contentWindow;

                iframe.one('load', function () { iframeWindow.postMessage(scope.cssString, 'http://localhost:23684/GameLobby/GameLobby1'); });
            }
        };
    }
})();