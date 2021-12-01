﻿setor.addEventListener("input", function () {

    if (!this.value) {
        this.value = 0;
    }
    if (!nomeUsuario.value) {
        nomeUsuario.value = "";
    }
    if (!nomeCompleto.value) {
        nomeCompleto.value = "";
    }
    if (!filial.value) {
        filial.value = 0;
    }

    let form = new FormData();
    form.append("__RequestVerificationToken", token);
    form.append("nomeUsuario", nomeUsuario.value);
    form.append("nomeCompleto", nomeCompleto.value);
    form.append("setor", this.value);
    form.append("filial", filial.value);

    const url = "/Usuarios/PesquisarJSON";
    fetch(url, {
        body: form,
        method: "POST"
    }).then(T => T.json()).then(function (response) {
        // console.log(response);
        var UsuarioTr = document.querySelectorAll("tr[name=\"Usuario\"");
        UsuarioTr.forEach(function (Usuario) {
            Usuario.remove();
        });

        response.forEach(function (Usuario) {
            montarTabelaUsuario(Usuario);
        });

    });




});