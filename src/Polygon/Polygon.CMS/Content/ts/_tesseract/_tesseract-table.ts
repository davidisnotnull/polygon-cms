interface Table {
    header: any;
    rows: any;
    columnCount: number;
    totalNumberOfRows: number;
}

export class TesseractTable
{
    public tableElement: HTMLElement;
    public requestUrl: string;
    
    constructor(url: string) {
        this.tableElement = document.querySelector(".tesseract__table");
        this.requestUrl = url;
        this.Initialise(url);
    }
    
    public Initialise(url: string)
    {
        fetch(url, {
                method: 'POST'
            })
            .then(r => r.json())
            .then(data => {
                console.log(data);
                this.ConstructTable(data);
            }).catch(e => {
                console.log("Error: ", e)
        });
    }
    
    public Refresh()
    {
        let tableHead = document.querySelector(".table__head");
        tableHead.innerHTML = "";
        
        let tableBody = document.querySelector(".table__body");
        tableBody.innerHTML = "";
        
        fetch(this.requestUrl, {
            method: 'POST'
        })
            .then(r => r.json())
            .then(data => {
                this.ConstructTable(data);
            }).catch(e => {
                console.log("Error: ", e)
        });
    }
    
    private ConstructTable(data: any)
    {
        let table : Table = data;
        
        let tableHeader = document.querySelector(".table__head");
        
        for (let _i = 0; _i < table.columnCount; _i++)
        {
            let theadCol = document.createElement("th");
            theadCol.className += ("col_" + _i);
            if (table.header[_i] != undefined)
            {
                theadCol.innerText = table.header[_i].toString();    
            }
            tableHeader.appendChild(theadCol);
        }
        
        let tableBody = document.querySelector(".table__body");
        let columnCount = 0;
        
        for (let row of table.rows)
        {
            if (columnCount == table.columnCount)
                return;
            
            let tableRow = document.createElement("tr");
            
            for(let cell of row)
            {
                let rowCell = document.createElement("td");
                rowCell.innerHTML = cell;
                tableRow.appendChild(rowCell);
            }
            
            tableBody.appendChild(tableRow);
            ++columnCount;
        }
    }   
}