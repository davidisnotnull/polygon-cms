import $ from 'jquery';
window.jQuery = $;
window.$ = $;

import _ from "lodash";
import "popper.js";
import "bootstrap";
import { initializeModal } from "./tesseract.modal.js";
import { showModalWindow } from "./tesseract.modal.js";
import { showModalWithData } from "./tesseract.modal.js";
import { closeModalWindow } from "./tesseract.modal.js";
import { replaceModalContent } from "./tesseract.modal.js";

window.showModalWindow = showModalWindow;
window.showModalWithData = showModalWithData;
window.closeModalWindow = closeModalWindow;
window.replaceModalContent = replaceModalContent;

import "../scss/app.scss";

$(function() {
    initializeModal();
})