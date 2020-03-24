import * as $ from "jquery";
(<any>window).jQuery = $

import "popper.js";
import "bootstrap";

/* Tesserat */
import { TesseractModal } from "./_tesseract/_tesseract-modal";

/* Utility classes */
import { AjaxRequest } from "./_utils/_ajax-request";

/* Pages */
import { ReferenceTypePage } from "./_pages/_reference-type";

$(document).ready(function () {
    console.log("Polygon CMS Version 1.0");
    new TesseractModal();

    if (document.querySelector('#referenceTypePage'))
    {
        new ReferenceTypePage();
    }

});

import "../scss/main.scss";