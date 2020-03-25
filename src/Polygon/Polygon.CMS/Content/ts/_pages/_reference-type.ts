import * as $ from "jquery";
import { TesseractModal } from "../_tesseract/_tesseract-modal";

export class ReferenceTypePage 
{
    public tesseractModal: any;
    public saveButton: any;
    public submitUrl: any;

    constructor() {
        this.tesseractModal = new TesseractModal();
        this.submitUrl = "/Settings/ReferenceTypes/CreateReferenceType";
        this.saveButton = document.querySelector(".modal__save");
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
        })
            .catch(e => {
                console.log("Error :", e)
            });
    }
}