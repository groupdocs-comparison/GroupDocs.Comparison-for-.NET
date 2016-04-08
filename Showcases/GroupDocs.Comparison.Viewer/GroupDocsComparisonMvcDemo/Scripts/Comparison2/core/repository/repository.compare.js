define("core/repository/repository.compare",
    ["jquery",
     "core/config",
     "core/dataservice/dataservice.compare"
    ],
    function ($, config, ds) {
        var compare = new function (){ };
        var userCredentials = { userId: config.userId, privateKey: config.privateKey };
        
        compare.startComparison = function(sessionId, sourceFileId, targetFileId, doneCallback, errorCallback) {
            var params = $.extend({
                comparisonSessionId: sessionId,
                sourceFileId: sourceFileId,
                targetFileId: targetFileId
            }, userCredentials);
            
            return $.Deferred(function (def) {
                ds.compare({
                    success: function(response) {
                        if (response.Status.toLowerCase() !== "ok") {
                            def.reject(response.ErrorMessage);
                        } else {
                            def.resolve(response.Result.JobId);
                        }
                    },
                    error: function() {
                        def.reject();
                    }
                }, params);
            }).promise().done(doneCallback).fail(errorCallback);
        };
        
        compare.getOutputDocument = function (jobId, doneCallback, errorCallback) {
            var params = $.extend({
                jobId: jobId
            }, userCredentials);

            return $.Deferred(function (def) {
                if (!jobId) def.reject("Unknown jobId");
                
                ds.getOutputDocument({
                    success: function (response) {
                        def.resolve(response);
                    },
                    error: function () {
                        def.reject();
                    }
                }, params);
            }).promise().done(doneCallback).fail(errorCallback);
        };
        
        compare.getChanges = function (docId, doneCallback, errorCallback) {
            var params = $.extend({
                resultFileId: docId
            }, userCredentials);

            return $.Deferred(function (def) {
                ds.getChanges({
                    success: function (response) {
                        if (response.Status.toLowerCase() !== "ok") {
                            def.reject(response.ErrorMessage);
                        } else {
                            def.resolve(response.Result);
                        }
                    },
                    error: function () {
                        def.reject();
                    }
                }, params);
            }).promise().done(doneCallback).fail(errorCallback);
        };

        compare.downloadableGetChanges = function (docId, doneCallback, errorCallback) {
            var params = {
                contextId: docId
            };

            return $.Deferred(function (def) {
                ds.downloadableGetChanges({
                    success: function (response) {
                        if (response.Status.toLowerCase() !== "ok") {
                            def.reject(response.ErrorMessage);
                        } else {
                            def.resolve(response.Result);
                        }
                    },
                    error: function () {
                        def.reject();
                    }
                }, params);
            }).promise().done(doneCallback).fail(errorCallback);
        };
        
        compare.getEmbedGuid = function ( doneCallback, errorCallback) {
            var params = $.extend({}, userCredentials);

            return $.Deferred(function (def) {
                ds.getEmbedGuid({
                    success: function (response) {
                        if (response.success) {
                            def.resolve(response.result);
                        }
                    },
                    error: function () {
                        def.reject();
                    }
                }, params);
            }).promise().done(doneCallback).fail(errorCallback);
        };
        
        compare.generateEmbedGuid = function (doneCallback, errorCallback) {
            var params = $.extend({}, userCredentials);

            return $.Deferred(function (def) {
                ds.generateEmbedGuid({
                    success: function (response) {
                        if (response.success) {
                            def.resolve(response.result);
                        }
                    },
                    error: function () {
                        def.reject();
                    }
                }, params);
            }).promise().done(doneCallback).fail(errorCallback);
        };

        compare.getDocumentDetails = function(guid) {
            var params = $.extend({ guid: guid }, userCredentials);
            return $.Deferred(function(def) {
                ds.getDocumentDetails({
                    success: function(response) {
                        if (response.Status==="Ok") {
                            def.resolve(response.Result);
                        }
                    },
                    error: function() {
                        def.reject();
                    }
                }, params);
            });
        };

        compare.updateChanges = function(resultFileId, changes) {
            var params = $.extend({ resultFileId: resultFileId, changes: changes }, userCredentials);
            return $.Deferred(function (def) {
                ds.updateChanges({
                    success: function (response) {
                        if (response.Status === "Ok") {
                            def.resolve(response.Result);
                        }
                    },
                    error: function () {
                        def.reject();
                    }
                }, params);
            });
        };

        compare.getDownloadResultUrl = function(docId, format) {
            var url = ViewContext.Credentials.serviceAddress + "/comparison/public/" + docId + "/download?format=" + format;
            return url;
        };

        return compare;
    });