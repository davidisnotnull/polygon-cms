import * as ClassicEditor from "@ckeditor/ckeditor5-build-classic";

class TesseractWysiwyg
{
    wysiwygElement: HTMLElement;

    constructor()
    {
        this.wysiwygElement = document.querySelector(".tesseract__wysiwyg");
        this.init();
    }

    init() {
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
            .catch(e => {
                console.error("Error :", e);
            })
    }
}

export default TesseractWysiwyg; 