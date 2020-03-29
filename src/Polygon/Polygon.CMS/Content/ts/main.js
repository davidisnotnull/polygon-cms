"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var $ = require("jquery");
window.jQuery = $;
require("popper.js");
require("bootstrap");
/* Tesseract */
var _tesseract_modal_1 = require("./_tesseract/_tesseract-modal");
/* Utility classes */
/* Pages */
var _reference_collection_1 = require("./_pages/_reference-collection");
var _reference_item_1 = require("./_pages/_reference-item");
$(document).ready(function () {
    console.log("Polygon CMS Version 1.0");
    new _tesseract_modal_1.TesseractModal();
    /* Load Reference Type scripts */
    if (document.querySelector('.page__reference-collection')) {
        new _reference_collection_1.ReferenceCollectionPage();
    }
    if (document.querySelector(".page__reference-item")) {
        new _reference_item_1.ReferenceItemPage();
    }
});
require("../scss/main.scss");
//# sourceMappingURL=main.js.map