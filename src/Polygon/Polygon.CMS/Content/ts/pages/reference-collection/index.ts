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
        this.createCollectionBtn = document.querySelector("#CreateReferenceCollection") as HTMLButtonElement;
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceCollections/";
        this.init();
    }
    
    init() {
        this.generateTable();   
        this.createCollectionBtn.addEventListener('click', this.generateCreateCollectionDrawer.bind(this));
        
        const targetNode = document.querySelector(".tesseract__drawer");
        const mutationConfig = { attributes: true, attributeOldValue: true, attributeFilter: ["data-state"] }
        const onMutation = mutations => {
            for(const mutation of mutations) {
                console.log(mutation);
                if (mutation.oldValue == "open")
                {
                    console.log("Mutating");
                    this.refreshTable();                
                }
            }
        }
        const observer = new MutationObserver(onMutation);
        observer.observe(targetNode, mutationConfig);
    }
    
    refreshTable() {
        const table = document.querySelector(".tesseract__table");
        table.innerHTML = "";
        this.generateTable();
    }
    
    generateTable() {
        const tableOptions = new class implements TableOptions {
            hasDelete: boolean;
            hasEdit = true;
            hasPagination: boolean;
            hasSort: boolean;
            hasView = true;
            pageCount: number;
            requestUrl: string;
            selectable: boolean;
            showRowCount = true;
        };
        tableOptions.requestUrl = this.tableDataUrl;
        new TesseractTable(tableOptions);

        const targetNode = document.querySelector(".tesseract__table");
        const mutationConfig = { attributes: true, attributeFilter: ["data-ready"] };
        const onMutation = mutations => {
            for(const mutation of mutations) {
                observer.disconnect();
                this.addEventHandlers();
            }
        }
        const observer = new MutationObserver(onMutation);
        observer.observe(targetNode, mutationConfig);
    }

    addEventHandlers() {
        const viewButtons = document.querySelectorAll(".btn__view");
        for (const viewButton of viewButtons)
        {
            const dataGuid = viewButton.getAttribute("data-id");
            viewButton.addEventListener("click", function(){
                window.location.href = "/Settings/ReferenceData/Details/?guid=" + dataGuid;
            });
        }
        
        const editButtons = document.querySelectorAll(".btn__edit");
        for (const editButton of editButtons)
        {
            const dataGuid = editButton.getAttribute("data-id");
            const updateUrl = "/Settings/ReferenceData/UpdateReferenceCollection/?id=" + dataGuid;
            editButton.addEventListener("click", function() {
                ReferenceCollectionPage.generateUpdateCollectionDrawer(updateUrl);
            });            
        }
        
    }
    
    generateCreateCollectionDrawer() {
        let drawerOptions = new class implements DrawerOptions {
            contentUrl: string;
            hasCancelButton: boolean = true;
            hasSaveButton: boolean = true;
            title: string;
        };
        drawerOptions.contentUrl = this.createUrl;
        new TesseractDrawer(drawerOptions); 
    }
    
    private static generateUpdateCollectionDrawer(updateUrl: string) {
        let drawerOptions = new class implements DrawerOptions {
            contentUrl: string;
            hasCancelButton: boolean = true;
            hasSaveButton: boolean = true;
            title: string;
        };
        drawerOptions.contentUrl = updateUrl;
        new TesseractDrawer(drawerOptions);
    }

}

export default ReferenceCollectionPage;