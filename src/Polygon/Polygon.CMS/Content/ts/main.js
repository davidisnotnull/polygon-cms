"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/* Styles */
require("./_tesseract/main.scss");
/* Tesseract */
var navigation_1 = require("./_tesseract/navigation");
var wysiwyg_1 = require("./_tesseract/wysiwyg");
/* Pages */
// Settings pages
var reference_collection_1 = require("./pages/reference-collection");
var reference_item_1 = require("./pages/reference-item");
var cookie_settings_1 = require("./pages/cookie-settings");
// Developer pages
var tesseract_1 = require("./pages/developer/tesseract");
/* Script loader */
window.onload = function (e) {
    new navigation_1.default();
    /* Load Reference Collection Page scripts */
    if (document.querySelector('.page__reference-collection')) {
        new reference_collection_1.default();
    }
    /* Load Reference Item Page scripts */
    if (document.querySelector(".page__reference-item")) {
        new reference_item_1.default();
    }
    /* Load Cookie Settings Page scripts */
    if (document.querySelector(".page__cookie-settings")) {
        new wysiwyg_1.default();
        new cookie_settings_1.default();
    }
    if (document.querySelector(".page__developer--tesseract")) {
        new tesseract_1.default();
    }
};
//# sourceMappingURL=main.js.map