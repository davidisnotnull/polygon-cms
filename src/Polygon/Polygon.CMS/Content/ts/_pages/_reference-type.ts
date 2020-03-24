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
        this.Initialise();
    }

    public Initialise() {
        
    }

    public SaveReferenceType() {
        $("#TesseractModal [type=submit]").attr("disabled", "");
        var form = $("#tesseract-modal-content form");
        $.ajax({
            url: "/Settings/ReferenceTypes/CreateReferenceType",
            data: form.serialize(),
            type: 'POST',
            statusCode: {
                200: function () {
                    this.tesseractModal.CloseModalWindow();
                },
                400: function (data) {
                    $("#TesseractModal .modal-content").html(data);
                }
            }
        });
    }

}