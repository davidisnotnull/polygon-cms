import { TesseractModal } from "../_tesseract/_tesseract-modal";
import { TesseractTable } from "../_tesseract/_tesseract-table";

export class ReferenceCollectionPage
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
        this.tesseractTable = new TesseractTable(this.tableDataUrl);

        this.tesseractModal = new TesseractModal();
                
        this.Initialise();
    }

    public Initialise() {
        this.saveButton.addEventListener("click", (event: Event) => {
            event.preventDefault();
            this.SaveReferenceType();
        });
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
            this.tesseractModal.Initialise();
            this.tesseractTable.Refresh();
            this.saveButton.removeAttribute("disabled");
        })
            .catch(e => {
                console.log("Error :", e)
            });
    }
}