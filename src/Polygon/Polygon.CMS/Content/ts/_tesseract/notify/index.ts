import NotifyOptions from "./interfaces/NotifyOptions";

class TesseractNotify {
    
    props: NotifyOptions;
    
    constructor(props: NotifyOptions) {
        this.init();
    }
    
    init() {
        switch (this.props.type)
        {
            case "success": 
                break;
            case "info":
                break;
            case "error": 
                break;
            default:
                break;
        }
    }
    
    showNotification() {
        
    }
    
    hideNotification() {
        
    }
    
}

export default TesseractNotify;