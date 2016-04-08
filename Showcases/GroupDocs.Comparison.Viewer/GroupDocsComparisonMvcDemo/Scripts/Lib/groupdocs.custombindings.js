; (function (ko, $) {
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };
    $.fn.reverse = [].reverse;
    ko.bindingHandlers.modal = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            var allBindings = allBindingsAccessor();
            var $element = $(element);
            $element.addClass('hide modal');

            $element.on('show', function() {
                $("html").css("overflow","hidden");
            }).on("hide", function () {
                $("html").css("overflow","");
                return true;
            });
            
            if (allBindings.modalOptions) {
                if (allBindings.modalOptions.beforeShow) {
                    $element.on('show', function () {
                        return allBindings.modalOptions.beforeShow();
                    });
                }
                if (allBindings.modalOptions.beforeClose) {
                    $element.on('hide', function () {
                        return allBindings.modalOptions.beforeClose();
                    });
                }
                if (allBindings.modalOptions.afterShow) {
                    $element.on('shown', function () {
                        return allBindings.modalOptions.afterShow();
                    });
                }
            }
        },
        update: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            if (value) {
                $(element).modal('show');
            } else {
                $(element).modal('hide');
            }
        }
    };
    
    ko.bindingHandlers.tooltip = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            $(element).tooltip();
        }
    };
    ko.bindingHandlers.jqTabs = {
        init: function (element, valueAccessor) {
            var options = valueAccessor() || {};
            setTimeout(function () { $(element).tabs(options); }, 0);
        }
    };
    ko.bindingHandlers.toggle = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var $element = $(element);
            
            $element.click(function() {
                var value = valueAccessor();
                $element.toggleClass("thumbs_btn_slide", 'slow');
                $(value).toggle('slide', 'slow');
                return false;
            });
        }
    };    
    ko.bindingHandlers.dropdownButton = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            var $element = $(element);
            var selector = ko.utils.unwrapObservable(valueAccessor());
            var buttonSelector = selector + "-button";

            $element.find(buttonSelector).click(function (event) {
                var $button = $(buttonSelector + ".active");
                var $this = $(this);
                var $target = $this.parent().find(selector);
                var clearAllActive = function () {
                    var $el1 = $button.parent().find(selector);
                    if ($el1.is(":visible")) {
                        $el1.hide("blind", "fast");
                    }
                    $button.removeClass("active");
                };

                if ($target.is(":visible") && $this.hasClass("active") ) {
                    clearAllActive();
                } else {
                    clearAllActive();
                    $this.addClass('active');
                    $target.show('blind', 'fast');
                }
                
                $(".toolTip").tooltip('hide');
                return false;
            });
        }
    };
    
    ko.bindingHandlers.stopBindings = {
        init: function () {
            return { controlsDescendantBindings: true };
        }
    };    
    ko.virtualElements.allowedBindings.stopBindings = true;
    
    ko.bindingHandlers.diffMarker = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            $(element).toggle(value);
        },
        update: function (element, valueAccessor, allBindingsAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            var container = allBindingsAccessor().container || document;
            if (!value) {
                $(element).stop(true, true).hide();
            } else {
                $(element).show();
                $(container).scrollTo($(element), 100, { offset: -100 });
                $(element).stop(true, true).effect("pulsate", { times: 3 }, 500, function() {
                    $(element).fadeTo(200, 0.5);
                });
            }
        }
    };

    ko.bindingHandlers.diffType = {
        update: function (element, valueAccessor, allBindingsAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            var $element = $(element);
            switch(value) {
                case "Deleted": //delete
                    $element.addClass("striked");
                    break;
                case "Inserted": //insert
                    $element.addClass("underlined");
                    break;
                case "StyleChanged": //stylechange
                    $element.addClass("double-underlined");
                    break;
            }
        }
    };
    
    ko.bindingHandlers.slideVisible = {
        init: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            $(element).toggle(value);
        },

        update: function (element, valueAccessor, allBindingsAccessor) {
  
            var value = valueAccessor(), allBindings = allBindingsAccessor();
            var valueUnwrapped = ko.utils.unwrapObservable(value);
            var duration = allBindings.slideDuration || 400; // 400ms is default duration unless otherwise specified

            function scrollBarUpdate() {
            }

            if (valueUnwrapped == true)
                $(element).slideDown(duration, scrollBarUpdate); // Make the element visible
            else
                $(element).slideUp(duration, scrollBarUpdate);   // Make the element invisible

        }
    };

    ko.bindingHandlers.calculatePosition = {
        update: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var location = ko.dataFor(element);
            var field = ko.contextFor(element).$parents[1];
            if (location == null || field == null) return;
            var page = $(element).closest(".doc-page");
            var imageOffset = $(".page-image", page).offset();
            var pageOffset = $(page).offset();
            var imageWidth = ko.utils.unwrapObservable(bindingContext.$root.pageWidth);
            var imageHeight = ko.utils.unwrapObservable(bindingContext.$root.pageHeight);
            var leftPadding = imageOffset.left - pageOffset.left;
            var topPadding = imageOffset.top - pageOffset.top;
            var x = Math.round(location.locationX() * imageWidth + leftPadding);
            var y = Math.round(location.locationY() * imageHeight /*+ topPadding*/);
            $(element).css({ left: x + "px", top: y + "px" });
            if (location.locationHeight() != 0) {
                //$(element).css({ height: Math.round(location.locationHeight() * bindingContext.$root.scale()) + 'px' });
                //console.log(location.locationHeight());
                var absoluteHeight = location.locationHeight() / ((bindingContext.$root.originalPageWidth * bindingContext.$root.heightWidthRatio) / (bindingContext.$root.pageImageWidth * bindingContext.$root.heightWidthRatio));
                $(element).css({ height: Math.round(absoluteHeight * bindingContext.$root.scale()) + 'px' });
            } else {
                $(element).css({ height: 'auto' });
            }
            if (bindingContext.$parents[2].viewerAction == 'sign' &&
                field.fieldType() == bindingContext.$parents[2].config.signatureFieldType.Signature &&
                bindingContext.$parents[2].config.checkBrowserForSvgSupport() &&
                field.data() != '' &&
                field.data().indexOf('<text')>0 &&
                field.settings()!=null && field.settings().matchHeight()) {
                var signatureHeight = $($(field.data())[0]).prop("viewBox").baseVal.height;
                var signatureWidth = $($(field.data())[0]).prop("viewBox").baseVal.width / (signatureHeight / $(element).height());
                $(element).css({ width: Math.round(signatureWidth /* * bindingContext.$root.scale()*/) + 'px' });
            } else {
                if (location.locationWidth() != 0) {
                    //$(element).css({ width: Math.round(location.locationWidth() * bindingContext.$root.scale()) + 'px' });
                    var absoluteWidth = location.locationWidth() / (bindingContext.$root.originalPageWidth / bindingContext.$root.pageImageWidth);
                    $(element).css({ width: Math.round(absoluteWidth * bindingContext.$root.scale()) + 'px' });
                } else {
                    $(element).css({ width: 'auto'});
                }
            }
        }
    };

    ko.bindingHandlers.calculateFieldSize = {
        update: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var location = ko.dataFor(element);
            var field = ko.contextFor(element).$parents[1];
            if (location == null || field == null) return;
            if (location.locationHeight() != 0) {
                //$(element).css({ height: Math.round(location.locationHeight() * bindingContext.$root.scale()) + 'px' });
                var absoluteHeight = location.locationHeight() / ((bindingContext.$root.originalPageWidth * bindingContext.$root.heightWidthRatio) / (bindingContext.$root.pageImageWidth * bindingContext.$root.heightWidthRatio));
                $(element).css({ height: Math.round(absoluteHeight * bindingContext.$root.scale()) + 'px' });
            }
            if (!(bindingContext.$parents[2].viewerAction == 'sign' && field.fieldType() == bindingContext.$parents[2].config.signatureFieldType.Signature))
            {
                if (location.locationWidth() != 0) {
                    //$(element).css({ width: Math.round(location.locationWidth() * bindingContext.$root.scale()) + 'px' });
                    var absoluteWidth = location.locationWidth() / (bindingContext.$root.originalPageWidth / bindingContext.$root.pageImageWidth);
                    $(element).css({ width: Math.round(absoluteWidth * bindingContext.$root.scale()) + 'px' });
                }
            }
        }
    };

    ko.bindingHandlers.signatureFieldStyle = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            var allBindings = allBindingsAccessor();

            //$(element).toggle(value);
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var location = ko.utils.unwrapObservable(valueAccessor());
            if (location == null) return;
            var $element = $(element);
            
            $element.css({ padding: '0px' });
            if (location.fontSize()>0)
                $element.css({ fontSize: Math.round(location.fontSize() * bindingContext.$root.scale()) + 'px' });
            if (location.locationHeight() != 0) {
                //$element.css({ height: Math.round(location.locationHeight() * bindingContext.$root.scale()) + 'px' });
                var absoluteHeight = location.locationHeight() / ((bindingContext.$root.originalPageWidth * bindingContext.$root.heightWidthRatio) / (bindingContext.$root.pageImageWidth * bindingContext.$root.heightWidthRatio));
                $element.css({ height: Math.round(absoluteHeight * bindingContext.$root.scale()) + 'px' });
            }
            if (location.locationWidth() != 0) {
                //$element.css({ width: Math.round(location.locationWidth() * bindingContext.$root.scale()) + 'px' });
                var absoluteWidth = location.locationWidth() / (bindingContext.$root.originalPageWidth / bindingContext.$root.pageImageWidth);
                $element.css({ width: Math.round(absoluteWidth * bindingContext.$root.scale()) + 'px' });
            }
            if (location.fontName() != "")
                $element.css({ fontFamily: location.fontName() });
            if (location.fontColor() != "")
                $element.css({ color: location.fontColor() });
            if (location.fontBold())
                $element.css({ "font-weight": "bold" });
            else
                $element.css({ "font-weight": "" });
            if (location.fontItalic())
                $element.css({ "font-style": "italic" });
            else
                $element.css({ "font-style": "" });
            if (location.fontUnderline())
                $element.css({ "text-decoration": "underline" });
            else
                $element.css({ "text-decoration": "" });
            $element.css({ "text-align": "" });
            switch (location.align()) {
                case 0:
                    $element.css({ "text-align": "left" });
                    break;
                case 1:
                    $element.css({ "text-align": "center" });
                    break;
                case 2:
                    $element.css({ "text-align": "right" });
                    break;
            }
        }
    };
    
    ko.bindingHandlers.dropField = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {

            var overlaps = (function () {
                function getPositions(elem) {
                    var pos = $(elem).position();
                    var width = $(elem).width();
                    var height = $(elem).height();
                    var top = pos.top;
                    var left = pos.left;
                    if ($(elem).context==null) {
                        var page = $(element);
                        var pageImage = $(".page-image", page);
                        var parentOffset = pageImage.offset();
                        top = top - parentOffset.top;
                        left = left - parentOffset.left;
                    }
                    return [[left, left + width], [top, top + height]];
                }
                function comparePositions(p1, p2) {
                    var r1 = p1[0] < p2[0] ? p1 : p2;
                    var r2 = p1[0] < p2[0] ? p2 : p1;
                    return r1[1] > r2[0] || r1[0] === r2[0];
                }
                return function (a, b) {
                    var pos1 = getPositions(a),
                        pos2 = getPositions(b);
                    return comparePositions(pos1[0], pos2[0]) && comparePositions(pos1[1], pos2[1]);
                };
            })();

            $(element).droppable({
                accept: ".signature_field, .signature_doc_field",
                tolerance:"fit",
                drop: function (event, ui) {
                    var page = $(element);
                    var pageId = allBindingsAccessor().pageId;
                    var obj = $(ui.draggable);
                    var fieldId = $(obj).attr("fieldId");
                    var fieldType = $(obj).attr("fieldType");
                    var pageImage = $(".page-image", page);
                    var parentOffset = pageImage.offset();
                    var pageNum = pageId;
                    var imageWidth = pageImage.width();
                    var imageHeight = pageImage.height();
                    var pos = $(ui.helper).offset();
                    var x = pos.left - parentOffset.left;
                    var y = pos.top - parentOffset.top;
                    var relativeX = x / imageWidth;
                    var relativeY = y / imageHeight;

                    if ($(ui.helper).hasClass('signature_doc_field')) { // old field moved to another page
                        var location = ko.dataFor(ui.draggable.context);
                        setTimeout((function () {
                                $(this).draggable("destroy");
                                location.locationX(relativeX);
                                location.locationY(relativeY);
                                location.page(pageNum);
                                bindingContext.$root.vm.updateFieldLocation(location);
                        }).bind(ui.draggable), 50);
                    } else { // new field added to a page
                        var isOverlap = false;
                        page.find(".signature_doc_field").each(function (i, val) {
                            if (overlaps(val, ui.helper)) {
                                bindingContext.$root.vm.config.alert({ title: "Error", message: "Locations should not be overlapped" });
                                isOverlap = true;
                                return false;
                            }
                        });
                        if (isOverlap) return false;

                        var height, width;
                        switch (parseInt(fieldType)) {
                            case 1: //signature
                                height = 46;
                                width = 138;
                                break;
                            case 6: //checkbox
                                height = 25;
                                width = 25;
                                break;
                            default:
                                height = $(ui.helper).height();
                                width = $(ui.helper).width();
                                break;
                        }
                        var relativeWidth = width * (bindingContext.$root.originalPageWidth / bindingContext.$root.pageImageWidth);
                        var relativeHeight = height * ((bindingContext.$root.originalPageWidth * bindingContext.$root.heightWidthRatio) / (bindingContext.$root.pageImageWidth * bindingContext.$root.heightWidthRatio));
                        bindingContext.$root.vm.addField(fieldId, pageNum, relativeX, relativeY, relativeHeight, relativeWidth, true, '');
                    }
                }
            });
        }
    };
    var droppableShouldCancel;
    ko.bindingHandlers.moveExistingField = {
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var valueUnwrapped = ko.utils.unwrapObservable(valueAccessor());            
            if (valueUnwrapped.enable != null && !valueUnwrapped.enable) return;
            if (ko.dataFor(element).locked != null && ko.dataFor(element).locked()) return;
            var location = ko.dataFor(element);
            var docPage = $("#" + bindingContext.$root.docViewerId + " .doc-page");

            var leftPos, topPos;
            if (bindingContext.$root.vm.config.isDownloadable) {
                leftPos = $(docPage).first().offset().left + $("#" + bindingContext.$root.docViewerId + " .doc-page .page-image").first().offset().left;
                topPos = $("#" + bindingContext.$root.docViewerId + " .doc-page .page-image").first().offset().top;
            } else {
                leftPos = $(docPage).first().offset().left;
                topPos = $(docPage).first().offset().top + 1;
            }
            var dragArea = [
                leftPos,
                topPos,
                leftPos + $(docPage).last().width() - ((location.locationWidth() / (bindingContext.$root.originalPageWidth / bindingContext.$root.pageImageWidth)) * bindingContext.$root.scale()),
                $(docPage).first().offset().top + ko.utils.unwrapObservable(bindingContext.$root.pageHeight) * bindingContext.$root.pageCount() - (location.locationHeight() / (bindingContext.$root.originalPageWidth / (bindingContext.$root.pageImageWidth * bindingContext.$root.heightWidthRatio)))
            ];
            $(element).mousemove(function(event) {
                if (event.ctrlKey && !bindingContext.$root.vm.config.isDownloadable) {
                    $(this).draggable({ helper: "clone" });
                } else
                    $(this).draggable({ helper: "" });
            }).draggable({
                scroll: false,
                zIndex: 2700,
                grid: [1, 1],
                cancel: '',
                containment: dragArea,
                stop: function(event, ui) {
                    $(".toolTip").tooltip('enable');
                    var field = ko.contextFor(element).$parents[1];
                    var obj = $(element).parent().parent();
                    var pageImage = $(".page-image", obj);
                    var parentOffset = pageImage.offset();
                    var pageNum = parseInt($(obj).attr("id").replace(bindingContext.$parents[4].pagePrefix, ""));
                    var imageWidth = pageImage.width();
                    var imageHeight = pageImage.height();
                    var pos = $(ui.helper).offset();
                    var y = pos.top - parentOffset.top;
                    if (y < 0 || y / imageHeight > 1) { //page number correction
                        obj = y < 0 ? obj.prev() : obj.next();
                        pageImage = $(".page-image", obj);
                        parentOffset = pageImage.offset();
                        pageNum = parseInt($(obj).attr("id").replace(bindingContext.$parents[4].pagePrefix, ""));
                        imageWidth = pageImage.width();
                        imageHeight = pageImage.height();
                        pos = $(ui.helper).offset();
                        y = pos.top - parentOffset.top;
                    }
                    var x = pos.left - parentOffset.left;

                    var relativeX = x / imageWidth;
                    var relativeY = y / imageHeight;
                    var fieldId = location.fieldId ? location.fieldId() : location.fieldGuid();
                    if (event.ctrlKey && !bindingContext.$root.vm.config.isDownloadable) {
                        var relativeWidth = $(element).width() * (bindingContext.$root.originalPageWidth / bindingContext.$root.pageImageWidth);
                        var relativeHeight = $(element).height() * ((bindingContext.$root.originalPage * bindingContext.$root.heightWidthRatio) / (bindingContext.$root.pageImageWidth * bindingContext.$root.heightWidthRatio));
                        if ((location.dirtyFlag && location.dirtyFlag().isDirty()) || (field.dirtyFlag && field.dirtyFlag().isDirty())) return;
                        bindingContext.$root.vm.addField(fieldId, pageNum, relativeX, relativeY, relativeHeight, relativeWidth, false, field.name());
                    } else {
                        location.locationX(relativeX);
                        location.locationY(relativeY);
                        location.page(pageNum);
                        //location.locationWidth($(element).width());
                        //location.locationHeight($(element).height());
                        bindingContext.$root.vm.updateFieldLocation(location);
                    }
                },
                start: function (event, ui) {
                    $(".toolTip").tooltip('hide');
                    $(".toolTip").tooltip('disable');
                    if ($(event.originalEvent.target).hasClass('text_area_toolbar') || $(event.originalEvent.target).parents('.text_area_toolbar').length > 0) {
                        return $(event.originalEvent.target).hasClass("ta_move");
                    }
                },
                revert: function () {
                    if (droppableShouldCancel) {
                        droppableShouldCancel = false;
                        return true;
                    } else {
                        return false;
                    }
                }
            });
            $(element).droppable({
                tolerance: "touch",
                over: function () {
                    droppableShouldCancel = true;
                },
                out: function () {
                    droppableShouldCancel = false;
                }
            });
        }
    };
    
    ko.bindingHandlers.dragField = {
        init: function (element, valueAccessor) {
            $(element).draggable({
                scroll: false,
                appendTo: 'body',
                revert: false,
                zIndex: 2700,
                cursor: "move",
                cursorAt: { left: 0 },
               // containment: ".doc-page",
                helper: function (event) {
                    switch (event.currentTarget.attributes['fieldType'].value) {
                        case "1":
                            return $("<div class='tool_field_helper' style='width:138px;height:46px'>" + $(this).attr("drag-helpertext") + "</div>");
                        default:
                            return $("<div class='tool_field_helper' style='width:205px;'>" + $(this).attr("drag-helpertext") + "</div>");
                    }
                    
                    
                },
                grid: [1, 1],
                cancel: false,
                start: function (event, ui) {
                    $(".toolTip").tooltip('hide');
                    $(".toolTip").tooltip('disable');
                },
                stop: function(event, ui) {
                    $(".toolTip").tooltip('enable');
                }
            });
        }
    };

    var resizeField = function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        if ($(element).data('uiResizable') != null) {
            $(element).resizable("destroy");
        }
        var valueUnwrapped = ko.utils.unwrapObservable(valueAccessor());
        if (valueUnwrapped.enable != null && !valueUnwrapped.enable) return;
        var location = ko.dataFor(element);
        var field = ko.contextFor(element).$parents[1];
        //var pageImageHeight = $("#pages-container #" + bindingContext.$root.docViewerId + "-img-" + location.page() + ".page-image").height();
        if (location.locked != null && location.locked()) return;
        var page = $(element).closest(".doc-page");
        var overlaps = (function () {
            function getPositions(elem) {
                var pos = $(elem).position();
                var width = $(elem).width();
                var height = $(elem).height();
                var top = pos.top;
                var left = pos.left;
                return [[left, left + width], [top, top + height]];
            }
            function comparePositions(p1, p2) {
                var r1 = p1[0] < p2[0] ? p1 : p2;
                var r2 = p1[0] < p2[0] ? p2 : p1;
                return r1[1] > r2[0] || r1[0] === r2[0];
            }
            return function (a, b) {
                var pos1 = getPositions(a),
                    pos2 = getPositions(b);
                return comparePositions(pos1[0], pos2[0]) && comparePositions(pos1[1], pos2[1]);
            };
        })();
        var resizeOptions = {
            stop: function (event, ui) {
                var fields = page.find(".signature_doc_field").not(this);
                var isOverlap = false;
                fields.each(function (i, val) {
                    if (overlaps(val, ui.helper)) {
                        bindingContext.$root.vm.config.alert({ title: "Error", message: "Locations should not be overlapped" });
                        isOverlap = true;
                        return false;
                    }
                });
                if (isOverlap) {
                    $(this).css({ 'width': ui.originalSize.width + 'px' });
                    $(this).css({ 'height': ui.originalSize.height + 'px' });
                    return false;
                }

                var pageImageWidth = $("#pages-container #" + bindingContext.$root.docViewerId + "-img-" + location.page() + ".page-image").width();
                var pageImageHeight = ko.utils.unwrapObservable(bindingContext.$root.pageHeight);
                if (pageImageWidth * location.locationX() + ui.size.width > pageImageWidth) {
                    $(this).css({ 'width': ui.originalSize.width + 'px' });
                    return false;
                }
                if (pageImageHeight * location.locationY() + ui.size.height >= pageImageHeight) {
                    $(this).css({ 'height': ui.originalSize.height + 'px' });
                    return false;
                }

                //location.locationWidth(ui.size.width / bindingContext.$root.scale());
                //location.locationHeight(ui.size.height / bindingContext.$root.scale());
                var relativeWidth = (ui.size.width * (bindingContext.$root.originalPageWidth / bindingContext.$root.pageImageWidth)) / bindingContext.$root.scale();
                var relativeHeight = (ui.size.height * ((bindingContext.$root.originalPageWidth * bindingContext.$root.heightWidthRatio) / (bindingContext.$root.pageImageWidth * bindingContext.$root.heightWidthRatio))) / bindingContext.$root.scale();
                location.locationWidth(relativeWidth);
                location.locationHeight(relativeHeight);
                bindingContext.$root.vm.updateFieldLocation(location);
                $(".toolTip").tooltip('enable');
            },
            start: function(event, ui) {
                $(".toolTip").tooltip('hide');
                $(".toolTip").tooltip('disable');
            },
            resize: function (e, ui) {
                var pageImageWidth = $("#pages-container #" + bindingContext.$root.docViewerId + "-img-" + location.page() + ".page-image").width();
                var pageImageHeight = ko.utils.unwrapObservable(bindingContext.$root.pageHeight);

                var directionRight = ui.originalSize.width < ui.size.width;
                if (directionRight && (pageImageWidth * location.locationX() + ui.size.width >= pageImageWidth - 5))
                    $(this).resizable('widget').trigger('mouseup');

                var directionDown = ui.originalSize.height < ui.size.height;
                if (directionDown && (pageImageHeight * location.locationY() + ui.size.height >= pageImageHeight - 5))
                    $(this).resizable('widget').trigger('mouseup');
            }
        };
        var signatureField = ko.utils.arrayFirst(ko.contextFor(element).$parents[2].signatureFields(), function(item) {
            return item.fieldType() == field.fieldType();
        });
        resizeOptions.minHeight = signatureField != null ? signatureField.minGraphSizeH() : 30;
        resizeOptions.minWidth = signatureField != null ? signatureField.minGraphSizeW() : 90;
        switch (parseInt(field.fieldType())) {
        case 1:
            //signature
            resizeOptions.aspectRatio = 3;
            break;
        case 6:
            //checkbox
            resizeOptions.aspectRatio = 1;
            break;
        default:
            break;
        }
        //resizeOptions.containment = ".doc-page";
        $(element).resizable(resizeOptions);
    };
    ko.bindingHandlers.resizeField = {
        update: resizeField,
        init: resizeField
    };
    
    ko.bindingHandlers.dateString = {
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            requirejs(['core/utils'], function(utils) {

                var value = valueAccessor(), allBindings = allBindingsAccessor();
                var valueUnwrapped = ko.utils.unwrapObservable(value);
                var pattern = allBindings.datePattern || 'MM/dd/yyyy';
                try {
                    $(element).text(utils.dateFromIso(valueUnwrapped,pattern));
                } catch(e) {
                    $(element).text("---");
                } 
            });
            
        }
    };
    
    ko.bindingHandlers.fieldSettingsToolbar = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var location = ko.dataFor(element);
            var field = ko.contextFor(element).$parents[1];
            $(element).find(".dropdown_menu_button").click(function (event) {
                var button = $(".dropdown_menu_button.active");
                $(button).next(".dropdown_menu").hide();

                if ($(this).hasClass("active")) {
                    $(this).next(".dropdown_menu").hide('blind', 'fast');
                    $(this).removeClass("active");
                } else {
                    $(this).addClass('active');
                    $(this).next(".dropdown_menu").show('blind', 'fast');
                }
                $(".toolTip").tooltip('hide');
                return false;
            });
            if (field.fieldType() == 1) {
                $(element).css("width", "60px").addClass("small-toolbar");
            } else if (field.fieldType() == 6) {
                $(element).css("width", "93px").addClass("small-toolbar");
            } else if (field.fieldType() == 8) {
                $(element).css("width", "60px").addClass("small-toolbar");
            }            //$(element).find(".font_size").delegate("li", "click", function () {
            //    var size = ko.dataFor(this);
            //    location.fontSize(size);
            //});
            $(element).find(".ta_plus").click(function () {
                var fontSizes = bindingContext.$root.vm.config.fontSizes;
                var maxFontSize = Math.max.apply(null, fontSizes);
                if (location.fontSize() < maxFontSize)
                    location.fontSize(location.fontSize() + 1);
            });
            $(element).find(".ta_minus").click(function () {
                var fontSizes = bindingContext.$root.vm.config.fontSizes;
                var minFontSize = Math.min.apply(null, fontSizes);
                if (location.fontSize() > minFontSize)
                    location.fontSize(location.fontSize() - 1);
            });
           // $(element).find(".font_name").delegate("li", "click", function () {
           //     var name = ko.dataFor(this);
           //     location.fontName(name);
           // });
            //$(element).find(".font_color").delegate("li", "click", function () {
            //    var name = ko.dataFor(this);
            //    location.fontColor(name);
            //});

        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            
            if ($(element).is(':visible')) {
                $(element).parents(".field_in_document").tooltip('enable');
            } else {
                $(element).parents(".field_in_document").tooltip('hide');
                $(element).parents(".field_in_document").tooltip('disable');
            }
        }
    };
    
    var datePickerIsOpen = false;
    var moveInViewportScrollDuration = 200;
    ko.bindingHandlers.datePicker = {
        init: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var valueUnwrapped = ko.utils.unwrapObservable(valueAccessor());
            var field = ko.contextFor(element).$parents[1];
            if (field)
                field.settings().showMonthYearDropdowns();
            var minYear = field &&  field.settings() != null && field.settings().minYear() != null ? field.settings().minYear() : "c-99";
            var maxYear = field &&  field.settings() != null && field.settings().minYear() != null ? field.settings().maxYear() : "c+30";
            var options = {
                dateFormat: "dd.mm.yy",
                changeMonth: field && field.settings() != null && field.settings().showMonthYearDropdowns() != null ? field.settings().showMonthYearDropdowns() : true,
                changeYear: field && field.settings() != null && field.settings().showMonthYearDropdowns() != null ? field.settings().showMonthYearDropdowns() : true,
                yearRange: minYear + ":" + maxYear,
                maxDate: new Date(maxYear, 11, 31),
                minDate: new Date(minYear, 0, 1),
                beforeShow: function (inp, obj) {
                    $(element).tooltip('hide');
                    $(element).tooltip('disable');
                    var height = $(inp).height() + 2;
                    setTimeout(function() {
                        $(obj.dpDiv).css({ left: '0px', top: height + 'px' });
                    }, 0);
                    $(inp).after(obj.dpDiv);
                    setTimeout(function () {
                        datePickerIsOpen = true;
                    }, moveInViewportScrollDuration);
                    
                },
                onClose: function() {
                    $(element).tooltip('enable');
                    datePickerIsOpen = false;
                }
            };
            if (valueUnwrapped.dateFormat != null) options.dateFormat = ko.utils.unwrapObservable(valueUnwrapped.dateFormat);
            $(element).datepicker(options).click(function () {
                if (!($.browser.msie && $.browser.version=="8.0"))
                    $(element).datepicker("show");
            }).keyup(function (e) {
                if (e.keyCode == 8 || e.keyCode == 46) {
                    $.datepicker._clearDate(this);
                }
            });
            $(".fod_icon_date").click(function () {
                if (($.browser.msie && $.browser.version == "8.0"))
                    $(element).next(".ui-datepicker").toggle();
            });
        }
    };
   
    ko.bindingHandlers.fieldCheckbox = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var field = ko.contextFor(element).$parents[1];
            
            $(element).addClass(field.data() == 'on' ? "checked" : "unchecked");
            $(element).addClass("checkbox"+field.id());
            $(element).click(function () {
                if (field.data() == null) return;
                $(element).toggleClass("unchecked");
                $(element).toggleClass("checked");
                if (field.data() == 'on') {
                    field.data('off');
                } else {
                    field.data('on');
                    if (field.groupName() && field.groupName() != '') {
                        var allFields = ko.contextFor(element).$parentContext.$parentContext.$parents[0].fields();
                        var signDocument = ko.contextFor(element).$parentContext.$parentContext.$parents[0].signDocument();
                        var documentId, documentFields;
                        if (signDocument.documentId) {
                            documentId = signDocument.documentId();
                            documentFields = ko.utils.arrayFilter(allFields, function (fld) {
                                return fld.locations() && fld.locations()[0] && fld.locations()[0].documentId() == documentId;
                            });
                        } else {
                            documentId = signDocument.documentGuid();
                            documentFields = ko.utils.arrayFilter(allFields, function (fld) {
                                return fld.locations() && fld.locations()[0] && fld.locations()[0].documentGuid() == documentId;
                            });
                        }
                        ko.utils.arrayForEach(documentFields, function (fld) {
                            if (fld.id() != field.id() && fld.groupName() == field.groupName() && fld.data() == 'on' && (fld.recipientId== null || fld.recipientId()==field.recipientId() ) ) {
                                var resetCheckbox = $(".checkbox" + fld.id());
                                resetCheckbox.toggleClass("unchecked");
                                resetCheckbox.toggleClass("checked");
                                fld.data('off');
                                resetCheckbox.trigger('change');
                            }
                        });
                    }
                }
                $(this).trigger('change');
            });
        }
    };
    
    ko.bindingHandlers.sortableList = {
        init: function (element, valueAccessor,allBindingsAccessor, viewModel) {
            $(element).sortable({
                update: function (event, ui) {
                    var list = valueAccessor();
                    //retrieve our actual data item
                    var item = ko.dataFor(ui.item.get(0));
                    //figure out its new position
                    var position = ko.utils.arrayIndexOf(ui.item.parent().children(":visible"), ui.item[0]);
                    //remove the item and add it back in the right spot
                    if (position >= 0) {
                        list.remove(item);
                        list.splice(position, 0, item);
                    }
                    if (typeof(item.dirtyFlag) == "function")
                        item.dirtyFlag().forceDirty();
                    ui.item.remove();
                    $(window).resize();
                },
                opacity: 0.5,
                scroll: false,
                handle: ".dots",
                appendTo: 'body',
                helper: 'clone',
                start: function (e, u) {
                    u.placeholder.css("height", u.item.css("height").replace("px", "") *0.25 + "px");
                }
            });
            $(element).mousedown(function() {
                $(".toolTip").tooltip('hide');
                $(".toolTip").tooltip('disable');
            });
            $(element).mouseup(function () {
                $(".toolTip").tooltip('enable');
            });
        }
    };

    ko.bindingHandlers.reorderList = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            $(element).sortable({
                update: function (event, ui) {
                    var value = ko.utils.unwrapObservable(valueAccessor());
                    //retrieve our actual data item
                    var item = ko.dataFor(ui.item.get(0));
                    //figure out its new position
                    var position = ko.utils.arrayIndexOf(ui.item.parent().children(":visible"), ui.item[0]);
                    if (value.updateFunction != null) {
                        value.updateFunction(item, position);
                    }
                },
                opacity: 0.5,
                scroll: false,
                handle: ".dots",
                appendTo: 'body',
                helper: 'clone',
                start: function (e, u) {
                    u.placeholder.css("height", u.item.css("height").replace("px", "") * 0.25 + "px");
                }
            });
            $(element).mousedown(function () {
                $(".toolTip").tooltip('hide');
                $(".toolTip").tooltip('disable');
            });
            $(element).mouseup(function () {
                $(".toolTip").tooltip('enable');
            });
        }
    };

    ko.bindingHandlers.selectedCheckbox = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            $(element).click(function() {
                var item = ko.dataFor(element);
                item.selected(!item.selected());
                if (item.selected()) {
                    $(this).removeClass("unchecked");
                    $(this).addClass("checked");
                } else {
                    $(this).addClass("unchecked");
                    $(this).removeClass("checked");
                }
            });
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var item = ko.dataFor(element);
            if (item.selected()) {
                $(element).removeClass("unchecked");
                $(element).addClass("checked");
            } else {
                $(element).addClass("unchecked");
                $(element).removeClass("checked");
            }
        }
    };

    ko.bindingHandlers.fieldTooltipText = {
        update: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var field = ko.contextFor(element).$parents[1];
            var isOwn = bindingContext.$root.vm.isOwnField(field);
            var viewerAction = ko.utils.unwrapObservable(bindingContext.$root.vm.viewerAction);
            if (viewerAction == 'prepare') {
                $(element).attr('data-original-title', field.name() + (field.tooltip() != '' && field.tooltip() != field.name() ? ' ' + field.tooltip() : ''));
            } else {
                if (isOwn) {
                    if (field.dirtyFlag().isDirty() && !field.data.isValid()) {
                        $(element).attr('data-original-title', field.data.error);
                    } else
                        $(element).attr('data-original-title', field.name() + (field.tooltip() != '' && field.tooltip() != field.name() ? ' ' + field.tooltip() : ''));
                    if (field.mandatory())
                        $(element).attr('data-mandatory', field.mandatory());
                } else {
                    if (bindingContext.$root.vm.getRecipientNameById!=null)
                        $(element).attr('data-original-title', 'Field for ' + bindingContext.$root.vm.getRecipientNameById(field.recipientId()));
                }
            }
        }
    };

    ko.bindingHandlers.enableSign = {
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var value = valueAccessor(), allBindings = allBindingsAccessor();
            var valueUnwrapped = ko.utils.unwrapObservable(value);
            var fieldsLeft = valueUnwrapped.fieldsLeft;
            var app = valueUnwrapped.app;
            var recipientStatus = valueUnwrapped.recipientStatus != null ? valueUnwrapped.recipientStatus : 0;
            if (fieldsLeft == 0 && recipientStatus == 1) {
                $(element).attr("data-original-title", "Click to sign the "+app);
                $(element).removeClass('disabled');
            }
            else {            
                if (recipientStatus == 4)
                    $(element).attr("data-original-title", "Recipient already signed");
                else {
                    if (fieldsLeft > 0) {
                        $(element).attr("data-original-title", "<span class='edit_invalid_field' style='color: white; cursor: pointer; text-decoration: underline'>Please complete the remaining " + fieldsLeft + " required " + (fieldsLeft == 1 ? " field" : " fields</span"));
                    }
                }
                $(element).addClass('disabled');
            }
        }
    };
    
    ko.bindingHandlers.moveInViewport = {
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var location = ko.dataFor(element);
            if (!location || !location.selected()) return;
            var page = $(element).closest(".doc-page");
            var wrapper = $(page).closest(".signature-viewer").parent();
            var center = $(wrapper).height() / 2;
            var $targetField = $(element).parent();
            if ($targetField.length == 0) return;
            if (datePickerIsOpen) return;
            var targetFieldPosition = $targetField.position();

            if (bindingContext.$root.vm.config.isDownloadable) {
                var yPos = targetFieldPosition.top + $targetField.height() / 2;
                var topPos = yPos + page.position().top;
                var targetScrollTopPos = topPos - center;
                if (topPos > center)
                    $(wrapper).stop(true, true).animate({ scrollTop: targetScrollTopPos }, { duration: moveInViewportScrollDuration });
                else
                    $(wrapper).stop(true, true).animate({ scrollTop: 0 }, { duration: moveInViewportScrollDuration });
            } else {
                var $nextLink = $("#next_field_marker");
                var imageOffset = $(".page-image", page).offset();
                var imageWidth = ko.utils.unwrapObservable(bindingContext.$root.pageWidth);
                var nextLinkX = imageOffset.left + imageWidth - $nextLink.width() / 2;
                $nextLink.css("left", nextLinkX + "px");

                var y = targetFieldPosition.top + $targetField.height() / 2 - $nextLink.height() / 2;
                var top = y + page.position().top;
                var targetScrollTop = top - center;

                var showNextLink = function() {
                    var $activeInput = $(document.activeElement);
                    var $targetInput = $("input,textarea,select", $targetField);
                    if ($activeInput.length > 0 && $targetInput.length > 0 && $activeInput[0] !== $targetInput[0]) {
                        $activeInput.blur();
                        $targetInput.focus();
                    }
                    if ($targetInput.length == 0) $activeInput.blur();

                    var targetFieldOffset = $targetField.offset();

                    var y1 = targetFieldOffset.top + $targetField.height() / 2 - $nextLink.height() / 2;
                    $nextLink.css({ top: y1 + "px" }).show();

                    $nextLink.unbind('click');
                    if (bindingContext.$root.vm.hasNextLocation()) {
                        $nextLink.removeClass('embed_next_field_empty');
                        if (!$nextLink.hasClass("embed_next_field"))
                            $nextLink.addClass("embed_next_field");
                        $nextLink.click(function() {
                            bindingContext.$root.vm.activateNextLocation();
                            return false;
                        });
                    } else {
                        $nextLink.addClass('embed_next_field_empty');
                        $nextLink.removeClass('embed_next_field');
                        $nextLink.click(function() {
                            $(".sign_envelope").tooltip('show');
                            return false;
                        });

                    }
                };
                if (top > center)
                    $(wrapper).stop(true, true).animate({ scrollTop: targetScrollTop }, { duration: moveInViewportScrollDuration, complete: showNextLink });
                else
                    $(wrapper).stop(true, true).animate({ scrollTop: 0 }, { duration: moveInViewportScrollDuration, complete: showNextLink });
            }
        }
    };

    ko.bindingHandlers.textFill = {
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {

            var valueUnwrapped = ko.utils.unwrapObservable(valueAccessor());
            var maxFontSize = 60;
            if (typeof (valueUnwrapped) != "undefined" && valueUnwrapped.maxFontSize != null) maxFontSize = valueUnwrapped.maxFontSize;
            if (typeof (valueUnwrapped) == "boolean" && !valueUnwrapped) return;
            var $element = $(element);
            var parent = $element.parent();
            if (bindingContext.$root.matchWidth()) {
                $(parent).css('width', '228px');
                var elementWidth = $element.width() || 1;
                
                var maxWidth;
                if ($element.css('fontFamily').indexOf('Herr Von Muellerhoff') > -1 ||
                    $element.css('fontFamily').indexOf('Tangerine') > -1 ||
                    $element.css('fontFamily').indexOf('Kristi') > -1)
                    maxWidth = parent.width() - 20;
                else
                    maxWidth = parent.width();
                var fontSizeWidth = parseInt($element.css("fontSize"), 10),
                    multiplierWidth = maxWidth / elementWidth,
                    newSizeWidth = fontSizeWidth * multiplierWidth;
                $element.css(
                    "fontSize",
                    (maxFontSize > 0 && newSizeWidth > maxFontSize) ?
                    maxFontSize :
                        newSizeWidth
                );
            } else {
                var elementHeight = $element.height() || 1;
                var padding = 3;
                if ($element.css('fontFamily').indexOf('Herr Von Muellerhoff') > -1 ||
                    $element.css('fontFamily').indexOf('Tangerine') > -1 ||
                    $element.css('fontFamily').indexOf('Kristi') > -1 ||
                    $element.css('fontFamily').indexOf('Homemade Apple') > -1 ||
                    $element.css('fontFamily').indexOf('Lobster') > -1)
                    padding = 20;
                if ($element.css('fontFamily').indexOf('Calligraffitti') > -1)
                    padding = 30;
                var fontSize = parseInt($element.css("fontSize"), 10),
                    multiplier = parent.height() / elementHeight,
                    newSize = fontSize * multiplier;
                $element.css(
                    "fontSize",
                    (maxFontSize > 0 && newSize > maxFontSize) ?
                        maxFontSize :
                        newSize
                ).css('padding-left', padding).css('padding-right', padding);
            }
        }
    };

    ko.bindingHandlers.signaturesCarousel = {
        init: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            $(element).bind('mousemove', function(e) {
                var itemToMove = $(this).closest(".signature-carousel-container").children().first();
                var coorX = e.pageX - $(this).closest(".signature-carousel-container").offset().left;
                var maxWidth = 0;
                $(this).parent().find(".signature-carousel").each(function () {
                    if (this.scrollWidth > maxWidth) maxWidth = this.scrollWidth;
                });
                var maxOffset = maxWidth - $(this).closest(".signature-carousel-container").width();
                var animationSpeed = 600;
                $(itemToMove).stop();
                if (coorX < 61) {
                    animationSpeed = -(parseInt($(itemToMove).css('margin-left')));
                    $(itemToMove).stop(true, true).animate({ 'margin-left': '0' }, animationSpeed);
                }
                if (coorX > 507) {
                    animationSpeed = maxOffset + parseInt($(this).css('margin-left'));
                    $(itemToMove).stop(true, true).animate({ 'margin-left': -maxOffset }, animationSpeed);
                }
                e.preventDefault();
            })
            .bind('mouseleave', function(e) {
                $(this).stop();
            });

            var startX, startMargin;
            $(element).bind('touchstart', function (event) {
                startX = event.originalEvent.touches[0].pageX;
                var itemToMove = $(this).closest(".signature-carousel-container").children().first();
                startMargin = parseInt($(itemToMove).css('margin-left'));
            });
            $(element).bind('touchmove', function (event) {
                var maxWidth = 0;
                $(this).parent().find(".signature-carousel").each(function () {
                    if (this.scrollWidth > maxWidth) maxWidth = this.scrollWidth;
                });
                var maxOffset = maxWidth - $(this).closest(".signature-carousel-container").width();
                var coorX = event.originalEvent.touches[0].pageX;
                if (startMargin - (startX - coorX) <= 0 && startMargin - (startX - coorX) >= -(maxOffset))
                    $(this).css('margin-left', startMargin - ( startX-coorX));
                event.preventDefault();
            });

            $(element).closest('.modal-body').bind('keyup', function (event) {
                var lastItem = $(element).find(".signature-carousel .signature-carousel-item").last();
                if (lastItem.offset().left < 0) {
                    $(element).css('margin-left', 0);
                }
            });
        }
    };

    ko.bindingHandlers.signatureCreateDialog = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            $(element).find('.popexpand').click(function (e) {
                var collapsedWidth = 264;
                var collapsedHeight = 88;
                var expandedWidth = 497;
                var expandedHeight = 165;
                var padCanvas;
                if ($(element).hasClass('expanded')) {
                    $(element).removeClass('expanded');
                    $("#signature-draw-container-" + viewModel.padIndex()).css("width", collapsedWidth + "px").css("height", collapsedHeight + "px").css("margin-top", "20px");
                    $("#signature-draw-container-" + viewModel.padIndex() + " svg.pad").attr("width", collapsedWidth).attr("height", collapsedHeight);
                    $(element).find("#signatureUpload" + viewModel.padIndex() + " .image-container, #signatureUpload" + viewModel.padIndex() + " .image-container img").css("width", collapsedWidth + "px").css("height", collapsedHeight + "px");
                    $("#signatureType" + viewModel.padIndex()+ " .signature-types:first").css("height", "88px");
                    $("#signatureMy" + viewModel.padIndex() + " .signature-types:first").css("height", "110px");

                    $(element).find("#signature-pad-" + viewModel.padIndex()).css("width", collapsedWidth + "px").css("height", collapsedHeight + "px");
                    padCanvas = $(element).find("#signature-pad-" + viewModel.padIndex() + " canvas");
                    if (padCanvas.length > 0) {
                        padCanvas.attr("width", collapsedWidth).attr("height", collapsedHeight).css("width", collapsedWidth + "px").css("height", collapsedHeight + "px");
                        //padCanvas[0].getContext("2d")._resize(collapsedWidth, collapsedHeight);
                    }
                } else {
                    $(element).addClass('expanded');
                    $("#signature-draw-container-" + viewModel.padIndex()).css("width", expandedWidth + "px").css("height", expandedHeight + "px").css("margin-top", "35px");
                    $("#signature-draw-container-" + viewModel.padIndex() + " svg.pad").attr("width", expandedWidth).attr("height", expandedHeight);
                    $(element).find("#signatureUpload" + viewModel.padIndex() + " .image-container, #signatureUpload" + viewModel.padIndex()+ " .image-container img").css("width", expandedWidth + "px").css("height", expandedHeight + "px");
                    $("#signatureType" + viewModel.padIndex() + " .signature-types:first").css("height", "176px");
                    $("#signatureMy" + viewModel.padIndex() + " .signature-types:first").css("height", "230px");

                    $(element).find("#signature-pad-" + viewModel.padIndex()).css("width", expandedWidth + "px").css("height", expandedHeight + "px");
                    padCanvas = $(element).find("#signature-pad-" + viewModel.padIndex() + " canvas:visible");
                    if (padCanvas.length > 0) {
                        padCanvas.attr("width", expandedWidth).attr("height", expandedHeight).css("width", expandedWidth + "px").css("height", expandedHeight + "px");
                        padCanvas[0].getContext("2d")._resize(expandedWidth, expandedHeight);
                    }
                }
                viewModel.expanded($(element).hasClass('expanded'));
            });
        }
    };

    ko.bindingHandlers.clearUploaded = {
        init: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var val = ko.utils.unwrapObservable(valueAccessor());
            if (!val) return;
            var $el = $(element);
            var id = $el.attr("id");
            if (!$el.attr("src") || $el.attr("src") == "") return;
            var imgUrl = $el.attr("src");
            var canvasId = id + "-canvas";
            var $canvas = $("#"+canvasId);
            var imageWidth = $el.width();
            var imageHeight = $el.height();
            if ($canvas.length == 0) {
                $("<canvas />").attr("id", canvasId)
                    .attr("width", imageWidth)
                    .attr("height", imageHeight)
                    .insertAfter($el);
                $canvas = $("#" + canvasId);
            }
            var canvas = $canvas[0];
            var context = canvas.getContext("2d");
            var binaryEroder = function(data) {
                for (var x = 0; x < data.width; x++) {
                    for (var y = 0; y < data.height; y++) {
                        var i = x * 4 + y * 4 * data.width;
                        var luma = Math.floor(data.data[i] * 299 / 1000 +
                            data.data[i + 1] * 587 / 1000 +
                            data.data[i + 2] * 114 / 1000);

                        data.data[i] = luma;
                        data.data[i + 1] = luma;
                        data.data[i + 2] = luma;
                        data.data[i + 3] = 255;
                    }
                }
            };
            var img = new Image();
            img.onload = function() {
                context.clearRect(0, 0, canvas.width, canvas.height);
                context.drawImage($el[0], 0, 0, canvas.width, canvas.height);
                var imageData = context.getImageData(0, 0, canvas.width, canvas.height);
                binaryEroder(imageData);
                context.putImageData(imageData, 0, 0);
            };
            img.src = imgUrl;
            //console.log("Processing image "+id+" with dimensions "+imageWidth+"x"+imageHeight);
        }
    };
    
    ko.bindingHandlers.popover = {
        update: function (element, valueAccessor, allBindingsAccessor) {
            $(element).popover({
                trigger: 'click',
                container: false,
                template: '<div class="popover popover-additional"><div class="arrow"></div><div class="popover-inner"><div class="popover-content"><p></p></div></div></div>'
            });
            $(element).click(function () {
                $("[rel='popover']").not(this).popover('hide');
            });
        }
    };

    ko.bindingHandlers.fieldToken = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var accessor = valueAccessor();
            $(element).val(ko.utils.unwrapObservable(accessor.value()));
            $(element).parent().delegate('input[type="hidden"]', 'change', function (e) {
                var value = $(e.delegateTarget).find('input[type="hidden"]').val();
                accessor.value(value);
            });
            var settings = {};
            if (accessor.regex) 
                settings.regex = accessor.regex;
            if (accessor.unique)
                settings.unique = accessor.unique;
            $(element).tokenField(settings);        
        }
    };

    ko.bindingHandlers.svgFieldCheckbox = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var field = ko.contextFor(element).$parents[1];
            var location = ko.dataFor(element);
            $(element).addClass("checkbox" + field.id());
            $(element).find("svg>path").css("fill", location.fontColor()!='' ? location.fontColor() : "#000000");
            $(element).click(function () {
                if (field.data() == null) return;
                if (field.data() == 'on') {
                    field.data('off');
                } else {
                    field.data('on');
                    if (field.groupName() && field.groupName() != '') {
                        var allFields = ko.contextFor(element).$parentContext.$parentContext.$parents[0].fields();
                        var signDocument = ko.contextFor(element).$parentContext.$parentContext.$parents[0].signDocument();
                        var documentId, documentFields;
                        if (signDocument.documentId) {
                            documentId = signDocument.documentId();
                            documentFields = ko.utils.arrayFilter(allFields, function (fld) {
                                return fld.locations() && fld.locations()[0] && fld.locations()[0].documentId() == documentId;
                            });
                        } else {
                            documentId = signDocument.documentGuid();
                            documentFields = ko.utils.arrayFilter(allFields, function (fld) {
                                return fld.locations() && fld.locations()[0] && fld.locations()[0].documentGuid() == documentId;
                            });
                        }
                        ko.utils.arrayForEach(documentFields, function (fld) {
                            if (fld.id() != field.id() && fld.groupName() == field.groupName()  && (fld.recipientId == null || fld.recipientId() == field.recipientId())) {
                                var resetCheckbox = $(".checkbox" + fld.id());
                                if (fld.data() == 'on' || fld.data() == '') {
                                    fld.data('off');
                                    resetCheckbox.trigger('change');
                                }
                            }
                        });
                    }
                }
                $(this).trigger('change');
            });
        }
    };
    ko.bindingHandlers.bindChildren = {
        init: function (element, valueAcessor, allBindings, vm, bindingContext) {
            //bind children first
            ko.applyBindingsToDescendants(bindingContext, element);

            //tell KO not to bind the children itself
            return { controlsDescendantBindings: true };
        }
    };

    ko.bindingHandlers.ckEditor = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var txtBoxId = $(element).attr("id");            
            // handle disposal (if KO removes by the template binding)
            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                if (CKEDITOR.instances[txtBoxId]) {
                    CKEDITOR.remove(CKEDITOR.instances[txtBoxId]);
                }
            });
            CKEDITOR.replace(txtBoxId,{
                fullPage: true,
                allowedContent: true
            });
            CKEDITOR.instances[txtBoxId].on('blur', function () {
                var observable = valueAccessor();
                observable($('<div/>').text(CKEDITOR.instances[txtBoxId].getData()).html());
            });
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var txtBoxId = $(element).attr("id");
            var val = ko.utils.unwrapObservable(valueAccessor());
            CKEDITOR.instances[txtBoxId].setData($('<div/>').html(val).text());
        }
    }

    ko.bindingHandlers.svgDisplayInserted = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var val = ko.utils.unwrapObservable(valueAccessor());
            if (val) {
                $("[compare-class='added']").show();
            } else {
                $("[compare-class='added']").hide();
            }
        }
    };

    ko.bindingHandlers.svgTransform = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var $container = $(element);
            var svgGroup = $("g", element)[0];
            $(svgGroup).attr("transform", viewModel.transformMatrix());
            
            if (viewModel.svgDisplayInserted()) {
                $("[compare-class='added']", $container).show();
            } else {
                $("[compare-class='added']", $container).hide();
            }

            if (viewModel.svgDisplayDeleted()) {
                $("[compare-class='deleted']", $container).show();
            } else {
                $("[compare-class='deleted']", $container).hide();
            }
        }
    };
    
    ko.bindingHandlers.updateLocationOnImageLoad = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            var location = value.location;
            $(element).on("load", function() {
                var relativeWidth = ($(this)[0].naturalWidth * (bindingContext.$root.originalPageWidth / bindingContext.$root.pageImageWidth)) / bindingContext.$root.scale();
                var relativeHeight = ($(this)[0].naturalHeight * ((bindingContext.$root.originalPageWidth * bindingContext.$root.heightWidthRatio) / (bindingContext.$root.pageImageWidth * bindingContext.$root.heightWidthRatio))) / bindingContext.$root.scale();
                location.locationWidth(relativeWidth);
                location.locationHeight(relativeHeight);
            });
        }
    };

    ko.bindingHandlers.localize = {
        init: function(element, valueAccessor, allBindingAcessors, viewModel) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            if (!value) {
                return;
            }
            var processingTheEvent = false;

            $(element).bind("DOMNodeInserted", function() {
                if (processingTheEvent === true) {
                    return;
                }
                processingTheEvent = true;
                var localizedStrings = viewModel.localization;
                if (localizedStrings != null) {
                    $(this).find("[data-localize],[data-localize-ph],[data-localize-tooltip],[data-localize-title]").each(function() {
                        var that = $(this);
                        var localizationKey = that.attr("data-localize");
                        var localizationTextValue;
                        if (localizationKey) {
                            localizationTextValue = localizedStrings[localizationKey];
                            that.text(localizationTextValue);
                            that.removeAttr("data-localize");
                        }
                        localizationKey = that.attr("data-localize-ph");
                        if (localizationKey) {
                            localizationTextValue = localizedStrings[localizationKey];
                            that.attr("placeholder", localizationTextValue);
                            that.removeAttr("data-localize-ph");
                        }
                        localizationKey = that.attr("data-localize-title");
                        if (localizationKey) {
                            localizationTextValue = localizedStrings[localizationKey];
                            that.attr("title", localizationTextValue);
                            that.removeAttr("data-localize-title");
                        }
                        localizationKey = that.attr("data-localize-tooltip");
                        if (localizationKey) {
                            localizationTextValue = localizedStrings[localizationKey];
                            that.attr("data-tooltip", localizationTextValue);
                            that.removeAttr("data-localize-tooltip");
                        }
                    });
                }

                processingTheEvent = false;
            });
        }
    };

    ko.bindingHandlers.fieldDropdown = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var field = ko.utils.unwrapObservable(valueAccessor());
            $(element).find("ul").delegate("li", "click", function () {
                field.data(ko.contextFor(this).$data);
                $(element).trigger('change');
            });
        }
    };
})(ko, jQuery);
