import { TesseractModal } from "../../_tesseract/_tesseract-modal";
import TesseractTable from "../../_tesseract/table";
import TableProps from "../../_tesseract/table/interfaces/TableProps";

class ReferenceCollectionPage
{
    public tesseractModal: any;
    public tesseractTable: any;
    public saveButton: any;
    public submitUrl: any;
    public tableDataUrl: string;

    constructor() {
        this.submitUrl = "/Settings/ReferenceData/CreateReferenceCollection";
        this.saveButton = document.querySelector(".modal__save");
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceCollections/";
        this.tesseractModal = new TesseractModal();
        this.init();
    }
    
    init() {
        this.generateTable();       
        this.saveButton.addEventListener("click", (event: Event) => {
            event.preventDefault();
            this.SaveReferenceType();
        });
    }
    
    generateTable() {
        let tableProps = new class implements TableProps {
            hasDelete: boolean = true;
            hasEdit: boolean = true;
            hasPagination: boolean = false;
            hasSort: boolean = false;
            hasView: boolean = true;
            pageCount: number;
            requestUrl: string;
            selectable: boolean = true;
            showRowCount: boolean = true;
        };
        tableProps.requestUrl = this.tableDataUrl;
        this.tesseractTable = new TesseractTable(tableProps);
    }

    public SaveReferenceType() {
        this.saveButton.setAttribute("disabled", "");
        
        let form: any;
        form = document.querySelector(".modal__form");
        const formData = new FormData(form);
        
        fetch(this.submitUrl, {
            method: "POST",
            body: formData
        })
        .then(r => r.status)
        .then(s => {
            this.tesseractModal.CloseModal();
            this.tesseractTable.Refresh();
            this.saveButton.removeAttribute("disabled");
        }).then(m => {
            this.tesseractModal.Initialise();
        })
            .catch(e => {
                console.log("Error :", e)
            });
    }
}

export default ReferenceCollectionPage;