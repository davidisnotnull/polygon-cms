import Table from './interfaces/Table';
import TableOptions from './interfaces/TableOptions';
import './styles';

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

        if (this.props.selectable)
        {   
            let selectAllContainer = <HTMLTableCellElement>(document.createElement('th'));
            selectAllContainer.className = 'col__select';
            
            let selectAllCheckbox = <HTMLInputElement>(document.createElement('input'));
            selectAllCheckbox.type = 'checkbox';
            selectAllCheckbox.className = 'input__chk-select-all';
            selectAllCheckbox.addEventListener('click', this.handleSelectAll.bind(this));

            selectAllContainer.appendChild(selectAllCheckbox);
            theadRow.appendChild(selectAllContainer);
            
            ++columnCount;
        }
        
        for (let _i = 0; _i < tableData.columnCount; _i++)
        {
            let theadCol = <HTMLTableCellElement>(document.createElement('th'));
            theadCol.className = ("col__" + _i);
            if (tableData.header[_i] != undefined)
            {
                theadCol.innerText = tableData.header[_i].toString();
            }
            theadRow.appendChild(theadCol);
        }
        
        if (this.props.hasView)
        {
            let theadCol = <HTMLTableCellElement>(document.createElement('th'));
            theadCol.className = 'col__ctrl--view';
            theadRow.appendChild(theadCol);
            
            ++columnCount;
        }
        
        if (this.props.hasEdit)
        {
            let theadCol = <HTMLTableCellElement>(document.createElement('th'));
            theadCol.className = 'col__ctrl--edit';
            theadRow.appendChild(theadCol);
            
            ++columnCount;
        }
        
        if (this.props.hasDelete)
        {
            let theadCol = <HTMLTableCellElement>(document.createElement('th'));
            theadCol.className = 'col__ctrl--delete';
            theadRow.appendChild(theadCol);
            
            ++columnCount;
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

            if (this.props.selectable) {
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
            
            if (this.props.hasView) {
                let rowCell = <HTMLTableCellElement>(document.createElement('td'));
                let viewLink = <HTMLButtonElement >(document.createElement('button'));
                viewLink.innerText = 'View';
                viewLink.className = 'btn__view';
                viewLink.addEventListener('click', this.handleViewClick.bind(this));
                rowCell.appendChild(viewLink);
                tableRow.appendChild(rowCell);
            }
            
            if (this.props.hasEdit)
            {
                let rowCell = <HTMLTableCellElement>(document.createElement('td'));
                let editLink = <HTMLButtonElement >(document.createElement('button'));
                editLink.innerText = 'Edit';
                editLink.className = 'btn__edit';
                editLink.addEventListener('click', this.handleEditClick.bind(this));
                rowCell.appendChild(editLink);
                tableRow.appendChild(rowCell);
            }
            
            if (this.props.hasDelete)
            {
                let rowCell = <HTMLTableCellElement>(document.createElement('td'));
                let deleteLink = <HTMLButtonElement >(document.createElement('button'));
                deleteLink.innerText = 'Delete';
                deleteLink.className = 'btn__delete';
                deleteLink.addEventListener('click', this.handleDeleteClick.bind(this));
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
            tfoot.className = 'table__foot';
            let footerRow = <HTMLTableRowElement>(document.createElement('tr'));
            let footerCell = <HTMLTableCellElement>(document.createElement('td'));
            footerCell.setAttribute('colspan', String(columnCount));
            footerCell.innerText = 'Total number of rows: ' + tableData.totalNumberOfRows;
            footerRow.appendChild(footerCell);
            tfoot.appendChild(footerRow);
            table.appendChild(tfoot);
        }
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
    
    handleViewClick(e) {
        console.log('Clicked on View');
    }
    
    handleEditClick(e) {
        console.log('Clicked on Edit');
    }
    
    handleDeleteClick(e) {
        console.log('Clicked on Delete');
    }
}

export default TesseractTable;