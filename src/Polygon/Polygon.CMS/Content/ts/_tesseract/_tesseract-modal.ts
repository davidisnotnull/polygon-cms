import * as $ from "jquery";

export class TesseractModal 
{
    public modalElement: HTMLElement;
    public modalTitle: any;
    public modalBody: any;
    public modalFooter: any;
    public modalButtons: any;
    public saveButton: any;

    constructor() {
        this.modalElement = document.querySelector('#TesseractModal');
        this.modalTitle = this.modalElement.querySelector('#modal-title');
        this.modalBody =- this.modalElement.querySelector('#modal-content');
        this.modalButtons = document.querySelectorAll(".tesseract__modal");
        this.Initialise();
    }

    public Initialise()
    {
        Array.from(this.modalButtons).forEach((button: any) => {
            button.addEventListener("click", (event: Event) => {
                event.preventDefault();
                let url = button.getAttribute("href") ? button.getAttribute("href") : button.getAttribute("data-url")
                let size = button.getAttribute("data-size");
                this.ShowModalWindow(url, size)
            });
        });
    }

    public ShowModalWindow(url: string, size: string)
    {
        let options = {
            backdrop: "static"
        };
        
        this.SetWindowSize(size);

        fetch(url)
            .then(r => r.text())
            .then(f => {
                console.log(f);
                $("#TesseractModal .dynamic").html(f);
                $("#TesseractModal").modal(options);
        }).catch(e => {
            console.log("Error: ", e)
        });
    }

    public ShowCustomModalWindow(title: string, content: string, size: string)
    {
        let options = {
            backdrop: "static"
        };
        
        this.SetWindowSize(size);

        $("#TesseractModal .modal-title").html(title);
        $("#TesseractModal .modal-body").html(content);
        $("#TesseractModal").modal(options);
    }

    public ReplaceModalContent(url: string)
    {
        $.get(url, function (data) {
            $("#TesseractModal .dynamic").html(data);
        });
    }

    public CloseModal()
    {
        $("#TesseractModal .dynamic").html("");
        $("#TesseractModal").modal("hide");
        $(".modal-backdrop").remove();
    }

    public SetWindowSize(size: string)
    {
        let modal =  $("#TesseractModal > .modal-dialog").removeClass(
            "modal-lg modal-sm modal-md");

        if (size) {
            switch (size) {
                case "small":
                    modal.addClass("modal-sm");
                    break;
                case "large":
                    modal.addClass("modal-lg");
                    break;
                default:
                    modal.addClass("modal-md");
                    break;
            }
        } else {
            modal.addClass("modal-md");
        }
    }
}