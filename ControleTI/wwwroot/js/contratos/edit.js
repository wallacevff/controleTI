function modalEdit(idModal, id) {
    var div = document.querySelector(`#${idModal}Here`);
    if (modal = document.querySelector(`#${idModal}`)) {
        modal.remove();
    }
    var NomeFantasia = document.querySelector(`#NomeFantasia-${id}`);
    var RazaoSocial = document.querySelector(`#RazaoSocial-${id}`);
    var CNPJ = document.querySelector(`#CNPJ-${id}`);

    var empresa = {
        "Id": id,
        "NomeFantasia": NomeFantasia.textContent.replace("\n","").trim().replace("/",""),
        "RazaoSocial": RazaoSocial.textContent.replace("\n","").trim(),
        "CNPJ": CNPJ.textContent.replace("\n","").trim()
    }
    console.log(empresa);
    
    var modal = document.createElement("div");
    modal.insertAdjacentHTML("beforeend", `
    <div class="modal fade" id="${idModal}" tabindex="-1" role="dialog" aria-labelledby="${idModal}" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="${idModal}Label">Cadastrar Empresa</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="row">
                    <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">Nome Fantasia</label>
                                <input id="Id" lass="form-control" value=${id} hidden=true>
                                <input id="NomeFantasia" class="form-control" value="${NomeFantasia.textContent.trim()}"/>
                                <label class="control-label">Razão Social</label>
                                <input id="RazaoSocial" class="form-control" value="${RazaoSocial.textContent.replace("/").trim()}"  />
                                <label class="control-label">CNPJ</label>
                                <input id="CNPJ" inputmode=numeric value=${CNPJ.textContent} class="form-control" />
                                <br>
                                <button type="button" onclick='editarEmpresaParceira("${idModal}")' data-dismiss="modal" class="btn btn-success">Editar</button>
                                <button class="btn btn-danger" data-dismiss="modal"
                                    onClick='apagarModal("${idModal}")'>Cancelar
                                </button>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
            </div>
        </div>
    </div>
</div>
`
    );

    div.appendChild(modal);


    var mod = document.querySelector("#CNPJ");
    var originalValue = "";
    if (mod) {
        modal.addEventListener("input",
            function () {
                let cnpj = mod.value
                cnpj = cnpjFormat(cnpj);
                mod.value = cnpj;
            }
        );
    }
}

function editarEmpresaParceira(idModal) {
    const url = "/EmpresaParceira/Edit";
    var token = document.querySelector("input[name=__RequestVerificationToken]");
    var id = document.querySelector("#Id");
    var nomeFantasia = document.querySelector("#NomeFantasia");
    var razaoSocial = document.querySelector("#RazaoSocial");
    var CNPJ = document.querySelector('#CNPJ');
    empresa = {
        "Id": id.value,
        "NomeFantasia": nomeFantasia.value,
        "RazaoSocial": razaoSocial.value,
        "CNPJ": CNPJ.value,
    };
    changeTR(empresa, idModal);

    
    let form = new FormData();
    form.append("Id", empresa.Id);
    form.append("NomeFantasia", empresa.NomeFantasia);
    form.append("RazaoSocial", empresa.RazaoSocial);
    form.append("CNPJ", empresa.CNPJ.replace(".", "").replace("/", "").replace("-", "").replace(".", ""));
    form.append("__RequestVerificationToken", token)
    fetch(url, {
        body: form,
        method: "PUT"
    });

}

function cnpjFormat(cnpj) {
    var x = cnpj.replace(/\D/g, '').match(/(\d{0,2})(\d{0,3})(\d{0,3})(\d{0,4})(\d{0,2})/);
    cnpj = !x[2] ? x[1] : x[1] + '.' + x[2] + '.' + x[3] + '/' + x[4] + (x[5] ? '-' + x[5] : '')
    return cnpj;
}

function changeTR(empresaParceira, idModal) {
    
    //var table = document.querySelector('#dispositivoTableBody');
    empresaParceira.cnpj = cnpjFormat(empresaParceira.CNPJ);
    var NomeEmpresaDom = document.querySelector(`#NomeFantasia-${empresaParceira.Id}`);
    var RazaoSocialDom = document.querySelector(`#RazaoSocial-${empresaParceira.Id}`);
    var CNPJ = document.querySelector(`#CNPJ-${empresaParceira.Id}`);

    NomeEmpresaDom.textContent = empresaParceira.NomeFantasia.trim().replace("/","");
    RazaoSocialDom.textContent = empresaParceira.RazaoSocial.trim();
    CNPJ.textContent = empresaParceira.CNPJ.trim();
    empresaParceira = null;
    //apagarModal(idModal);
    
}
