import NotifyOptions from "./interfaces/NotifyOptions";
const utils = require('../_utils');
import './styles';

class TesseractNotify {

    props: NotifyOptions;

    constructor(props: NotifyOptions) {
        this.props = props;
        this.init();
    }

    init() {
        this.showNotification();
    }

    showNotification() {
        let body = document.querySelector("body");
        let notification = <HTMLDivElement>(document.createElement('div'));
        notification.className = "tesseract__notify";

        switch (this.props.type) {
            case "success":
                notification.classList.add("success");
                break;
            case "info":
                notification.classList.add("info");
                break;
            case "error":
                notification.classList.add("error");
                notification.innerHTML = "<strong>ERROR</strong> ";
                break;
            default:
                notification.classList.add("default")
                break;
        }

        notification.innerHTML += this.props.message;
        notification.addEventListener('click', this.hideNotification.bind(this));
        body.append(notification);

        let showAnimation = notification.animate([
            { opacity: 0 },
            { opacity: 1 }
        ], { duration: 500, iterations: 1 });
        showAnimation.onfinish = this.notificationTimer;
    }

    notificationTimer = function () {
        let timerDuration: number = 5000;
        let notification = document.querySelector(".tesseract__notify");
        setTimeout(() => {
            let hideAnimation = notification.animate([
                { opacity: 1 },
                { opacity: 0 }
            ],
                { duration: 500, iterations: 1 });
            hideAnimation.onfinish = function () {
                notification.remove();
            };
        },
            timerDuration);
    }

    hideNotification() {
        let notification = document.querySelector(".tesseract__notify");
        let hideAnimation = notification.animate([
            { opacity: 1 },
            { opacity: 0 }
        ], { duration: 500, iterations: 1 });
        hideAnimation.onfinish = function () {
            notification.remove();
        };
    }

}

export default TesseractNotify;