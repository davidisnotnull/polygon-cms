﻿/* Styles */
import "./_tesseract/main.scss";

/* Tesseract */
import TesseractNavigation from "./_tesseract/navigation";
import TesseractWysiwyg from "./_tesseract/wysiwyg";

/* Pages */
/* Content Pages */
import SelectPageType from "./pages/content/select-page-type";
import CreatePage from "./pages/content/create-page";

/* Settings pages */
import ReferenceCollectionPage from "./pages/reference-collection";
import ReferenceItemPage from "./pages/reference-item";
import CookieSettingsPage from "./pages/cookie-settings";

/* Developer pages */
import TesseractDeveloperPage from "./pages/developer/tesseract";

/* Script loader */
window.onload = () => {
    
    new TesseractNavigation();

    /* Load Select Page Type scripts */
    if (document.querySelector('.page__select-page-type'))
    {
        new SelectPageType();
    }

    if (document.querySelector(".page__create-page"))
    {
        new CreatePage();
        new TesseractWysiwyg();
    }
    
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
};