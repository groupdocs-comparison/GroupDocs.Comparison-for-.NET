define("core/vm/vm.viewer",
    ["jquery",
        "ko",
        "core/config",
        "comparison-settings"
    ],
    function ($, ko, config, settings) {
        var options = function() {
                return {
                    fileId: "", //"1894d24eb4dc96ff36f5eee7e4d480b6c1fd43e2bf5497b656c6beb25728b460",
                    privateKey: ViewContext.Credentials.privateKey,
                    baseUrl: ViewContext.Credentials.serviceAddress + "/shared/",
                    quality: 90,
                    use_pdf: "false",
                    pageContentType: "image",
                    docSpace: $("#doc_viewer"),
                    navigation: $("#viewer-navigation"),
                    //search: $('#searchElement'),
                    //zooming: $('#viewer-zoom'),
                    thumbnails: $("#thumbnails-container"),
                    thumbnailsSlider: $("#thumbs_btn"),
                    selectionContent: $("#selection-content"),
                    serviceUrl: ViewContext.Credentials.serviceAddress,
                    thumbsImageBase64Encoded: settings.thumbsImageBase64Encoded,
                    usePageNumberInUrlHash: false,
                    _mode: settings.mode,
                    variableHeightPageSupport: false,
                    thumbnailsOptions: {
                        thumbnailWidth: 150,
                        _mode: 'webComponent'
                    }
                };
            },
            viewerAdapter = null,
            visible = ko.observable(),
            type = ko.observable("normal"),
            
            normalVisible = ko.computed(function() {
                return visible() && type() === "normal";
            }),

            svgVisible = ko.computed(function () {
                return visible() && type() === "svg";
            }),

            adapter = function() {
                if (viewerAdapter == null) {
                    viewerAdapter = new DocViewerAdapter(options());
                    viewerAdapter.docViewerWidget = viewerAdapter.docSpace;


                    viewerAdapter.docViewerWidget.bind("_onProcessPages", function(e, response) {
                        var model = viewerAdapter.docViewerViewModel;
                        var width = 0;
                        var height = 0;
                        if (typeof (response.page_size.Width) != "undefined") {
                            width = response.page_size.Width;
                            height = response.page_size.Height;
                        } else if (typeof (response.documentDescription) != "undefined") {
                            var documentDescription = JSON.parse(response.documentDescription);
                            width = documentDescription.widthForMaxHeight;
                            height = documentDescription.maxPageHeight;
                        } 
                        
                        model.heightWidthRatio = parseFloat(height / width);
                        model.pageHeight(Math.round(model.pageImageWidth * model.heightWidthRatio * (model.initialZoom / 100)));
                        model.originalPageWidth = width;
                        model.originalPageHeight = height;
                    });

                    viewerAdapter.docViewerViewModel.initialZoom = (($("#comparison_doc_viewer").width() - 2 * viewerAdapter.docViewerViewModel.imageHorizontalMargin - 20) / viewerAdapter.docViewerViewModel.initialWidth * 100);
                    viewerAdapter.docViewerViewModel.scale(viewerAdapter.docViewerViewModel.initialZoom / 100);

                    visible.subscribe(function (value) {
                        if (type() !== "normal") return;
                        var speed = value ? "slow" : null;
                        options().docSpace.toggle(value, speed);
                        if (!value) options().thumbnails.toggle(value, speed);
                        options().thumbnailsSlider.toggle(value, speed);
                        if (value) options().thumbnailsSlider.addClass("thumbs_btn_slide").removeClass("thumbs_btn_slide", 1);
                    });
                }
                return viewerAdapter;
            },

            loadSvgDocument = function (docGuid) {
                type("svg");
                return $.Deferred(function (def) {
                    var opt = options();
                    $.get(opt.baseUrl + "files/" + docGuid, function (data) {
                        def.resolve();
                    });
                }).promise();
            };


        return {
            adapter: adapter,
            visible: visible,
            normalVisible: normalVisible,
            svgVisible: svgVisible,
            type: type,
            loadSvgDocument: loadSvgDocument,
        };
    });