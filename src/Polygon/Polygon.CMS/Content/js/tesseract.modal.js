
export function initializeModal() {
    $("body").on("click", ".global-modal", function (event) {
        var button = $(this);
        event.preventDefault();
        showModalWindow(button.attr("href") ? button.attr("href") : button.data("url"), button.data("size"))
    });

    $("#tesseractModal .modal-content").on("click", ".close-modal", function () {
        closeModalWindow();
    });

    $('#tesseractModal').on('shown.bs.modal',
        function () {
            var tt = $(" #tesseractModal .modal-content form:first *:input[type!=hidden]:first").focus();
            if (tt != 'undefined') {
                if (tt.attr('type') == "submit") {
                    $("select[type!=hidden]:first").focus();
                } else {
                    tt.focus();
                }
            }
        });
};

export function showModalWindow(url, size, options) {
    if (!options)
        options = {
            backdrop: "static"
        };

    $.get(url, function (data) {
        $("#tesseractModal .modal-body").html(data);
        setWindowSize(size);
        $("#tesseractModal").modal(options);
    }).fail(function (jqXhr, textStatus, errorThrown) {
        console.log(jqXhr.statusText);
    });

    if (options.closeCallBack)
        $("#tesseractModal").on("hidden.bs.modal", function () {
            options.closeCallBack();
        });
};

export function showModalWithData(title, data, size, options) {
    if (!options)
        options = {
            backdrop: "static"
        };

    $("#tesseractModal .modal-title").html(title);
    $("#tesseractModal .modal-body").html(data);
    setWindowSize(size);
    $("#tesseractModal").modal(options);

    if (options.closeCallBack)
        $("#tesseractModal").on("hidden.bs.modal", function () {
            options.closeCallBack();
        });
};

export function setupModalForm(statusCodeActions) {
    $("#tesseractModal").on("submit", "form", function (e) {
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
};

export function setWindowSize(size) {
    var modal = $("#tesseractModal > .modal-dialog").removeClass(
        "modal-lg modal-sm modal-md"
    );

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
};

export function ShowWindowPost(url, formSelector, size, options) {
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
            $("#tesseractModal .modal-body").html(data);
            setWindowSize(size);
            $("#tesseractModal").modal(options);
        }
    });
}

export function closeModalWindow() {
    $("#tesseractModal .modal-body").html("");
    $("#tesseractModal").modal("hide");
    $(".modal-backdrop").remove();
};

export function GenerateLink(url, linkText) {
    return (
        '<a href="' + url + '" class="tesseractModal link">' + linkText + "</a>"
    );
};

export function ShowValidationErrors(errors) {
    $("#tesseractModal [type=submit]").removeAttr("disabled");
    $(".field-validation-error").html("");
    $("#tesseractModal form")
        .validate()
        .showErrors($.parseJSON(errors));
};

export function replaceModalContent(url) {
    $.get(url, function (data) {
        $("#tesseractModal .modal-body").html(data);
    });
};