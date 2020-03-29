import * as $ from "jquery";
(<any>window).jQuery = $;

import "popper.js";
import "bootstrap";

/* Tesseract */
import { TesseractModal } from "./_tesseract/_tesseract-modal";
import { TesseractWysiwyg } from "./_tesseract/_tesseract-wysiwyg";

/* Utility classes */

/* Pages */
import { ReferenceCollectionPage } from "./_pages/_reference-collection";
import { ReferenceItemPage} from "./_pages/_reference-item";
import { CookieSettingsPage } from "./_pages/_cookie-settings";

$(document).ready(function () {
    new TesseractModal();    

    /* Load Reference Collection Page scripts */
    if (document.querySelector('.page__reference-collection'))
    {
        new ReferenceCollectionPage();
    }
    
    /* Load Reference Item Page scripts */
    if (document.querySelector(".page__reference-item"))
    {
        new ReferenceItemPage();
    }
    
    /* Load Cookie Settings Page scripts */
    if (document.querySelector(".page__cookie-settings"))
    {
        new TesseractWysiwyg();
        new CookieSettingsPage();
    }
    
});

import "../scss/main.scss";