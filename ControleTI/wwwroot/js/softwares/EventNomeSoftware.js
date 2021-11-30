
nomeSoftware.addEventListener("input", function () {

    if (!this.value) {
        this.value = "";
    }


    let form = new FormData();
    form.append("__RequestVerificationToken", token);
    form.append("nomeSoftware", this.value);
    

    const url = "/Softwares/PesquisarJSON";
    fetch(url, {
        body: form,
        method: "POST"
    }).then(T => T.json()).then(function (response) {
        //console.log(response);
        var softwareTr = document.querySelectorAll("tr[name=\"software\"");
        softwareTr.forEach(function (software) {
            software.remove();
        });

        response.forEach(function (software) {
            montarTabelaSoftware(software);
        });

    });




});