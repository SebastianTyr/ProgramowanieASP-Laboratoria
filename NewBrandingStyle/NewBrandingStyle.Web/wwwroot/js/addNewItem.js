(function () {
    const alertElement = document.getElementById("success-alert");
    const formElement = document.forms[0];

    const addNewItem = async () => {
        //1 reading form data
        const requestData = formElement.nodeValue;

        //2 calling application server using fetch API method
        const response = await fetch(requestData);

        const responseJSON = await response.json();

        if (responseJSON.success) {
            //3 unhide element
            alertElement.style.display = "flex";

        }
    };

    window.addEventListener("load", () => {
        formElement.addEventListener("submit", event => {
            event.preventDefault();

            addNewItem().then(() => console.log("added successfully"));
        });
    });
}) ();