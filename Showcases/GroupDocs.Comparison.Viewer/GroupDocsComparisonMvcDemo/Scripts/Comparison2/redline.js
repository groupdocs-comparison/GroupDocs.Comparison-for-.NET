define("redline",
    ["jquery",
        "core/config",
        "comparison-settings",
        "core/binder",
        "core/vm",
        "core/repository"],
    function($, config, settings, binder, vm, repository) {
        var comparisonHub = null,
            jobId = "",
            downloadableChanges = null,
            bindViewModels = function() {
                binder.bind(".comparison-content", vm);
            },
            outputDocument = function(docGuid, docType) {
                if (settings.mode !== "embed") {
                    vm.embed.documentId(docGuid);
                }

                if (docType === "svg") {
                    vm.viewer.loadSvgDocument(docGuid).then(function(doc) {
                        $("#doc_viewer").hide();
                        vm.viewer.visible(true);
                        vm.progress.visible(false);
                        vm.selector.running(false);
                        vm.selector.completed(true);
                    });
                } else {
                    vm.viewer.type("normal");
                    vm.viewer.adapter().docViewerViewModel.loadDocument(docGuid);
                }

                $("#comparison_doc_viewer").css("visibility", "visible");
            },
            resetInitialState = function() {
                vm.viewer.visible(false);
                vm.diffNavigator.resetInitialState();
                vm.selector.resetInitialState();
                vm.embed.documentId("");
            },
            comparisonStarted = function(id) {
                jobId = id;
                vm.progress.progress(0);
                vm.progress.visible(true);
            },
            errorHandler = function(value) {
                if (value === "") return;
                if (vm.progress.visible()) vm.progress.visible(false);
                config.alert({ title: "Notification", message: value });
            },
            startComparison = function() {
                repository.compare.startComparison(vm.selector.sessionId(), vm.selector.sourceFileId(), vm.selector.targetFileId(), comparisonStarted, errorHandler);
            },
            completedComparison = function(value) {
                if (!value) return;
                if (!jobId) return;
                repository.compare.getOutputDocument(jobId, function(doc) {
                    outputDocument(doc.guid, doc.type);
                }, errorHandler);
            },
            loadResults = function(resultFileName, changes) {
                downloadableChanges = changes;
                vm.viewer.adapter().docViewerViewModel.loadDocument(resultFileName);
            },
            initViewModels = function() {
                resetInitialState();

                vm.selector.error.subscribe(errorHandler);
                vm.selector.sessionId(settings.sessionId);
                vm.selector.setStartHandler(startComparison);
                vm.selector.completed.subscribe(function(value) {
                    if (value) return;
                    resetInitialState();
                });

                vm.viewer.adapter().docViewerViewModel.diffNavigator = vm.diffNavigator;
                vm.viewer.adapter().docViewerWidget.bind("onDocumentLoadComplete", function(e, data) {
                    if (config.isDownloadable) {
                        $("#comparison_doc_viewer").css("visibility", "visible");
                        vm.diffNavigator.setChanges(downloadableChanges);
                    } else {
                        vm.diffNavigator.loadChanges(data.guid);
                    }

                    if (settings.thumbsImageBase64Encoded != null) {
                        var thumbsButton = $("#thumbs_btn");
                        thumbsButton.css("z-index", "50");
                    }

                    vm.viewer.visible(true);

                    vm.progress.visible(false);
                });

                vm.progress.error.subscribe(function(value) {
                    if (value === "") return;
                    errorHandler(value);
                    resetInitialState();
                });
                vm.progress.completed.subscribe(completedComparison);

                vm.diffNavigator.afterChangesApplied.subscribe(function(docGuid) {
                    if (docGuid == null) return;
                    vm.viewer.visible(false);
                    vm.diffNavigator.resetInitialState();
                    if (!config.isDownloadable) {
                        vm.embed.documentId("");
                        outputDocument(docGuid);
                    } else {
                        repository.compare.downloadableGetChanges(docGuid, function(data) {
                            loadResults(data.ResultFileName, data);
                        });
                    }
                });
                vm.diffNavigator.error.subscribe(errorHandler);
                vm.diffNavigator.data.subscribe(function(value) {
                    if (value == null) return;
                    _.each(value.changes(), function (c) {
                        if (!c.page()) return;
                        var pageId = c.page().Id;
                        var pageWidth = c.page().Width;
                        var pageHeight = c.page().Height;

                        var page = $("#doc_viewer-page-" + pageId);
                        var pageImage = $(".page-image", page);
                        if (page.length === 0 || pageImage.length === 0) return;

                        var imageWidth = vm.viewer.adapter().docViewerViewModel.pageWidth();
                        var imageHeight = vm.viewer.adapter().docViewerViewModel.pageHeight();
                      //  var imageHeight = imageWidth / pageWidth * pageHeight;
                        var imageOffset = pageImage.offset();
                        var pageOffset = page.offset();
                        var leftPadding = imageOffset.left - pageOffset.left;
                        var topPadding = imageOffset.top - pageOffset.top;

                        if (!c.box()) return;
                        var x = c.box().X;
                        var l = Math.round(((imageWidth / pageWidth) * x) + leftPadding);

                        var y = pageHeight - c.box().Y;
                        var t = Math.round(((imageHeight / pageHeight) * y) + topPadding);

                        c.width(10);
                        c.height(10);
                        c.left(l - 10);
                        c.top(t - 10 * pageId);
                    });
                    vm.selector.completed(true);
                    vm.selector.running(false);

                    $(".summary_pane").hide();
                    $("ul.com_side_summary_tabs li:first").addClass("active").show().find("label input:radio").attr("checked", ""); //Activate first tab                 
                    $(".summary_pane:first").show();
                    $("body").on("click", "ul.com_side_summary_tabs li", function() {
                        $("ul.com_side_summary_tabs li").removeClass("active");
                        $("ul.com_side_summary_tabs li").find("label input:radio").attr("checked", "");
                        $(this).addClass("active").find("label input:radio").attr("checked", "checked");
                        $(".summary_pane").hide();
                        var activeTab = $(this).find("label input:radio").val();
                        $("#" + activeTab).show();
                    });
                });
            },

            initHub = function() {
                if (typeof($.connection) == "undefined") return;
                comparisonHub = $.connection.comparisonHub.client;
                comparisonHub.updateStatus = function(data) {
                    vm.progress.updateStatus(data);
                };

                $.connection.hub.start()
                    .done(function() {
                        $.connection.comparisonHub.server.setGuidForConnection(settings.sessionId);
                    });
            },
            localizeElements= function() {
                var localizedStrings = settings.localization;
                if (localizedStrings != null) {
                    this.element.find("[data-localize],[data-localize-ph],[data-localize-tooltip]").each(function () {
                        var that = $(this);
                        var localizationKey = that.attr("data-localize");
                        var localizationTextValue;
                        if (localizationKey) {
                            localizationTextValue = localizedStrings[localizationKey];
                            that.text(localizationTextValue);
                        }
                        localizationKey = that.attr("data-localize-ph");
                        if (localizationKey) {
                            localizationTextValue = localizedStrings[localizationKey];
                            that.attr("placeholder", localizationTextValue);
                        }
                        localizationKey = that.attr("data-localize-tooltip");
                        if (localizationKey) {
                            localizationTextValue = localizedStrings[localizationKey];
                            that.attr("data-tooltip", localizationTextValue);
                        }
                    });
                }
            },

            initUi = function() {
                //localizeElements();
                $("[rel='tooltip']").tooltip();

                function initresizefunction() {
                    $(".comparison_viewer_wrapper").css({ 'width': (($(window).width()) - 36) + "px" });
                }

                $(document).ready(initresizefunction);

                var winWidth = $(window).width();

                function resizing() {
                    $(".comparison_sidebar.expanded").resizable({
                        handles: "w",
                        maxWidth: 500,
                        minWidth: 310,
                        resize: function() {
                            $(".comparison_viewer_wrapper").width(winWidth - $(".comparison_sidebar").width() - 1);
                        }
                    });
                }

                $(document).ready(resizing);
                $(window).resize(resizing);


                $("body").on("click", ".sidebar_toggle_btn", function() {
                    if ($(".comparison_sidebar").hasClass("expanded")) {
                        $(".comparison_sidebar.expanded").resizable("destroy");
                        $(".comparison_sidebar.expanded").attr("style", "");
                    };
                    $(".comparison_sidebar").toggleClass("collapsed expanded");
                    resizing();
                    resizing("destroy");
                    $(this).toggleClass("collapsed_toggle_icon expanded_toggle_icon");
                    $(".comparison_viewer_wrapper").width(winWidth - $(".comparison_sidebar").width() - 1);
                    $("#comparison_sidebarcont_collapsed").toggle();
                    $("#comparison_sidebarcont_expanded").toggle();

                });
                $("body").on("click", ".changes_line_wrapper", function() {
                    $(this).find(".small_pointer").toggleClass("down");
                    $(this).next(".change_sublist").toggle("blind", "fast");
                    return false;
                });

                $("html").click(function() {
                    $(".dropdown-menu").slideUp("fast").removeClass("active");
                });

                $("#viewer_mainwrapper").removeClass("mainwrap_sidescroll");
            },
            init = function () {
                $(document).ready(initUi);
                bindViewModels();
                initViewModels();
                initHub();

                if (settings.sourceFileId !== "") {
                    vm.selector.setSourceGuid(settings.sourceFileId);
                    if (settings.targetFileId === "") {
                        vm.selector.selectTarget();
                    }
                }

                if (settings.targetFileId !== "") {
                    vm.selector.setTargetGuid(settings.targetFileId);
                }

                if (settings.resultFileId !== "") {
                    if (!config.isDownloadable) {
                        repository.compare.getDocumentDetails(settings.resultFileId).then(function(data) {
                            outputDocument(data.Guid, data.Supported ? "normal" : "svg");
                        });
                    } else {
                        vm.diffNavigator.setDocumentId(settings.resultFileId);

                    }
                }
            },        
            create = function() {
                if (config.isDownloadable) return;
                init();
            };

        return {
            vm: vm,
            repository: repository,
            loadResults: loadResults,
            init: init,
            create: create
        };
    });

require(["redline"], function(app) {
    app.create();
});