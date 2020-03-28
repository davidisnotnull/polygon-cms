import * as $ from "jquery";
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
        this.tesseractModal = new TesseractModal();
        this.submitUrl = "/Settings/ReferenceTypes/CreateReferenceType";
        this.saveButton = document.querySelector(".modal__save");
        
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceCollections/";
        this.tesseractTable = new TesseractTable(this.tableDataUrl);
                
        this.Initialise();
    }

    public Initialise() {
        this.saveButton.addEventListener("click", (event: Event) => {
            event.preventDefault();
            this.SaveReferenceType();
        });
        
        
    }

    public SaveReferenceType() {
        $("#TesseractModal [type=submit]").attr("disabled", "");
        
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
        })
            .catch(e => {
                console.log("Error :", e)
            });
    }
}