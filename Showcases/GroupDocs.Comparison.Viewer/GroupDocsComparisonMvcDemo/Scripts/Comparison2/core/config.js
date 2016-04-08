define("core/config",
    ["ko"],
    function (ko) {
        var privateKey = "",
            appPath = "",
            uploaderProxy = "",
            openfileDialogId = "#openfile-dialog",
            embedDialogId = "#embedComparisonDialog",
            isDownloadable = false,
            useHttpHandlers = false,
            downloadableComparisonPrefix = "",
            downloadableSettings = {
                resultFileName: "",
                changes: []
            },
            templateUrl = "/scripts/comparison2/views",
            comparisonAction = {
                none: "None",
                accept: "Accept",
                reject: "Reject"
            },
            changeType = {
                copy: "Copy",
                insert: "Inserted",
                "delete": "Deleted",
                styleChange: "StyleChanged"
            },
            initInfUser = function () {
                var downloadablePrefix = "";
                if (isDownloadable) {
                    downloadablePrefix = downloadableComparisonPrefix + (useHttpHandlers ? "-handler" : "/embedded");
                }
                infuser.defaults.templateUrl = downloadablePrefix + templateUrl;
                //console.log(infuser.defaults.templateUrl);
                infuser.defaults.ajax.async = false;
            },
            init = function () {
                if ((typeof (gdComparisonPrefix) != "undefined") && gdComparisonPrefix) {
                    isDownloadable = true;
                    useHttpHandlers = (typeof (gdUseHttpHandlers) != "undefined" && gdUseHttpHandlers);
                    downloadableComparisonPrefix = gdComparisonPrefix;
                } else downloadableComparisonPrefix = "";
                initInfUser();
                
                privateKey = ViewContext.Credentials.privateKey;
                appPath = ViewContext.AppPath;
                uploaderProxy = "Uploader.aspx";
            },
            alert = function (type, message) {
                if (typeof (type) == "string") jerror(message);
                else if (typeof(type) == "object") {
                    jerror(type.message, type.handler, type.title);
                }
            },
            validationMessages = {
                required: "* Required",
                invalidEmail: "Please enter valid email address"
            };

        init();

        return {
            privateKey: privateKey,
            appPath: appPath,
            uploaderProxy: uploaderProxy,
            alert: alert,
            validationMessages: validationMessages,
            openfileDialogId: openfileDialogId,
            embedDialogId: embedDialogId,
            templateUrl: templateUrl,
            downloadableComparisonPrefix: downloadableComparisonPrefix,
            isDownloadable: isDownloadable,
            downloadableSettings: downloadableSettings,
            comparisonAction: comparisonAction,
            changeType: changeType
        };
    });