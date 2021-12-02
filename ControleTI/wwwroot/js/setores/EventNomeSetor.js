
nomeSetor.addEventListener("input", function () {

    if (!this.value) {
        this.value = "";
    }


    let form = new FormData();
    form.append("__RequestVerificationToken", token);
    form.append("nomeSetor", this.value);
   
    

    const url = "/Setores/PesquisarJSON";
    fetch(url, {
        body: form,
        method: "POST"
    }).then(T => T.json()).then(function (response) {
        //console.log(response);
        var SetorTr = document.querySelectorAll("tr[name=\"Setor\"");
        SetorTr.forEach(function (Setor) {
            Setor.remove();
        });

        response.forEach(function (Setor) {
            montarTabelaSetor(Setor);
        });

    });




});