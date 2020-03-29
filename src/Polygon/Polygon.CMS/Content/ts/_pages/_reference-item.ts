import { TesseractModal } from "../_tesseract/_tesseract-modal";
import { TesseractTable } from "../_tesseract/_tesseract-table";

export class ReferenceItemPage {

    public tesseractModal: any;
    public tesseractTable: any;
    public referenceCollectionId: string;
    public saveButton: any;
    public saveUrl: any;
    public updateUrl: any;
    public deleteUrl: any;
    public tableDataUrl: string;

    constructor() {
        this.referenceCollectionId = document.querySelector("#ReferenceCollectionId").getAttribute("value");
        this.saveButton = document.querySelector(".modal__save");
        this.tableDataUrl = "/api/tesseract/TableApi/GetReferenceItems/?guid=" + this.referenceCollectionId;
        this.saveUrl = "/Settings/ReferenceData/CreateReferenceItem/";
        this.updateUrl = "/Settings/ReferenceData/UpdateReferenceItem/";
        this.deleteUrl = "/Settings/ReferenceData/DeleteReferenceItem/";
        this.tesseractTable = new TesseractTable(this.tableDataUrl);
        this.tesseractModal = new TesseractModal();
        
        this.Initialise();
    }

    public Initialise(){
        this.saveButton.addEventListener("click", (event: Event) => {
            event.preventDefault();
            let action = this.saveButton.getAttribute("data-action");
            this.SubmitForm(action);
        });
    }
    
    public SubmitForm(action: string)
    {
        switch (action) {
            case "save":
                this.SaveReferenceItem();
                break;
            case "edit":
                this.UpdateReferenceItem();
                break;
            case "delete":
                this.DeleteReferenceItem();
                break;
        }
    }
    
    private SaveReferenceItem()
    {
        this.saveButton.setAttribute("disabled", "");

        let form: any;
        form = document.querySelector(".modal__form");
        const formData = new FormData(form);

        let token = document.querySelector('input[name="__RequestVerificationToken"]').getAttribute("value");
        
        fetch(this.saveUrl, {
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
    
    private UpdateReferenceItem()
    {
        this.saveButton.setAttribute("disabled", "");
        
        let form: any;
        form = document.querySelector(".modal__form");
        const formData = new FormData(form);
        
        let token = document.querySelector('input[name="__RequestVerificationToken"]').getAttribute("value");
                
        fetch(this.updateUrl, {
            method: "POST",
            headers: {
                "RequestVerificationToken": token
            },
            body: formData
        })
            .then(r => r.status)
            .then(s => {
                this.tesseractModal.CloseModel();
                this.tesseractTable.Refresh();
                this.saveButton.removeAttribute("disabled");
            })
            .catch(e => {
                console.log("Error :", e)
            });
    }
    
    private DeleteReferenceItem()
    {
        
        
        
    }
}