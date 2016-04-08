(function () {
    var root = this;

    requirejs.config({
        baseUrl: "/scripts/comparison2"
        
    });

    function boot() {

    }

    function define3RdPartyModules() {
        define("jquery", [], function () { return root.jQuery; });
        define("ko", [], function () { return root.ko; });
        define("lib/amplify", [], function () { return root.amplify; });
        define("lib/underscore", [], function () { return root._; });
    }
    
    function loadPluginsAndBoot() {
        requirejs([], boot);
    }
    
    define3RdPartyModules();
    loadPluginsAndBoot();

})();