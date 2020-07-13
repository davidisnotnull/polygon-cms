class SelectPageType {

    constructor() {
        this.init();
    }

    init() {
        console.log("Firing Select Page Type scripts");
        this.addEventHandlers();
    }

    addEventHandlers() {
        const createButtons = document.querySelectorAll(".button__create-page");
        for (const createButton of createButtons)
        {
            let contentTypeGuid = createButton.getAttribute("data-id");
            createButton.addEventListener("click", function(){
                window.location.href = "/Content/CreatePage/?id=" + contentTypeGuid;
            });
        }
    }
}

export default SelectPageType;