(function ($) {
    $.confirm = function (params) {
        $("#confirm-modal").remove();

        var zIndex = "";
        if (params.zIndex != null) zIndex = "z-index: " + params.zIndex +";";

        var markup = [
            '<div class="modal fade modal2 " id="confirm-modal" tabindex="-1" style="'+ zIndex +' outline: none;">',
                '<div class="modal_inner_wrapper">',
                    params.showCloseButton==null || params.showCloseButton ? '<a class="popclose" data-dismiss="modal"></a>' : '',
                    '<div class="modal_header">',
                        '<h3>', params.title, '</h3>',
                    '</div>',
                    '<div class="modal_content">',
                        '<div class="modal_input_wrap_full">',
                            '<p class="modaltext left">', params.message, '</p>',
                        "</div>",
                    "</div>",
                    "<div class='modal_footer'>",
                        "<div class='modal_btn_wrapper'>",
                        params.showCheckbox != null && params.showCheckbox ? "<span class='checkbox unchecked'><input type='checkbox' class='checkbox'></span><span style='position: relative; top:10px;'>"+params.checkboxText+"</span>" : "",
                        "</div>",
                    '</div>',
                '</div>',
            "</div>"
        ].join('');

        $(markup).appendTo('body');

        $.each(params.buttons, function (name, obj) {
            if (!obj.action) {
                obj.action = function () {
                };
            }

            var cssClass = "";
            if (name === "Yes" || obj.isYes) cssClass = "red_button right";
            else if (name === "No" || obj.isNo) cssClass = "text_btn right";

            if (obj["class"]) {
                cssClass = obj["class"];
            }

            $("<a />")
                .addClass(cssClass)
                .attr("href", "#")
                .html(name)
                .click(function () {
                    var checked = undefined;
                    if (params.showCheckbox) {
                        checked = $(".modal_footer span.checkbox").hasClass("checked");
                    }
                    $.confirm.hide();
                    obj.action(checked);
                    return false;
                }).appendTo("#confirm-modal .modal_btn_wrapper");
        });
        if ( params.keyboard!=null )
            $("#confirm-modal").modal({ keyboard: params.keyboard });
        $("#confirm-modal").on("hide",function() {
            $(".modal-backdrop").remove();
            $("#confirm-modal").remove();
            if (params.onclose != null)
                params.onclose();
        }).modal("show");
        $(".modal_footer span.checkbox").click(function () {
            if ($(this).hasClass("unchecked")) {
                $(this).removeClass("unchecked");
                $(this).addClass("checked");
            } else {
                $(this).addClass("unchecked");
                $(this).removeClass("checked");
            }
        });
    };
    
    $.confirm.hide = function () {
        $("#confirm-modal").modal("hide");
    };
})(jQuery);