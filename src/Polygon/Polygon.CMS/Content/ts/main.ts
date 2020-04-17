import * as $ from "jquery";
(<any>window).jQuery = $;

import "popper.js";
import "bootstrap";
import "preact";

/* Tesseract */
import TesseractWysiwyg from "./_tesseract/wysiwyg";

/* Pages */
// Settings pages
import ReferenceCollectionPage from "./pages/reference-collection";
import ReferenceItemPage from "./pages/reference-item";
import CookieSettingsPage from "./pages/cookie-settings";

// Developer pages
import TesseractDeveloperPage from "./pages/developer/tesseract";

/* Script loader */
$(() => {

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
    
    if (document.querySelector(".page__developer--tesseract"))
    {
        new TesseractDeveloperPage();
    }
    
});

/* Styles */
import "../scss/main.scss";