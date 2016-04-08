(function($) {
    $.widget("ui.groupdocsComparison", {
        options: {
            servicePrefix: '',
            context: '',
            immediateCompare: false,
            resultFileName: '',
            changes: []
        },
        
        _htmlCreated: false,

        on: function (eventName, handler) {
            $(this.element).on(eventName, handler);
        },

        off: function (eventName, handler) {
            $(this.element).off(eventName, handler);
        },

        _create: function () {
            if (this.options.immediateCompare)
                this._loadResults(this.options.resultFileName, this.options.changes);
        },

        _createHtml: function () {
            var self = this;
            if (self._htmlCreated) return;
            $(self.element).html(
                "<header class='embeded_header  comparison-content header_sidescroll' style='height: 43px;' data-bind='localize: true'> \
                     <div data-bind='visible: viewer.visible' style='display:none;'> \
                         <!-- ko stopBindings: true --> \
                         <div id='viewer-navigation' class='page_select' data-bind=\"template: 'widgets/document-navigation'\"> \
                         </div> \
                         <!-- /ko --> \
                     </div> \
                     \
                     <!-- ko stopBindings: true --> \
                     <div class='embed_zoom' style='display: none' data-bind=\"template: 'widgets/document-zoom'\"> \
                     </div> \
                     <!-- /ko --> \
                     \
                     <div id='redline-toolbox' data-bind=\"template: { name: 'widgets/diff-navigator', data:diffNavigator }, visible: diffNavigator.visible\" style='display:none;'> \
                     </div> \
                 </header> \
                 \
                 <div id='viewer_mainwrapper' class='viewer_mainwrapper' style='top: 45px;'> \
                     <div class='wrapper' style='overflow: hidden; padding: 0 15px;'> \
                         <div class='comparison-content'> \
                             <!-- ko with: viewer --> \
                             <a id='thumbs_btn' class='thumbs_btn' href='#' data-bind=\"toggle: '.thumbnailsContainer', visible: visible\" style='display:none;'></a> \
                             \
                             <div id='comparison_doc_viewer' class='comparison_viewer_wrapper' style='bottom: 35px; visibility: hidden'> \
                                 <!-- ko template: 'widgets/document-thumbnails' --><!-- /ko --> \
                                 <!-- ko template: 'widgets/document-viewer' --><!-- /ko --> \
                             </div> \
                             <!-- /ko --> \
                             <!-- ko template: { name: 'widgets/diff-explorer', data: diffNavigator } --> \
                             <!-- /ko --> \
                         </div> \
                     </div> \
                     <footer class='footer_sidescroll'> \
                         <!--<p class='footpowered'><span data-localize='PoweredBy'></span>:</p> \
                         <a class='footlogo' href='https://groupdocs.com'>&nbsp;</a>--> \
                     </footer> \
                 </div>");

            self.on("onDocumentLoadComplete", function (event, data) {
                if (!data.lic) {
                    var viewerMainWrapper = $(self.element).find(".viewer_mainwrapper");
                    $(viewerMainWrapper).css("top", "77px");
                    var licElement = $("<div/>");
                    $(licElement).addClass("banner_trial").css("top", "45px");
                    $(licElement).html("This viewer has been created using an unlicensed version of " +
                        "<a href='http://groupdocs.com' target='_blank'>GroupDocs.Comparison</a> for .NET ");
                    $(licElement).insertBefore(viewerMainWrapper);
                };
            });

            this._htmlCreated = true;
        },
        
        _loadResults: function (fileName, changes) {
            var self = this;
            self._createHtml();

            require(["redline"], function(redline) {
                redline.init();
                redline.loadResults(fileName, { ResultFileId: '', Changes: changes });
            });
        },

        _comparisonCompleted: function() {
            $(this.element).trigger("completed");
        },

        performCompare: function () {
            var self = this;
            var url = this.options.servicePrefix + "/comparison2/compare?contextId=" + this.options.context;
            var resultFileName = this.options.resultFileName;
            $.ajax({
                url: url,
                dataType: "json",
                success: function (changes) {
                    self._comparisonCompleted();
                    self._loadResults(resultFileName, changes);
                }
            });
        }
    });
})(jQuery)