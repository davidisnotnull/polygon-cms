"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var notify_1 = require("../../../_tesseract/notify/");
var TesseractDeveloperPage = /** @class */ (function () {
    function TesseractDeveloperPage() {
        this.init();
    }
    TesseractDeveloperPage.prototype.init = function () {
        var notifyTrigger = document.querySelector("#FireNotification");
        notifyTrigger.addEventListener('click', this.fireNotification.bind(this));
    };
    TesseractDeveloperPage.prototype.fireNotification = function () {
        console.info("Firing Tesseract notification");
        var notifyOptions = new /** @class */ (function () {
            function class_1() {
            }
            return class_1;
        }());
        notifyOptions.message = "Here's your test notification";
        notifyOptions.type = "info";
        new notify_1.default(notifyOptions);
    };
    return TesseractDeveloperPage;
}());
exports.default = TesseractDeveloperPage;
//# sourceMappingURL=index.js.map