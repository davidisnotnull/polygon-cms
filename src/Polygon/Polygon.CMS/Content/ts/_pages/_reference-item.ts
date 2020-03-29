import { TesseractModal } from "../_tesseract/_tesseract-modal";
import { TesseractTable } from "../_tesseract/_tesseract-table";

export class ReferenceItemPage {

    public tesseractModal: any;
    public tesseractTable: any;
    public referenceCollectionId: string;
    public saveButton: any;
    public submitUrl: any;
    public tableDataUrl: string;

    constructor() {
        this.referenceCollectionId = document.querySelector("#ReferenceCollectionId").getAttribute("value");
        this.saveButton = document.querySelector(".modal__save");
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceItems/?guid=" + this.referenceCollectionId;
        this.submitUrl = "/Settings/ReferenceData/CreateReferenceItem/";
        this.tesseractTable = new TesseractTable(this.tableDataUrl);
        this.tesseractModal = new TesseractModal();
        
        this.Initialise();
    }

    public Initialise(){
        this.saveButton.addEventListener("click", (event: Event) => {
            event.preventDefault();
            this.SaveReferenceItem();
        });
    }
    
    public SaveReferenceItem()
    {
        this.saveButton.setAttribute("disabled", "");

        let form: any;
        form = document.querySelector(".modal__form");
        const formData = new FormData(form);

        let token = document.querySelector('input[name="__RequestVerificationToken"]').getAttribute("value");

        fetch(this.submitUrl, {
            method: "POST",
            headers: {
              "RequestVerificationToken": token
            },
            body: formData
        })
            .then(r => r.status)
            .then(s => {
                this.tesseractModal.CloseModal();
                this.tesseractTable.Refresh();
                this.saveButton.removeAttribute("disabled");
            })
            .catch(e => {
                console.log("Error :", e)
            });
    }
}