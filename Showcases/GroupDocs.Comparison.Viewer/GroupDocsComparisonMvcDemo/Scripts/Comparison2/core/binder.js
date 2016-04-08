define("core/binder",
    ["jquery", "ko"],
    function ($, ko) {
        var bind = function(viewId, vmodel) {
            $.each($(viewId), function() {
                ko.applyBindings(vmodel, this);
            });
        };            
            
        return {
            bind: bind
        };
    });