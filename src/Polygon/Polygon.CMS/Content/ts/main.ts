import * as $ from "jquery";
(<any>window).jQuery = $

import "popper.js";
import "bootstrap";

/* Tesserat */
import { TesseractModal } from "./_tesseract/_tesseract-modal";

/* Utility classes */

/* Pages */
import { ReferenceTypePage } from "./_pages/_reference-type";

$(document).ready(function () {
    console.log("Polygon CMS Version 1.0");
    new TesseractModal();

    /* Load Reference Type scripts */
    if (document.querySelector('.page__reference-type'))
    {
        new ReferenceTypePage();
    }

});

import "../scss/main.scss";