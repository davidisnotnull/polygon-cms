import Table from './interfaces/Table';
import TableProps from './interfaces/TableProps';
import './styles';

class TesseractTable
{
    requestUrl: string;
    selectable: boolean;
    hasView: boolean;
    hasEdit: boolean;
    hasDelete: boolean;
    
   constructor(props: TableProps) {
       this.requestUrl = props.requestUrl;
       this.selectable = props.selectable;
       this.hasView = props.hasView;
       this.hasEdit = props.hasEdit;
       this.hasDelete = props.hasDelete;
       
       this.init();
   }
    
    init(){
        this.getTableData();
    }
    
    getTableData() {
        fetch(this.requestUrl, {
            method: 'POST'
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
        let table: HTMLTableElement = <HTMLTableElement> document.querySelector('.tesseract__table');

        let thead = table.createTHead();
        thead.className = 'table__head';
        
        let theadRow: HTMLTableRowElement = <HTMLTableRowElement>(document.createElement('tr'));
        
        let columnCount = tableData.columnCount;

        if (this.selectable)
        {   
            let selectAllContainer = <HTMLTableCellElement>(document.createElement('th'));
            selectAllContainer.className = 'col__select';
            
            let selectAllCheckbox = <HTMLInputElement>(document.createElement('input'));
            selectAllCheckbox.type = 'checkbox';
            selectAllCheckbox.className = 'input__chk-select-all';
            selectAllCheckbox.addEventListener('click', this.handleSelectAll.bind(this));

            selectAllContainer.appendChild(selectAllCheckbox);
            theadRow.appendChild(selectAllContainer);
        }
        
        for (let _i = 0; _i < columnCount; _i++)
        {
            let theadCol = <HTMLTableCellElement>(document.createElement('th'));
            theadCol.className = ("col__" + _i);
            if (tableData.header[_i] != undefined)
            {
                theadCol.innerText = tableData.header[_i].toString();
            }
            theadRow.appendChild(theadCol);
        }
        
        if (this.hasView)
        {
            let theadCol = <HTMLTableCellElement>(document.createElement('th'));
            theadCol.className = 'col__ctrl--view';
            theadRow.appendChild(theadCol);
        }
        
        if (this.hasEdit)
        {
            let theadCol = <HTMLTableCellElement>(document.createElement('th'));
            theadCol.className = 'col__ctrl--edit';
            theadRow.appendChild(theadCol);
        }
        
        if (this.hasDelete)
        {
            let theadCol = <HTMLTableCellElement>(document.createElement('th'));
            theadCol.className = 'col__ctrl--delete';
            theadRow.appendChild(theadCol);
        }
        
        thead.appendChild(theadRow);

        let tbody = table.createTBody();
        tbody.className = 'table__body';
        
        let rowCounter = 0;
        for (let row of tableData.rows)
        {
            ++rowCounter;
            
            let tableRow = <HTMLTableRowElement>(document.createElement('tr'));
            tableRow.setAttribute('data-row-id', String(rowCounter));

            if (this.selectable) {
                let rowCell = <HTMLTableCellElement>(document.createElement('td'));
                let selectRowCheckbox = <HTMLInputElement>(document.createElement('input'));
                selectRowCheckbox.type = 'checkbox';
                selectRowCheckbox.className = 'input__chk--select-row';
                selectRowCheckbox.addEventListener('click', this.handleSelectRow.bind(this));
                rowCell.appendChild(selectRowCheckbox);
                tableRow.appendChild(rowCell);
            }

            for (let cell of row)
            {
                let rowCell = <HTMLTableCellElement>(document.createElement('td'));
                rowCell.innerText = cell;
                tableRow.appendChild(rowCell);
            }
            
            if (this.hasView) {
                let rowCell = <HTMLTableCellElement>(document.createElement('td'));
                let viewLink = <HTMLButtonElement >(document.createElement('button'));
                viewLink.innerText = 'View';
                viewLink.className = 'btn__view';
                rowCell.appendChild(viewLink);
                tableRow.appendChild(rowCell);
            }
            
            if (this.hasEdit)
            {
                let rowCell = <HTMLTableCellElement>(document.createElement('td'));
                let viewLink = <HTMLButtonElement >(document.createElement('button'));
                viewLink.innerText = 'Edit';
                viewLink.className = 'btn__edit';
                rowCell.appendChild(viewLink);
                tableRow.appendChild(rowCell);
            }
            
            tbody.appendChild(tableRow);
        }

        table.appendChild(thead);
        table.appendChild(tbody);
    }

    handleSelectAll() {
        console.log("Toggle select all");
        let checkboxes = document.querySelectorAll('.input__chk--select-row');
        checkboxes.forEach(function(checkbox) {
            
        })
    }
    
    handleSelectRow(e) {
       console.log('Toggle select row');
    }

}

export default TesseractTable;