define("core/vm/vm.progress",
    ["jquery",
        "ko",
        "lib/underscore",
        "core/config"
    ],
    function ($, ko) {
        var visible = ko.observable(false),
            completed = ko.observable(false),
            progress = ko.observable(0),
            error = ko.observable(""),
            
            updateStatus = function(data) {
                switch (data.status) {
                    case "JobStarted":
                        progress(0);
                        completed(false);
                        visible(true);
                        error("");
                        break;
                    case "JobProgress":
                        progress(data.progress+"%");
                        break;
                    case "JobCompleted":
                        completed(true);
                        break;
                    case "JobFailed":
                        error("Sorry, the comparison is failed. A notification has been sent to the GroupDocs Support Team.");
                        break;
                }
            },
            
            init = function () {
            };

        init();

        return {
            visible: visible,
            updateStatus: updateStatus,
            error: error,
            completed: completed,
            progress: progress
        };
    });