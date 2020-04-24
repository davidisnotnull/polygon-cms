import Table from "./interfaces/Table";
import TableOptions from "./interfaces/TableOptions";
import "./styles";

class TesseractTable
{
    props: TableOptions;
    
    constructor(props: TableOptions) {
       this.props = props;
       this.init();
    }
    
    init() {
        this.getTableData();
    }
    
    getTableData() {
        fetch(this.props.requestUrl, {
            method: "POST"
        })
            .then(r => r.json())
            .then(data => {
                this.constructTable(data);  
            })
            .catch(error => {
                console.error(error);
                return[];
            });
    }
    
    private constructTable(data: any) {
        let tableData : Table = data;
        console.log(data);
        let table = document.querySelector(".tesseract__table") as HTMLTableElement;

        let thead = table.createTHead();
        thead.className = "table__head";
        
        let theadRow = (document.createElement("tr")) as HTMLTableRowElement;
        
        let columnCount = tableData.columnCount;

        if (this.props.selectable)
        {   
            let selectAllContainer = (document.createElement("th")) as HTMLTableCellElement;
            selectAllContainer.className = "col__select";
            
            let selectAllCheckbox = (document.createElement("input")) as HTMLInputElement;
            selectAllCheckbox.type = "checkbox";
            selectAllCheckbox.className = "input__chk-select-all";
            selectAllCheckbox.addEventListener("click", this.handleSelectAll.bind(this));

            selectAllContainer.appendChild(selectAllCheckbox);
            theadRow.appendChild(selectAllContainer);
            
            ++columnCount;
        }
        
        for (let _i = 0; _i < tableData.columnCount; _i++)
        {
            let theadCol = (document.createElement("th")) as HTMLTableCellElement;
            theadCol.className = (`col__${_i}`);
            if (tableData.header[_i] != undefined)
            {
                theadCol.innerText = tableData.header[_i].toString();
            }
            theadRow.appendChild(theadCol);
        }
        
        if (this.props.hasView)
        {
            let theadCol = (document.createElement("th")) as HTMLTableCellElement;
            theadCol.className = "col__ctrl--view";
            theadRow.appendChild(theadCol);
            
            ++columnCount;
        }
        
        if (this.props.hasEdit)
        {
            let theadCol = (document.createElement("th")) as HTMLTableCellElement;
            theadCol.className = "col__ctrl--edit";
            theadRow.appendChild(theadCol);
            
            ++columnCount;
        }
        
        if (this.props.hasDelete)
        {
            let theadCol = (document.createElement("th")) as HTMLTableCellElement;
            theadCol.className = "col__ctrl--delete";
            theadRow.appendChild(theadCol);
            
            ++columnCount;
        }
        
        thead.appendChild(theadRow);

        let tbody = table.createTBody();
        tbody.className = "table__body";
        
        let rowCounter = 0;
        for (let row of tableData.rows)
        {
            ++rowCounter;
            let itemGuid = "";
            
            let tableRow = (document.createElement("tr")) as HTMLTableRowElement;
            tableRow.setAttribute("data-row-id", String(rowCounter));

            if (this.props.selectable) {
                let rowCell = (document.createElement("td")) as HTMLTableCellElement;
                let selectRowCheckbox = (document.createElement("input")) as HTMLInputElement;
                selectRowCheckbox.type = "checkbox";
                selectRowCheckbox.className = "input__chk--select-row";
                selectRowCheckbox.addEventListener("click", this.handleSelectRow.bind(this));
                rowCell.appendChild(selectRowCheckbox);
                tableRow.appendChild(rowCell);
            }

            let caughtGuid = false;
            for (let cell of row)
            {
                if (caughtGuid === false) {
                    itemGuid = cell;
                    caughtGuid = true;
                    continue;
                }

                let rowCell = (document.createElement("td")) as HTMLTableCellElement;
                rowCell.innerText = cell;
                tableRow.appendChild(rowCell);
            }
            
            if (this.props.hasView) {
                let rowCell = (document.createElement("td")) as HTMLTableCellElement;
                let viewLink = (document.createElement("button")) as HTMLButtonElement;
                viewLink.innerText = "View";
                viewLink.className = "btn__view";
                viewLink.setAttribute("data-id", itemGuid);
                rowCell.appendChild(viewLink);
                tableRow.appendChild(rowCell);
            }
            
            if (this.props.hasEdit)
            {
                let rowCell = (document.createElement("td")) as HTMLTableCellElement;
                let editLink = (document.createElement("button")) as HTMLButtonElement;
                editLink.innerText = "Edit";
                editLink.className = "btn__edit";
                editLink.setAttribute("data-id", itemGuid);
                rowCell.appendChild(editLink);
                tableRow.appendChild(rowCell);
            }
            
            if (this.props.hasDelete)
            {
                let rowCell = (document.createElement("td")) as HTMLTableCellElement;
                let deleteLink = (document.createElement("button")) as HTMLButtonElement;
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

        if (this.props.showRowCount)
        {
            let tfoot = table.createTFoot();
            tfoot.className = "table__foot";
            let footerRow = (document.createElement("tr")) as HTMLTableRowElement;
            let footerCell = (document.createElement("td")) as HTMLTableCellElement;
            footerCell.setAttribute("colspan", String(columnCount));
            footerCell.innerText = "Total number of rows: " + tableData.totalNumberOfRows;
            footerRow.appendChild(footerCell);
            tfoot.appendChild(footerRow);
            table.appendChild(tfoot);
        }
        
        table.setAttribute("data-ready", "true");
    }

    handleSelectAll() {
        console.log("Toggle select all");
        let checkboxes = document.querySelectorAll(".input__chk--select-row");
        checkboxes.forEach(function(checkbox) {

        });
    }
    
    handleSelectRow(e) {
       console.log("Toggle select row");
    }

}

export default TesseractTable;