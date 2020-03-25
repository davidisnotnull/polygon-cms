export class TesseractTable
{
    public dataTable: HTMLElement;
    public requestUrl: string;
    
    constructor() {
        this.dataTable = document.querySelector("tesseract__table");
        this.requestUrl = this.dataTable.getAttribute("data-url");
        this.Initialise();
    }
    
    public Initialise(){
        fetch(this.requestUrl)
            .then(r => r.text())
            .then(f => {
                let tableHead = 
            }).catch(e => {
            console.log("Error: ", e)
        });
    }
}