software.addEventListener("input", function () {

    if (!this.value) {
        this.value = "";
    }
    if (!serialKey.value) {
        serialKey.value = "";
    }

    if (disponibilidade.value) {
        switch (disponibilidade.value) {
            case "1":
                restantes = true;
                break;
            case "2":
                restantes = false;
                break;
            default:
                restantes = null;
                break;
        }
    }

   // var restantes = null;
    let form = new FormData();
    form.append("__RequestVerificationToken", token);
    form.append("serialKey", serialKey.value);
    form.append("software", this.value);
    form.append("restantes", restantes);
    
    
    const url = "/SerialKeys/PesquisarJSON";
    fetch(url, {
        body: form,
        method: "POST"
    }).then(T => T.json()).then(function (response) {
        // console.log(response);
        var softwareTr = document.querySelectorAll("tr[name=\"SerialKey\"");
        softwareTr.forEach(function (software) {
            software.remove();
        });

        response.forEach(function (software) {
            montarTabelaSerialKey(software);
        });

    });




});