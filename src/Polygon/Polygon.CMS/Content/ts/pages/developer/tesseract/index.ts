import TesseractNotify from '../../../_tesseract/notify/';
import NotifyOptions from "../../../_tesseract/notify/interfaces/NotifyOptions";

class TesseractDeveloperPage {

    constructor() {
        this.init();
    }
    
    init() {
        let notifyTrigger = document.querySelector("#FireNotification");
        notifyTrigger.addEventListener('click', this.fireNotification.bind(this));
    }
    
    fireNotification() {
        console.info("Firing Tesseract notification");
        let notifyOptions = new class implements NotifyOptions {
            message: string;
            type: string;
        }
        notifyOptions.message = "Here's your test notification";
        notifyOptions.type = "error";
        new TesseractNotify(notifyOptions);
    }
    
}

export default TesseractDeveloperPage;