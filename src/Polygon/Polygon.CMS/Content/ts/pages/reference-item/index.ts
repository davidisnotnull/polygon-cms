import TesseractTable from "../../_tesseract/table";

class ReferenceItemPage {

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
        this.Initialise();
    }

    public Initialise(){
        this.saveButton.addEventListener("click", (event: Event) => {
            event.preventDefault();
            this.SubmitForm(this.saveButton);
        });
    }
    
    public SubmitForm(button: any)
    {
        let action = button.getAttribute("data-action");
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

export default ReferenceItemPage;