
jSaaspose.PortalService = function (applicationPath, useHttpHandlers) {
    this._init(applicationPath, useHttpHandlers);
};

$.extend(jSaaspose.PortalService.prototype, {
    _urlSuffix: "",
    _lastError: null,
    _service: null,
    _cacheTimeout: 300,
    applicationPath: null,
    useJSONP: false,
    _init: function (applicationPath, useHttpHandlers) {
        this.applicationPath = applicationPath;
        if (useHttpHandlers)
            this._urlSuffix = "";
        if ($.browser.msie)
            this.useJSONP = true;
    },

    viewEmbedDocumentAllAsync: function (userId, privateKey, guid, width, quality, usePdf, preloadPagesCount, password, fileDisplayName, successCallback, errorCallback, useCache) {
        var data = JSON.stringify({ userId: userId, privateKey: privateKey, path: guid, width: width, quality: quality, usePdf: usePdf, preloadPagesCount: preloadPagesCount, password: password, fileDisplayName: fileDisplayName });
        this._runServiceAsync("document-viewer/" + 'ViewDocument' + this._urlSuffix, data, successCallback, errorCallback, useCache != null ? useCache : false);
    },

    getPdf2XmlSync: function (userId, privateKey, guid) {
        var data = JSON.stringify({ userId: userId, privateKey: privateKey, guid: guid });
        return this._runServiceSync(this.applicationPath + 'document-viewer/GetPdf2Xml' + this._urlSuffix, data, false);
    },

    getPdf2XmlAsync: function (userId, privateKey, guid, successCallback, errorCallback) {
        var data = JSON.stringify({ userId: userId, privateKey: privateKey, guid: guid });
        return this._runServiceAsync(this.applicationPath + 'document-viewer/GetPdf2Xml' + this._urlSuffix, data, successCallback, errorCallback, false, true);
    },

    getImageUrlsAsync: function (userId, privateKey, guid, dimension, token, firstPage, pageCount, quality, usePdf, docVersion,
                                 watermarkText, watermarkColor, watermarkPosition, watermarkSize,
								 ignoreDocumentAbsence,
								 useHtmlBasedEngine,
                                 supportPageRotation, successCallback, errorCallback) {
        var data = JSON.stringify({
            userId: userId,
            privateKey: privateKey,
        	/*guid: guid,*/
            path: guid,
            width: 150,
            dimension: dimension,
            token: token,
            firstPage: firstPage,
            pageCount: pageCount,
            quality: quality,
            usePdf: usePdf,
            docVersion: docVersion,
            watermarkText: watermarkText,
            watermarkColor: watermarkColor,
            watermarkPosition: watermarkPosition,
            watermarkSize: watermarkSize,
            ignoreDocumentAbsence: ignoreDocumentAbsence,
            useHtmlBasedEngine: useHtmlBasedEngine,
            supportPageRotation: supportPageRotation
        });
        return this._runServiceAsync(this.applicationPath + 'GetImageUrls' + this._urlSuffix, data, successCallback, errorCallback, false);
    },

    loadFileBrowserTreeData: function (userId, privateKey, path, pageIndex, pageSize, orderBy, orderAsc, filter, fileTypes, extended, successCallback, errorCallback, useCache) {
        var data = JSON.stringify({
            userId: userId,
            privateKey: privateKey,
            path: path,
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: orderBy,
            orderAsc: orderAsc,
            filter: filter,
            fileTypes: fileTypes,
            extended: extended
        });
        return this._runServiceAsync(this.applicationPath + 'document-viewer/LoadFileBrowserTreeData' + this._urlSuffix, data, successCallback, errorCallback, useCache != null ? useCache : false);
    },

    _runServiceSync: function (url, data, useCache) {
        var r = null;
        var serviceCallEnded = false;
        var successCallback = function (response) {
            serviceCallEnded = true;
            r = response.data;
        };
        this._runService(url, data, false, successCallback, null, useCache);
        return r;
    },

    _runServiceAsync: function (url, data, successCallback, errorCallback, useCache, convertToXml) {
        return this._runService(url, data, true, successCallback, errorCallback, useCache, convertToXml);
    },

    _runService: function (url, data, mode, successCallback, errorCallback, useCache, convertToXml) {
        var cacher = Container.Resolve("Cacher");
        if (useCache) {
            var cacheItem = cacher.get(url + data);
            if (cacheItem) {
                cacheItem.value.Subscribe(function (response) {
                    this._successHandler(response, successCallback);
                } .bind(this), function (ex) { this._errorHandler(ex, errorCallback, false); } .bind(this));
                return cacheItem.value;
            }
        }
        var requestObservable = Container.Resolve("RequestObservable")({
            url: url,
            type: this.useJSONP ? "GET" : "POST",
            contentType: "application/json; charset=utf-8",
            dataType: this.useJSONP ? "jsonp" + (convertToXml ? " xml" : "") : null,
            data: this.useJSONP ? ("data=" + data.toString()) : data,
            async: mode
        });
        var finalHandler = Container.Resolve("AsyncSubject");
        requestObservable.Finally = function (method) {
            finalHandler.Subscribe(method);
        };
        requestObservable.Subscribe(
            function (response) {
                this._successHandler(response, successCallback);
                finalHandler.OnNext();
                finalHandler.OnCompleted();
            } .bind(this),
            function (ex) {
                this._errorHandler(ex, errorCallback, false);
                finalHandler.OnNext();
                finalHandler.OnCompleted();
            } .bind(this));
        cacher.add(url + data, requestObservable, this._cacheTimeout);
        return requestObservable;
    },

    _errorHandler: function (ex, errorCallback, alertError) {
        if (ex.xmlHttpRequest.readyState == 0) {
            return;
        }

        if (ex.xmlHttpRequest.status == 401) {
            window.location = Container.Resolve("HttpProvider").buildUrl("/", "sign-in", { 'returnUrl': window.location.href });
            return;
        }

        var error;
        var errorCode = 0;
        if (ex.xmlHttpRequest.responseText != '') {
            var msg = '';
            try {
                error = eval('(' + ex.xmlHttpRequest.responseText + ')');
            }
            catch (e) {
                error = { Reason: ex.xmlHttpRequest.responseText };
            }
            errorCode = 500;
        }
        else {
            errorCode = 404;
            error = { Reason: 'Service link is not found' };
        }

        if (this._lastError != 404 && alertError) {
            this._lastError = errorCode;
            if (errorCode == 404) {
                jerror(error.Reason);
            }
            else {
                jerror();
            }
        }

        try {
            if (errorCallback) {
                errorCallback(error);
            }
        }
        catch (e) { }
    },
    _successHandler: function (response, successCallback) {
        if (successCallback) {
            if (response.xmlHttpRequest.responseText == '') {
                response.data = null;
            }

            successCallback(response);
        }
    }
});

