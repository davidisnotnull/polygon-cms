"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ReferenceItemPage = /** @class */ (function () {
    function ReferenceItemPage() {
        this.referenceCollectionId = document.querySelector("#ReferenceCollectionId").getAttribute("value");
        this.saveButton = document.querySelector(".modal__save");
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceItems/?guid=" + this.referenceCollectionId;
        this.saveUrl = "/Settings/ReferenceData/CreateReferenceItem/";
        this.updateUrl = "/Settings/ReferenceData/UpdateReferenceItem/";
        this.deleteUrl = "/Settings/ReferenceData/DeleteReferenceItem/";
        this.Initialise();
    }
    ReferenceItemPage.prototype.Initialise = function () {
        var _this = this;
        this.saveButton.addEventListener("click", function (event) {
            event.preventDefault();
            _this.SubmitForm(_this.saveButton);
        });
    };
    ReferenceItemPage.prototype.SubmitForm = function (button) {
        var action = button.getAttribute("data-action");
        switch (action) {
            case "save":
                this.SaveReferenceItem();
                break;
            case "edit":
                this.UpdateReferenceItem();
                break;
            case "delete":
                this.DeleteReferenceItem();
                break;
        }
    };
    ReferenceItemPage.prototype.SaveReferenceItem = function () {
        var _this = this;
        this.saveButton.setAttribute("disabled", "");
        var form;
        form = document.querySelector(".modal__form");
        var formData = new FormData(form);
        var token = document.querySelector('input[name="__RequestVerificationToken"]').getAttribute("value");
        fetch(this.saveUrl, {
            method: "POST",
            headers: {
                "RequestVerificationToken": token
            },
            body: formData
        })
            .then(function (r) { return r.status; })
            .then(function (s) {
            _this.saveButton.removeAttribute("disabled");
        })
            .catch(function (e) {
            console.log("Error :", e);
        });
    };
    ReferenceItemPage.prototype.UpdateReferenceItem = function () {
        var _this = this;
        this.saveButton.setAttribute("disabled", "");
        var form;
        form = document.querySelector(".modal__form");
        var formData = new FormData(form);
        var token = document.querySelector('input[name="__RequestVerificationToken"]').getAttribute("value");
        fetch(this.updateUrl, {
            method: "POST",
            headers: {
                "RequestVerificationToken": token
            },
            body: formData
        })
            .then(function (r) { return r.status; })
            .then(function (s) {
            _this.saveButton.removeAttribute("disabled");
        })
            .catch(function (e) {
            console.log("Error :", e);
        });
    };
    ReferenceItemPage.prototype.DeleteReferenceItem = function () {
    };
    return ReferenceItemPage;
}());
exports.default = ReferenceItemPage;
//# sourceMappingURL=index.js.map