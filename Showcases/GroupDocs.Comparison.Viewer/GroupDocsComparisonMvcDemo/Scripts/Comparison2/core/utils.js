define("core/utils",
       ["lib/underscore"],
    function (_) {
        var hasProperties = function(obj) {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    return true;
                }
            }
            return false;
        },
            invokeFunctionIfExists = function(callback) {
                if (_.isFunction(callback)) {
                    callback();
                }
            },
            mapMemoToArray = function(items) {
                var underlyingArray = [];
                for (var prop in items) {
                    if (items.hasOwnProperty(prop)) {
                        underlyingArray.push(items[prop]);
                    }
                }
                return underlyingArray;
            };
        return {
            hasProperties: hasProperties,
            invokeFunctionIfExists: invokeFunctionIfExists,
            mapMemoToArray: mapMemoToArray
        };
    });

