tipoDispositivo.addEventListener("input", function () {

    if (!this.value) {
        this.value = "";
    }
    if (!nomeDispositivo.value) {
        nomeDispositivo.value = "";
    }

    let form = new FormData();
    form.append("__RequestVerificationToken", token);
    form.append("nomeDispositivo", nomeDispositivo.value);
    form.append("tipoDispositivoId", this.value);
    form.append("nomeUsuario", nomeUsuario.value);

    const url = "/Dispositivos/PesquisarJSON";
    fetch(url, {
        body: form,
        method: "POST"
    }).then(T => T.json()).then(function (response) {
        // console.log(response);
        var dispositivoTr = document.querySelectorAll("tr[name=\"dispositivo\"");
        dispositivoTr.forEach(function (dispositivo) {
            dispositivo.remove();
        });

        response.forEach(function (disp) {
            montarTabelaDispositivo(disp);
        });

    });




});