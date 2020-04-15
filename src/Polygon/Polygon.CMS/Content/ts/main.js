"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var $ = require("jquery");
window.jQuery = $;
require("popper.js");
require("bootstrap");
require("preact");
/* Tesseract */
var _tesseract_modal_1 = require("./_tesseract/_tesseract-modal");
var _tesseract_wysiwyg_1 = require("./_tesseract/_tesseract-wysiwyg");
/* Utility classes */
/* Pages */
var _reference_collection_1 = require("./_pages/_reference-collection");
var _reference_item_1 = require("./_pages/_reference-item");
var _cookie_settings_1 = require("./_pages/_cookie-settings");
$(document).ready(function () {
    new _tesseract_modal_1.TesseractModal();
    /* Load Reference Collection Page scripts */
    if (document.querySelector('.page__reference-collection')) {
        new _reference_collection_1.ReferenceCollectionPage();
    }
    /* Load Reference Item Page scripts */
    if (document.querySelector(".page__reference-item")) {
        new _reference_item_1.ReferenceItemPage();
    }
    /* Load Cookie Settings Page scripts */
    if (document.querySelector(".page__cookie-settings")) {
        new _tesseract_wysiwyg_1.TesseractWysiwyg();
        new _cookie_settings_1.CookieSettingsPage();
    }
});
require("../scss/main.scss");
//# sourceMappingURL=main.js.map