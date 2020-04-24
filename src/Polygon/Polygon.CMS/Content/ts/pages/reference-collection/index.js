"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var table_1 = require("../../_tesseract/table");
var drawer_1 = require("../../_tesseract/drawer");
var ReferenceCollectionPage = /** @class */ (function () {
    function ReferenceCollectionPage() {
        this.createUrl = "/Settings/ReferenceData/CreateReferenceCollection";
        this.createCollectionBtn = document.querySelector("#CreateReferenceCollection");
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceCollections/";
        this.init();
    }
    ReferenceCollectionPage.prototype.init = function () {
        this.generateTable();
        this.createCollectionBtn.addEventListener('click', this.generateCreateCollectionDrawer.bind(this));
    };
    ReferenceCollectionPage.prototype.generateTable = function () {
        var tableOptions = new /** @class */ (function () {
            function class_1() {
                this.hasEdit = true;
                this.hasView = true;
                this.showRowCount = true;
            }
            return class_1;
        }());
        tableOptions.requestUrl = this.tableDataUrl;
        this.tesseractTable = new table_1.default(tableOptions);
        var targetNode = document.querySelector(".tesseract__table");
        var mutationConfig = { childList: true, subtree: true };
        var onMutation = function (mutations) {
            for (var _i = 0, mutations_1 = mutations; _i < mutations_1.length; _i++) {
                var addedNodes = mutations_1[_i].addedNodes;
                for (var _a = 0, addedNodes_1 = addedNodes; _a < addedNodes_1.length; _a++) {
                    var node = addedNodes_1[_a];
                    if (!node.tagName)
                        continue;
                    console.log(node.subtree);
                }
            }
        };
        var observer = new MutationObserver(onMutation);
        observer.observe(targetNode, mutationConfig);
    };
    ReferenceCollectionPage.prototype.addEventHandlers = function () {
        console.log("Adding event handlers");
        var viewBtns = document.querySelectorAll(".btn__view");
        for (var viewBtn in viewBtns) {
            console.log(viewBtn);
        }
    };
    ReferenceCollectionPage.prototype.generateCreateCollectionDrawer = function () {
        var drawerOptions = new /** @class */ (function () {
            function class_2() {
                this.hasCancelButton = true;
                this.hasSaveButton = true;
            }
            return class_2;
        }());
        drawerOptions.contentUrl = this.createUrl;
        this.tesseractDrawer = new drawer_1.default(drawerOptions);
    };
    return ReferenceCollectionPage;
}());
exports.default = ReferenceCollectionPage;
//# sourceMappingURL=index.js.map