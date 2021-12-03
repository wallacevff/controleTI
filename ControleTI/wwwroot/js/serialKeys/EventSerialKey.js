serialKey.addEventListener("input", function () {

    if (!this.value) {
        this.value = "";
    }
    if (!software.value) {
        software.value = "";
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

    let form = new FormData();
    form.append("__RequestVerificationToken", token);
    form.append("serialKey", this.value);
    form.append("software", software.value);
    form.append("restantes", restantes);
    
    
    const url = "/SerialKeys/PesquisarJSON";
    fetch(url, {
        body: form,
        method: "POST"
    }).then(T => T.json()).then(function (response) {
        // console.log(response);
        var SerialKeyTr = document.querySelectorAll("tr[name=\"SerialKey\"");
        SerialKeyTr.forEach(function (SerialKey) {
            SerialKey.remove();
        });

        response.forEach(function (SerialKey) {
            montarTabelaSerialKey(SerialKey);
        });

    });




});