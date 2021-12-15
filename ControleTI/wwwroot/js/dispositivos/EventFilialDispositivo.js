filialDispositivo.addEventListener("input", function () {

    if (!this.value) {
        this.value = 0;
    }
    if (!nomeDispositivo.value) {
        nomeDispositivo.value = "";
    }
    if (!nomeUsuario.value) {
        nomeUsuario.value = "";
    }
    if (!tipoDispositivo.value) {
        tipoDispositivo.value = 0;
    }
    if (!setorDispositivo.value) {
        setorDispositivo.value = 0;
    }
    if (!statusDispositivo.value) {
        statusDispositivo.value = 0;
    }
    console.log(this.value);
    let form = new FormData();
    form.append("__RequestVerificationToken", token);
    form.append("nomeDispositivo", nomeDispositivo.value);
    form.append("nomeUsuario", nomeUsuario.value);
    form.append("tipoDispositivoId", tipoDispositivo.value);
    form.append("statusId", statusDispositivo.value);
    form.append("setorId", setorDispositivo.value);
    form.append("filialId", this.value);


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