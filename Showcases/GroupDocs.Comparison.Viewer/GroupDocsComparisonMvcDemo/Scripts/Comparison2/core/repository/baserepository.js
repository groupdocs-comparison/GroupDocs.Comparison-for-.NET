define("core/repository/baserepository",
    ["jquery", "lib/underscore", "ko", "core/utils"],
    function ($, _, ko, utils) {
        var itemsToArray = function(items, observableArray) {
            if (!observableArray) return;
            var underlyingArray = utils.mapMemoToArray(items);
            observableArray(underlyingArray);
        },
            addItemsToArray = function (items, observableArray) {
                if (!observableArray) return;
                var currentItems = observableArray();
                var result = currentItems.concat(items);
                observableArray(result);
                //$.each(utils.mapMemoToArray(items), function(i) {
                //    observableArray.push(this);
                //});
            },
            baseRepository = function(target, getFunction, updateFunction) {
                var self = this;
                self.mapDtoListToContext = function(dtoList, results) {
                        var items1 = _.map(dtoList, function(dto) {
                            return target.fromDto(dto);
                        });
                        itemsToArray(items1, results);
                        return items1; // must return these
                    };
                self.addDtoListToContext = function (dtoList, results) {
                    var items1 = _.map(dtoList, function (dto) {
                        return target.fromDto(dto);
                    });
                    addItemsToArray(items1, results);
                    return items1; // must return these
                };
                self.getData = function (options) {
                    return $.Deferred(function(def) {
                        var results = options && options.results,
                            param = options && options.param,
                            getFunctionOverride = options && options.getFunctionOverride;

                        getFunction = getFunctionOverride || getFunction;


                        getFunction({
                            success: function(dtoList) {
                                mapDtoListToContext(dtoList, results);
                                def.resolve(results);
                            },
                            error: function() {
                                def.reject();
                            }
                        }, param);
                    }).promise();
                };
                self.updateData = function(entity, callbacks) {

                    var entityJson = ko.toJSON(entity);

                    return $.Deferred(function(def) {
                        if (!updateFunction) {
                            if (callbacks && callbacks.error) {
                                callbacks.error();
                            }
                            def.reject();
                            return;
                        }

                        updateFunction({
                            success: function(response) {
                                entity.dirtyFlag().reset();
                                if (callbacks && callbacks.success) {
                                    callbacks.success();
                                }
                                def.resolve(response);
                            },
                            error: function(response) {
                                if (callbacks && callbacks.error) {
                                    callbacks.error();
                                }
                                def.reject(response);
                                return;
                            }
                        }, entityJson);
                    }).promise();
                };
            };
        return baseRepository;
    });