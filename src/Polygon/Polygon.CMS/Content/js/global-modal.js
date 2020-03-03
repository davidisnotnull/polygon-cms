
var Modal = Modal ||
{
    Initialize: function () {
        $(function () {
            $("body").on("click",
                "#global-modal",
                function (e) {
                    var button = $(this);
                    e.preventDefault();
                    Modal.ShowWindow(button.attr("href") ? button.attr("href") : button.data("url"),
                        button.data("size"));
                });

            $("#global-modal .modal-content").on("click",
                ".close-modal",
                function (e) {
                    Modal.CloseWindow();
                });

            $("#global-modal").on("shown.bs.modal",
                function () {
                    var tt = $("#global-modal .modal-content form:first *:input[type!=hidden]:first").focus();
                    if (tt != undefined) {
                        if (tt.attr("type") == "submit") {
                            $("select[type!=hidden]:first").focus();
                        } else {
                            tt.focus();
                        }
                    }
                });
        });
    },
    ShowWindow: function (url, size, options) {
        if (!options)
            options = {
                backdrop: "static"
            };

        $.get(url, function (data) {
            $("#global-modal .modal-content").html(data);
            Modal.SetWindowSize(size);
            $("#global-modal").modal(options);
        }).fail(function (jqXhr, textStatus, errorThrown) {
            console.log(jqXhr.statusText);
        });

        if (options.closeCallBack)
            $("#global-modal").on("hidden.bs.modal", function () {
                options.closeCallBack();
            });
    },
    SetupForm: function (statusCodeActions) {
        $("#global-modal").on("submit",
            "form",
            function (e) {
                e.preventDefault();
                if ($(this).valid()) {
                    $.ajax({
                        method: "POST",
                        url: $(this).attr("action"),
                        data: $(this).serialize(),
                        statusCode: statusCodeActions
                    });
                }
            });
    },
    SetWindowSize: function (size) {
        var modal = $("#global-modal > .modal-dialog").removeClass("modal-lg modal-sm modal-md");

        if (size) {
            switch (size) {
                case "small":
                    modal.addClass("modal-sm");
                    break;
                case "large":
                    modal.addClass("modal-lg");
                    break;
                default:
                    modal.addClass("modal-md");
                    break;
            }
        } else {
            modal.addClass("modal-md");
        }
    },
    ShowWindowPost: function (url, formSelector, size, options) {
        if (!options) {
            options = {
                backdrop: "static"
            };
        }

        $.ajax({
            url: url,
            data: $(formSelector).serialize(),
            method: "POST",
            success: function (data) {
                $("#global-modal .modal-content").html(data);
                Modal.SetWindowSize(size);
                $("#global-modal").modal(options);
            }
        });
    },
    CloseWindow: function () {
        $("#global-modal .modal-content").html("");
        $("#global-modal").modal("hide");
        $(".modal-backdrop").remove();
    },
    GenerateLink: function (url, linkText) {
        return '<a href="' + url + '" class="global-modal link">' + linkText + '</a>';
    },
    ShowValidationErrors: function (errors) {
        $("#global-modal [type=submit]").removeAttr("disabled");
        $(".field-validation-error").html("");
        $("#global-modal form").validate().showErrors($.parseJSON(errors));
    },
    ReplaceGlobalModalContent: function (url) {
        $.get(url, function (data) {
            $("#global-modal .modal-content").html(data);
        });
    }
}