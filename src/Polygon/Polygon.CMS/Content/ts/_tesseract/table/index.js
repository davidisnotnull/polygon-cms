"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("./styles");
var TesseractTable = /** @class */ (function () {
    function TesseractTable(props) {
        this.props = props;
        this.init();
    }
    TesseractTable.prototype.init = function () {
        this.getTableData();
    };
    TesseractTable.prototype.getTableData = function () {
        var _this = this;
        fetch(this.props.requestUrl, {
            method: "POST"
        })
            .then(function (r) { return r.json(); })
            .then(function (data) {
            _this.constructTable(data);
        })
            .catch(function (error) {
            console.error(error);
            return [];
        });
    };
    TesseractTable.prototype.constructTable = function (data) {
        var tableData = data;
        console.log(data);
        var table = document.querySelector(".tesseract__table");
        var thead = table.createTHead();
        thead.className = "table__head";
        var theadRow = (document.createElement("tr"));
        var columnCount = tableData.columnCount;
        if (this.props.selectable) {
            var selectAllContainer = (document.createElement("th"));
            selectAllContainer.className = "col__select";
            var selectAllCheckbox = (document.createElement("input"));
            selectAllCheckbox.type = "checkbox";
            selectAllCheckbox.className = "input__chk-select-all";
            selectAllCheckbox.addEventListener("click", this.handleSelectAll.bind(this));
            selectAllContainer.appendChild(selectAllCheckbox);
            theadRow.appendChild(selectAllContainer);
            ++columnCount;
        }
        for (var _i = 0; _i < tableData.columnCount; _i++) {
            var theadCol = (document.createElement("th"));
            theadCol.className = ("col__" + _i);
            if (tableData.header[_i] != undefined) {
                theadCol.innerText = tableData.header[_i].toString();
            }
            theadRow.appendChild(theadCol);
        }
        if (this.props.hasView) {
            var theadCol = (document.createElement("th"));
            theadCol.className = "col__ctrl--view";
            theadRow.appendChild(theadCol);
            ++columnCount;
        }
        if (this.props.hasEdit) {
            var theadCol = (document.createElement("th"));
            theadCol.className = "col__ctrl--edit";
            theadRow.appendChild(theadCol);
            ++columnCount;
        }
        if (this.props.hasDelete) {
            var theadCol = (document.createElement("th"));
            theadCol.className = "col__ctrl--delete";
            theadRow.appendChild(theadCol);
            ++columnCount;
        }
        thead.appendChild(theadRow);
        var tbody = table.createTBody();
        tbody.className = "table__body";
        var rowCounter = 0;
        for (var _i = 0, _a = tableData.rows; _i < _a.length; _i++) {
            var row = _a[_i];
            ++rowCounter;
            var itemGuid = "";
            var tableRow = (document.createElement("tr"));
            tableRow.setAttribute("data-row-id", String(rowCounter));
            if (this.props.selectable) {
                var rowCell = (document.createElement("td"));
                var selectRowCheckbox = (document.createElement("input"));
                selectRowCheckbox.type = "checkbox";
                selectRowCheckbox.className = "input__chk--select-row";
                selectRowCheckbox.addEventListener("click", this.handleSelectRow.bind(this));
                rowCell.appendChild(selectRowCheckbox);
                tableRow.appendChild(rowCell);
            }
            var caughtGuid = false;
            for (var _b = 0, row_1 = row; _b < row_1.length; _b++) {
                var cell = row_1[_b];
                if (caughtGuid === false) {
                    itemGuid = cell;
                    caughtGuid = true;
                    continue;
                }
                var rowCell = (document.createElement("td"));
                rowCell.innerText = cell;
                tableRow.appendChild(rowCell);
            }
            if (this.props.hasView) {
                var rowCell = (document.createElement("td"));
                var viewLink = (document.createElement("button"));
                viewLink.innerText = "View";
                viewLink.className = "btn__view";
                viewLink.setAttribute("data-id", itemGuid);
                rowCell.appendChild(viewLink);
                tableRow.appendChild(rowCell);
            }
            if (this.props.hasEdit) {
                var rowCell = (document.createElement("td"));
                var editLink = (document.createElement("button"));
                editLink.innerText = "Edit";
                editLink.className = "btn__edit";
                editLink.setAttribute("data-id", itemGuid);
                rowCell.appendChild(editLink);
                tableRow.appendChild(rowCell);
            }
            if (this.props.hasDelete) {
                var rowCell = (document.createElement("td"));
                var deleteLink = (document.createElement("button"));
                deleteLink.innerText = "Delete";
                deleteLink.className = "btn__delete";
                deleteLink.setAttribute("data-id", itemGuid);
                rowCell.appendChild(deleteLink);
                tableRow.appendChild(rowCell);
            }
            tbody.appendChild(tableRow);
        }
        table.appendChild(thead);
        table.appendChild(tbody);
        if (this.props.showRowCount) {
            var tfoot = table.createTFoot();
            tfoot.className = "table__foot";
            var footerRow = (document.createElement("tr"));
            var footerCell = (document.createElement("td"));
            footerCell.setAttribute("colspan", String(columnCount));
            footerCell.innerText = "Total number of rows: " + tableData.totalNumberOfRows;
            footerRow.appendChild(footerCell);
            tfoot.appendChild(footerRow);
            table.appendChild(tfoot);
        }
    };
    TesseractTable.prototype.handleSelectAll = function () {
        console.log("Toggle select all");
        var checkboxes = document.querySelectorAll(".input__chk--select-row");
        checkboxes.forEach(function (checkbox) {
        });
    };
    TesseractTable.prototype.handleSelectRow = function (e) {
        console.log("Toggle select row");
    };
    return TesseractTable;
}());
exports.default = TesseractTable;
//# sourceMappingURL=index.js.map