disponibilidade.addEventListener("input", function () {

    if (!serialKey.value) {
        serialKey.value = "";
    }
    if (!software.value) {
        software.value = "";
    }

    if (this.value) {
        switch (this.value) {
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
    form.append("serialKey", serialKey.value);
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