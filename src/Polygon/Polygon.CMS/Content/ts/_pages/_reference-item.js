"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var _tesseract_modal_1 = require("../_tesseract/_tesseract-modal");
var _tesseract_table_1 = require("../_tesseract/_tesseract-table");
var ReferenceItemPage = /** @class */ (function () {
    function ReferenceItemPage() {
        this.referenceCollectionId = document.querySelector("#ReferenceCollectionId").getAttribute("value");
        this.saveButton = document.querySelector(".modal__save");
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceItems/?guid=" + this.referenceCollectionId;
        this.submitUrl = "/Settings/ReferenceData/CreateReferenceItem/";
        this.tesseractTable = new _tesseract_table_1.TesseractTable(this.tableDataUrl);
        this.tesseractModal = new _tesseract_modal_1.TesseractModal();
        this.Initialise();
    }
    ReferenceItemPage.prototype.Initialise = function () {
        var _this = this;
        this.saveButton.addEventListener("click", function (event) {
            event.preventDefault();
            _this.SaveReferenceItem();
        });
    };
    ReferenceItemPage.prototype.SaveReferenceItem = function () {
        var _this = this;
        this.saveButton.setAttribute("disabled", "");
        var form;
        form = document.querySelector(".modal__form");
        var formData = new FormData(form);
        fetch(this.submitUrl, {
            method: "POST",
            body: formData
        })
            .then(function (r) { return r.status; })
            .then(function (s) {
            _this.tesseractModal.CloseModal();
            _this.tesseractTable.Refresh();
            _this.saveButton.removeAttribute("disabled");
        })
            .catch(function (e) {
            console.log("Error :", e);
        });
    };
    return ReferenceItemPage;
}());
exports.ReferenceItemPage = ReferenceItemPage;
//# sourceMappingURL=_reference-item.js.map