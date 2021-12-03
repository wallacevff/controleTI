
nomeFilial.addEventListener("input", function () {

    if (!this.value) {
        this.value = "";
    }


    let form = new FormData();
    form.append("__RequestVerificationToken", token);
    form.append("nomeFilial", this.value);
   
    

    const url = "/Filiais/PesquisarJSON";
    fetch(url, {
        body: form,
        method: "POST"
    }).then(T => T.json()).then(function (response) {
        //console.log(response);
        var FilialTr = document.querySelectorAll("tr[name=\"Filial\"");
        FilialTr.forEach(function (Filial) {
            Filial.remove();
        });

        response.forEach(function (Filial) {
            montarTabelaFilial(Filial);
        });

    });




});