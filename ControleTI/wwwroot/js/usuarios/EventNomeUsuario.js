
nomeUsuario.addEventListener("input", function () {

    if (!this.value) {
        this.value = "";
    }


    let form = new FormData();
    form.append("__RequestVerificationToken", token);
    form.append("nomeUsuario", this.value);
    form.append("nomeCompleto", nomeCompleto.value);
    form.append("setor", setor.value);
    form.append("filial", filial.value);
    

    const url = "/Usuarios/PesquisarJSON";
    fetch(url, {
        body: form,
        method: "POST"
    }).then(T => T.json()).then(function (response) {
        //console.log(response);
        var UsuarioTr = document.querySelectorAll("tr[name=\"Usuario\"");
        UsuarioTr.forEach(function (Usuario) {
            Usuario.remove();
        });

        response.forEach(function (Usuario) {
            montarTabelaUsuario(Usuario);
        });

    });




});