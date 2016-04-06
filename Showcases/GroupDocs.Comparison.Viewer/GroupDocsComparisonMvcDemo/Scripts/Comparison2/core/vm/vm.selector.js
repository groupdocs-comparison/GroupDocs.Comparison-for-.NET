define("core/vm/vm.selector",
    ["jquery",
        "ko",
        "lib/underscore",
        "core/config",
        "comparison-settings",
        "core/repository/repository.compare"
        ],
    function ($, ko, _, config, settings, repository) {
        var ready = ko.observable(false),
            fileDialogOpened = false,
            
            compare = function() {
            },

            setStartHandler = function (handler) {
                compare = handler;
            },

            completed = ko.observable(false),
            running = ko.observable(false),
            enabled = ko.computed(function() {
                return !running();
            }),
            
            enableCompare = ko.computed(function () {
                return ready() && !completed() && !running();
            }),
            
            popup = $(config.openfileDialogId),
            
            error = ko.observable(""),
            sessionId = ko.observable(""),
            sourceFileId= ko.observable(""),
            targetFileId = ko.observable(""),
            defaultSourceName = "Select Source",
            defaultTargetName = "Select Target",
            sourceName= ko.observable(defaultSourceName),
            targetName= ko.observable(defaultTargetName),
            supported = ["doc", "docx", "docm", "dot", "dotm", "dotx", "rtf", "odt", "ods", "ott", "txt",
                         "xls", "xlsx", "xlsm", "xlsb", "csv",
                         "ppt", "pptx", "pdf",
                         "htm", "html"],

           getExtension = function (fileName) {
               return fileName.split(".").pop().toLowerCase();
           },

            isSupported = function (fileName) {
                var extension = getExtension(fileName);
                var inArray = ($.inArray(extension, supported) > -1);
                return inArray;
            },

            isTheSameType = function (sourceFile, targetFile) {
                var sourceType = getExtension(sourceFile);
                var targetType = getExtension(targetFile);

                if (sourceType !== targetType) {
                    error("Source and target file should be of same type");
                    return false;
                }
                return true;
            },

            resetInitialState = function() {
                sourceFileId("");
                targetFileId("");
                sourceName(defaultSourceName);
                targetName(defaultTargetName);
                completed(false);
                ready(false);
                running(false);
            },
            
            confirmStartOver = function () {
                if (running()) return false;
                if (completed()) {
                    $.confirm({
                        title: "Confirmation",
                        message: "There is active comparison currently. Do you want to start over?",
                        buttons: {
                            Yes: {
                                'action': function() {
                                    resetInitialState();
                                }
                            },
                            No: {}
                        }
                    });
                   return false;
                }
                return null;
            },

            updateReadyToCompare = function () {
                var sourceIsReady = (sourceFileId() !== "");
                var targetIsReady = (targetFileId() !== "");
                var result = sourceIsReady && targetIsReady;
                ready(result);
            },

            setNewFile = function (type, guid, fileName) {
                error("");
                if (type === "source") {
                    sourceName(fileName);
                    sourceFileId(guid);
                } else if (type === "target") {
                    targetName(fileName);
                    targetFileId(guid);
                } else {
                    error("Unknown file type: " + type);
                }
                updateReadyToCompare();
            },

            
            
            selectSource = function () {
                if (fileDialogOpened || confirmStartOver()===false) return;

                fileDialogOpened = true;
                popup.data("type", "source");
                popup.data("fileId", sourceFileId);
                popup.modal("show");
            },

            setSourceGuid = function(guid) {
                repository.getDocumentDetails(guid).done(function(data) {
                    setNewFile("source", guid, data.Name);
                });
            },

            selectTarget = function () {
                if (fileDialogOpened || confirmStartOver() === false) return;

                fileDialogOpened = true;
                popup.data("type", "target");
                popup.data("fileId", targetFileId);
                popup.modal("show");
            },

            setTargetGuid = function (guid) {
                repository.getDocumentDetails(guid).done(function (data) {
                    setNewFile("target", guid, data.Name);
                });
            },
            
            startComparison = function () {
                if (!enabled()) return;
                error("");
                if (confirmStartOver() !== null) return;
                
                if (!enableCompare()) {
                    error("Please select source and target document");
                    return;
                }
                
                if (!isTheSameType(sourceName(), targetName())) return;


                
                var sourceSupported = isSupported(sourceName());
                if (!sourceSupported) {
                    error("Selected source document format is not supported.");
                    return;
                }

                var targetSupported = isSupported(targetName());
                if (!targetSupported) {
                    error("Selected target document format is not supported.");
                    return;
                }

                running(true);
                compare();
            },
            
            init = function () {
                popup.bind("fileSelected", function(e, metadata) {
                    var type = popup.data("type");
                    setNewFile(type, metadata.guid, metadata.name());
                }).bind("hide.bs.modal", function() {
                    fileDialogOpened = false;
                });
            };
        
        init();
        
        return {
            enabled: enabled,
            ready: ready,
            running: running,
            completed: completed,
            enableCompare: enableCompare,
            error: error,
            setStartHandler: setStartHandler,
            
            sourceName: sourceName,
            targetName: targetName,
            sourceFileId: sourceFileId,
            targetFileId: targetFileId,
            sessionId: sessionId,
            
            selectSource: selectSource,
            setSourceGuid: setSourceGuid,
            selectTarget: selectTarget,
            setTargetGuid: setTargetGuid,
            startComparison: startComparison,
            
            resetInitialState: resetInitialState
        };
    });