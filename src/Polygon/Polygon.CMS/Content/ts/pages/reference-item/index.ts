import TesseractTable from "../../_tesseract/table";
import TableOptions from "../../_tesseract/table/interfaces/TableOptions";
import DrawerOptions from "../../_tesseract/drawer/interfaces/DrawerOptions";
import TesseractDrawer from "../../_tesseract/drawer";

class ReferenceItemPage {

    tesseractTable: any;
    tesseractDrawer: any;
    createItemBtn: HTMLButtonElement;
    createUrl: string;
    tableDataUrl: string;
    referenceCollectionId: string;

    constructor() {
        this.referenceCollectionId = document.querySelector("#ReferenceCollectionId").getAttribute("value");
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceItems/?guid=" + this.referenceCollectionId;
        this.createUrl = "/Settings/ReferenceData/CreateReferenceItem/?id=" + this.referenceCollectionId;
        this.createItemBtn = document.querySelector("#CreateReferenceItem");
        this.init();
    }

    init() {
        this.generateTable();
        this.createItemBtn.addEventListener('click', this.generateCreateItemDrawer.bind(this));

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
            hasDelete = true;
            hasEdit = true;
            hasPagination: boolean;
            hasSort: boolean;
            hasView: boolean;
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
        const editButtons = document.querySelectorAll(".btn__edit");
        for (const editButton of editButtons)
        {
            const dataGuid = editButton.getAttribute("data-id");
            const updateUrl = "/Settings/ReferenceData/UpdateReferenceItem/?id=" + dataGuid;
            editButton.addEventListener("click", function() {
                ReferenceItemPage.generateUpdateItemDrawer(updateUrl);
            });
        }
        
        const deleteButtons = document.querySelectorAll(".btn__delete");
        for (const deleteButton of deleteButtons)
        {
            const dataGuid = deleteButton.getAttribute("data-id");
            const deleteUrl = "/Settings/ReferenceData/DeleteReferenceItem/?id=" + dataGuid;
            deleteButton.addEventListener("click", function() {
               ReferenceItemPage.generateDeleteItemDrawer(deleteUrl); 
            });
        }
    }

    generateCreateItemDrawer() {
        let drawerOptions = new class implements DrawerOptions {
            contentUrl: string;
            hasCancelButton: boolean = true;
            hasSaveButton: boolean = true;
            title: string;
        };
        drawerOptions.contentUrl = this.createUrl;
        new TesseractDrawer(drawerOptions);
    }

    private static generateUpdateItemDrawer(updateUrl: string) {
        let drawerOptions = new class implements DrawerOptions {
            contentUrl: string;
            hasCancelButton: boolean = true;
            hasSaveButton: boolean = true;
            title: string;
        };
        drawerOptions.contentUrl = updateUrl;
        new TesseractDrawer(drawerOptions);
    }
    
    private static generateDeleteItemDrawer(deleteUrl: string) {
        let drawerOptions = new class implements DrawerOptions {
          contentUrl: string;
          hasCancelButton: boolean = true;
          hasSaveButton: boolean = true;
          title: string;
        };
        drawerOptions.contentUrl = deleteUrl;
        new TesseractDrawer(drawerOptions);
    }
    
}

export default ReferenceItemPage;