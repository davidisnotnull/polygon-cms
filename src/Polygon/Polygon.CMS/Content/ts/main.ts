import * as $ from "jquery";
(<any>window).jQuery = $;

import "popper.js";
import "bootstrap";

/* Tesseract */
import { TesseractModal } from "./_tesseract/_tesseract-modal";

/* Utility classes */

/* Pages */
import { ReferenceCollectionPage } from "./_pages/_reference-collection";
import { ReferenceItemPage} from "./_pages/_reference-item";

$(document).ready(function () {
    console.log("Polygon CMS Version 1.0");
    new TesseractModal();    

    /* Load Reference Type scripts */
    if (document.querySelector('.page__reference-collection'))
    {
        new ReferenceCollectionPage();
    }
    
    if (document.querySelector(".page__reference-item"))
    {
        new ReferenceItemPage();
    }
});

import "../scss/main.scss";