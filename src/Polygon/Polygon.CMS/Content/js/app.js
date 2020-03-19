import $ from 'jquery';
window.jQuery = $;
window.$ = $;

/* Import libraries */
import _ from "lodash";
import "popper.js";
import "bootstrap";
import "jquery-validation";
import "jquery-validation-unobtrusive";
import "select2";
import "ckeditor4";

/* Setup custom modules */
import { initializeModal } from "./tesseract.modal.js";
import { showModalWindow } from "./tesseract.modal.js";
import { showModalWithData } from "./tesseract.modal.js";
import { closeModalWindow } from "./tesseract.modal.js";
import { replaceModalContent } from "./tesseract.modal.js";

/* Define global methods */
window.showModalWindow = showModalWindow;
window.showModalWithData = showModalWithData;
window.closeModalWindow = closeModalWindow;
window.replaceModalContent = replaceModalContent;

import "../scss/app.scss";

$(function() {
    initializeModal();
})