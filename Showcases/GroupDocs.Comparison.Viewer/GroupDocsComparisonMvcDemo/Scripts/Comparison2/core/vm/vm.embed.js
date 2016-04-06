define("core/vm/vm.embed",
    ["jquery",
        "ko",
        "lib/underscore",
        "core/config",
        "core/repository"
    ],
    function($, ko, _, config,  repository) {
        var documentId = ko.observable(""),
                visible = ko.computed(function () {
                return documentId() !== "";
        }),
        popup = $(config.embedDialogId),
        
        guid = ko.observable(""),
        frameWidth = ko.observable(1200),
        frameHeight = ko.observable(600),

        embedUrl = ko.computed(function () {
            return config.appPath + "document-comparison2/embed/" + guid() + "/" + documentId();
        }),
            
        iframeSource = ko.computed(function () {
            return "<iframe src=" + "\"" + embedUrl() + "\"" + " frameborder=" + "\"" + 0 + "\"" + " width=" + "\"" + frameWidth() + "\"" + " height=" + "\"" + frameHeight() + "\"" + "></iframe>";
        }),

        showPopup = function() {
            popup.modal("show");
        },
        setGuid = function (data) {
            guid(data);
        },
        generateNewUrl = function () {
            repository.compare.generateEmbedGuid(setGuid);
        },
         
        init = function () {
            visible.subscribe(function (value) {
                if (!value && guid() !== "") return;
                repository.compare.getEmbedGuid(setGuid);
            });
        };

        init();

        var result = {
            visible: visible,
            documentId: documentId,
            embedUrl:embedUrl,
            showPopup: showPopup,
            generateNewUrl: generateNewUrl,
            frameWidth: frameWidth,
            frameHeight: frameHeight,
            iframeSource: iframeSource
        };

        return result;
    });