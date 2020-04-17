import TesseractTable from "../../_tesseract/table";
import TableOptions from "../../_tesseract/table/interfaces/TableOptions";
import DrawerOptions from "../../_tesseract/drawer/interfaces/DrawerOptions";
import TesseractDrawer from "../../_tesseract/drawer";

class ReferenceCollectionPage
{
    tesseractTable: any;
    tesseractDrawer: any;
    createCollectionBtn: HTMLButtonElement;
    createUrl: string;
    public tableDataUrl: string;

    constructor() {
        this.createUrl = "/Settings/ReferenceData/CreateReferenceCollection";
        this.createCollectionBtn = <HTMLButtonElement> document.querySelector("#CreateReferenceCollection");
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceCollections/";
        this.init();
    }
    
    init() {
        this.generateTable();   
        this.createCollectionBtn.addEventListener('click', this.generateCreateCollectionDrawer.bind(this));
    }
    
    generateTable() {
        let tableOptions = new class implements TableOptions {
            hasDelete: boolean;
            hasEdit: boolean = true;
            hasPagination: boolean;
            hasSort: boolean;
            hasView: boolean = true;
            pageCount: number;
            requestUrl: string;
            selectable: boolean;
            showRowCount: boolean = true;
        };
        tableOptions.requestUrl = this.tableDataUrl;
        this.tesseractTable = new TesseractTable(tableOptions);
    }
    
    generateCreateCollectionDrawer() {
        let drawerOptions = new class implements DrawerOptions {
            contentUrl: string;
            hasCancelButton: boolean = true;
            hasSaveButton: boolean = true;
            title: string;
        };
        drawerOptions.contentUrl = this.createUrl;
        this.tesseractDrawer = new TesseractDrawer(drawerOptions); 
    }
}

export default ReferenceCollectionPage;