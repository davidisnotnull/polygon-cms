import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic"

export class TesseractWysiwyg
{
    public wysiwygElement: HTMLElement;
    
    constructor()
    {
        this.wysiwygElement = document.querySelector(".tesseract__wysiwyg");
        this.init();
    }
    
    public init() {
        console.log(this.wysiwygElement);
        ClassicEditor
            .create(this.wysiwygElement, {
                toolbar: [ 'heading', '|', 'bold', 'italic', 'link', 'bulletedList', 'numberedList', 'blockQuote'],
                heading: {
                    options: [
                        { model: 'paragraph', title: 'Paragraph', class: 'ck-heading__paragraph' },
                        { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading__heading1' },
                        { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading__heading2' }
                    ]
                }
            })
            .then(editor => {
                console.log(editor)
            })
            .catch(e => {
                console.error("Error :", e);
            })
    }
}