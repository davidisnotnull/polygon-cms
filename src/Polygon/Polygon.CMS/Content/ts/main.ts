import * as $ from "jquery";
(<any>window).jQuery = $;

import "popper.js";
import "bootstrap";
import "preact";

/* Tesseract */
import { TesseractModal } from "./_tesseract/_tesseract-modal";
import TesseractWysiwyg from "./_tesseract/wysiwyg";

/* Utility classes */

/* Pages */
import ReferenceCollectionPage from "./pages/reference-collection";
import ReferenceItemPage from "./pages/reference-item";
import CookieSettingsPage from "./pages/cookie-settings";

/* Script loader */
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

/* Styles */
import "../scss/main.scss";