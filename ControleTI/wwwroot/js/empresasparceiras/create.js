

function modalCreate(idModal) {
    var div = document.querySelector(`#${idModal}Here`);
    if (modal = document.querySelector(`#${idModal}`)) {
        modal.remove();
    }
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
                                <label asp-for="NomeFantasia" class="control-label">Nome Fantasia</label>
                                <input id="NomeFantasia" class="form-control" />
                                <label asp-for="RazaoSocial" class="control-label">Razão Social</label>
                                <input id="RazaoSocial" class="form-control" />
                                <label asp-for="CNPJ" class="control-label">CNPJ</label>
                                <input id="CNPJ" inputmode=numeric class="form-control" />
                                <br>
                                <button type="button" onclick='CadastrarEmpresaParceira()' data-dismiss="modal" class="btn btn-success">Criar</button>
                                <button class="btn btn-danger" data-dismiss="modal"
                                    onClick='apagarModal("${idModal}")'>Cancelar</button>
                        
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

    // var show = modal.querySelector("span");
    div.appendChild(modal);

    //show.removeAttribute("aria-hidden");

    //    console.log(modal);
    //div.removeChild(modal);

    var mod = document.querySelector("#CNPJ");
    var originalValue = "";
    if (mod) {
        modal.addEventListener("input",
            function () {
                let cnpj = mod.value
                cnpj = cnpjFormat(cnpj);
                mod.value = cnpj;
                //console.log(cnpj);
            }
        );
    }
}

/*
function apagarModalCreate() {
    var modal = document.querySelector("#modalCreate");
    modal.remove();
}
*/

function CadastrarEmpresaParceira() {
    apagarModal();
    var token = document.querySelector("input[name=__RequestVerificationToken]");
    /// console.log(token);
    //var tr = document.querySelector(`#emp-${id}`);
    var NomeFantasia = document.querySelector('#NomeFantasia');
    var RazaoSocial = document.querySelector('#RazaoSocial');
    var CNPJ = document.querySelector('#CNPJ');
    /*
    var EmpresaParceira = {
        NomeFantasia: NomeFantasia,
        RazaoSocial: RazaoSocial,
        CNPJ: CNPJ
    }; */
    //console.log(EmpresaParceira);

    const url = "/EmpresaParceira/Create";
    let form = new FormData();
    form.append("__RequestVerificationToken", token.value);
    form.append("NomeFantasia", NomeFantasia.value);
    form.append("RazaoSocial", RazaoSocial.value);
    form.append("CNPJ", CNPJ.value.replace(".","").replace("/","").replace("-","").replace(".",""));
    fetch(url, {
        body: form,
        method: "POST"
    }).then(response => {
        response.json()
            .then((respObj) => {
                appendTR(respObj);
                console.log(respObj);
            });
    });
}


function appendTR(empresaParceira) {
    apagarModal();
    var table = document.querySelector('#dispositivoTableBody');
    empresaParceira.cnpj = cnpjFormat(empresaParceira.cnpj);
    table.insertAdjacentHTML("beforeend", `
        <tr name="empresaParceira" id="emp-${empresaParceira.id}">
            <td>
                ${empresaParceira.id}
            </td>
            <td>
                ${empresaParceira.nomeFantasia}
            </td>
            <td>
                ${empresaParceira.razaoSocial}
            </td>
            <td>
                ${empresaParceira.cnpj}
            </td>
            <td>
                <a asp-action="Editar" class="btn btn-brown">Editar</a>
            </td>
            <td>
                <a asp-action="Detalhes" class="btn btn-info" id="@item.Id">Detalhes</a>
            </td>
            <td>
                <button type="button" data-toggle="modal" data-target="#modalDelete" class="btn btn-danger" onclick='modalDelete("modalDelete", ${empresaParceira.id}, "${empresaParceira.nomeFantasia}")'>Apagar</button>
            </td>
        </tr>  
    `);
}

function cnpjFormat(cnpj) {
    var x = cnpj.replace(/\D/g, '').match(/(\d{0,2})(\d{0,3})(\d{0,3})(\d{0,4})(\d{0,2})/);
    cnpj = !x[2] ? x[1] : x[1] + '.' + x[2] + '.' + x[3] + '/' + x[4] + (x[5] ? '-' + x[5] : '')
    return cnpj;
}

