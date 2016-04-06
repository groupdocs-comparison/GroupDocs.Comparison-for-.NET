define("core/dataservice/dataservice.compare",
    ["lib/amplify", "core/config"],
    function (amplify, config) {
        var urlPrefix = config.isDownloadable?config.downloadableComparisonPrefix+"/comparison2/"
                                             :"/document-comparison2/service/",
            init = function() {
                var mapJson = function(data) {
                    if (typeof data === "object") {
                        return JSON.stringify(data);
                    }
                    return data;
                };

                amplify.request.define("compare", "ajax", {
                    url: urlPrefix + "compare",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: "POST",
                    cache: false,
                    dataMap: mapJson
                });

                amplify.request.define("get-changes", "ajax", {
                    url: urlPrefix + "getchanges",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: "POST",
                    cache: false,
                    dataMap: mapJson
                });

                amplify.request.define("downloadable-get-changes", "ajax", {
                    url: urlPrefix + "getchanges?contextId={contextId}",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: "POST",
                    cache: false,
                    dataMap: mapJson
                });

                amplify.request.define("update-changes", "ajax", {
                    url: urlPrefix + "updatechanges",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: "POST",
                    cache: false,
                    dataMap: mapJson
                });

                amplify.request.define("document-details", "ajax", {
                    url: urlPrefix + "getdocumentdetails",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: "POST",
                    cache: false,
                    dataMap: mapJson
                });
                
                amplify.request.define("output-document", "ajax", {
                    url: urlPrefix + "getoutputdocument",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: "POST",
                    cache: false,
                    dataMap: mapJson
                });
                
                amplify.request.define("get-embded-guid", "ajax", {
                    url: urlPrefix + "getcomparisonembedguid",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    type: "POST",
                    cache: false,
                    dataMap: mapJson
                });
                
                amplify.request.define("generate-embded-guid", "ajax", {
                    url: urlPrefix + "generateembedguid",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    type: "POST",
                    cache: false,
                    dataMap: mapJson
                });

            },
            compare = function(callbacks, data) {
                return amplify.request({
                    resourceId: "compare",
                    success: callbacks.success,
                    error: callbacks.error,
                    data: data
                });
            },
            getChanges = function(callbacks, data) {
                return amplify.request({
                    resourceId: "get-changes",
                    success: callbacks.success,
                    error: callbacks.error,
                    data: data
                });
            },

            downloadableGetChanges = function (callbacks, data) {
                return amplify.request({
                    resourceId: "downloadable-get-changes",
                    success: callbacks.success,
                    error: callbacks.error,
                    data: data
                });
            },

            updateChanges = function(callbacks, data) {
                return amplify.request({
                    resourceId: "update-changes",
                    success: callbacks.success,
                    error: callbacks.error,
                    data: data
                });
            },
            
            getEmbedGuid = function (callbacks, data) {
                return amplify.request({
                    resourceId: "get-embded-guid",
                    success: callbacks.success,
                    error: callbacks.error,
                    data: data
                });
            },
            
            generateEmbedGuid = function (callbacks, data) {
                return amplify.request({
                    resourceId: "generate-embded-guid",
                    success: callbacks.success,
                    error: callbacks.error,
                    data: data
                });
            },
            
            getOutputDocument = function (callbacks, data) {
                return amplify.request({
                    resourceId: "output-document",
                    success: callbacks.success,
                    error: callbacks.error,
                    data: data
                });
            },
            
            getDocumentDetails = function(callbacks, data) {
                return amplify.request({
                    resourceId: "document-details",
                    success: callbacks.success,
                    error: callbacks.error,
                    data: data
                });
            };

        init();

        return {
            compare: compare,
            getChanges: getChanges,
            downloadableGetChanges: downloadableGetChanges,
            updateChanges: updateChanges,
            getDocumentDetails: getDocumentDetails,
            getOutputDocument: getOutputDocument,
            getEmbedGuid: getEmbedGuid,
            generateEmbedGuid: generateEmbedGuid
        };
    });