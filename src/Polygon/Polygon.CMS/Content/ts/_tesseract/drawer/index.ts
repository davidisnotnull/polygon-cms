import DrawerOptions from './interfaces/DrawerOptions';
import './styles';

const utils = require('../_utils');

class TesseractDrawer {
    
    props: DrawerOptions;
           
    constructor(props: DrawerOptions)
    {
        this.props = props;
        this.init();
    }
    
    init() {
        this.createModalOverlay();
        this.openDrawer();
        this.getDrawerContent();
    }
    
    getDrawerContent() {
        fetch(this.props.contentUrl, {
            method: 'GET'
        })        
            .then(r => r.text())
            .then(data => {
                this.constructDrawer(data);
            })
            .catch(error => {
                console.error(error);
                return '';
            });
    }
    
    constructDrawer(data: any) {
        let drawer : HTMLDivElement = <HTMLDivElement> document.querySelector('.tesseract__drawer');
        let drawerHeading: HTMLDivElement = <HTMLDivElement> document.querySelector('.drawer__heading');
        let drawerContent: HTMLDivElement = <HTMLDivElement> document.querySelector('.drawer__content');
        let drawerFooter: HTMLDivElement = <HTMLDivElement> document.querySelector('.drawer__footer');

        drawer.setAttribute("data-state", "open")
        
        if (this.props.title != undefined)
        {
            let title = <HTMLHeadingElement>(document.createElement('h4'));
            title.innerText = this.props.title;
            drawerHeading.appendChild(title);
        }
        
        if (data != undefined)
        {
            drawerContent.innerHTML = data;
        }
        
        if (this.props.hasCancelButton) {
            let cancelButton = <HTMLButtonElement>(document.createElement('button'));
            cancelButton.innerText = 'Cancel';
            cancelButton.className = 'btn-cancel';
            cancelButton.addEventListener('click', this.handleCancelClick.bind(this));
            drawerFooter.appendChild(cancelButton);
        }
        
        if (this.props.hasSaveButton) {
            let saveButton = <HTMLButtonElement>(document.createElement('button'));
            saveButton.innerText = 'Save';
            saveButton.type = 'button';
            saveButton.addEventListener('click', this.saveFunction.bind(this));
            drawerFooter.appendChild(saveButton);
        }
    }
    
    createModalOverlay() {
        let body : HTMLElement = <HTMLElement> document.querySelector('body');
        let overlay = <HTMLDivElement>(document.createElement('div'));
        overlay.className = 'overlay';
        body.appendChild(overlay);
        overlay.animate([
            { opacity: 0 },
            { opacity: 0.5 }
        ], { duration: 200, iterations: 1 });
        overlay.addEventListener('click', this.closeDrawer.bind(this));
    };
    
    destroyModalOverlay() {
        let overlay : HTMLDivElement = <HTMLDivElement> document.querySelector('.overlay');
        let overlayAnimation = overlay.animate([
            { opacity: 0.5 },
            { opacity: 0 }
        ], { duration: 200, iterations: 1 });
        overlayAnimation.onfinish = function() {
            overlay.remove();
        }
    };
    
    dispose = function() {
        let drawer : HTMLDivElement = <HTMLDivElement> document.querySelector('.tesseract__drawer');
        let drawerHeading: HTMLDivElement = <HTMLDivElement> document.querySelector('.drawer__heading');
        let drawerContent: HTMLDivElement = <HTMLDivElement> document.querySelector('.drawer__content');
        let drawerFooter: HTMLDivElement = <HTMLDivElement> document.querySelector('.drawer__footer');
        drawer.hidden = true;
        drawerHeading.innerHTML = null;
        drawerContent.innerHTML = null;
        drawerFooter.innerHTML = null;
        drawer.removeAttribute('style');
        drawer.setAttribute("data-state", "closed")
    };
    
    openDrawer() {
        let drawer : HTMLDivElement = <HTMLDivElement> document.querySelector('.tesseract__drawer');
        drawer.hidden = false;
        let slideIn = drawer.animate([
            { transform: 'translateX(0)', opacity: 0 },
            { transform: 'translateX(-30rem)', opacity: 1 }
        ], { duration: 200, iterations: 1 });
        slideIn.onfinish = function() {
            drawer.setAttribute('style', 'right:0');
        };
    }
    
    closeDrawer() {
        let drawer : HTMLDivElement = <HTMLDivElement> document.querySelector('.tesseract__drawer');
        this.destroyModalOverlay();
        let hideDrawer = drawer.animate([
            { transform: 'translateX(0px)', opacity: 1},
            { transform: 'translateX(30rem)', opacity: 0},
        ], { duration: 200, iterations: 1 });
        hideDrawer.onfinish = this.dispose;
    }
    
    handleCancelClick(e) {
        utils.events.pauseEvent(e);
        this.closeDrawer();
    }
    
    saveFunction(e) {
        utils.events.pauseEvent(e);
        let form = <HTMLFormElement> document.querySelector(".drawer__form");
        const formData = new FormData(form);

        fetch(this.props.contentUrl, {
            method: "POST",
            body: formData
        })
            .then(r => {
                this.closeDrawer();
            })
            .catch(e => {
                console.error("Error :", e)
            });
    }
}

export default TesseractDrawer;