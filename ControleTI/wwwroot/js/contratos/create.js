

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
                <h5 class="modal-title" id="${idModal}Label">Cadastrar Contrato</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">

                <div class="row">
                    <div class="col-md-12">
                        
                            <div class="form-group">
                                <label class="control-label">Descrição do Contrato</label>
                                <input name="Descricao" id="Descricao" class="form-control" />
                                <label class="control-label">Início</label>
                                <input type="date" name="Inicio" id="Inicio" class="form-control" />
                                <label lass="control-label">Fim</label>
                                <input type="date" name="Fim" id="Fim" inputmode=date class="form-control" />
                                <br>
                                <br>
                                <button type="button" onclick='CadastrarEmpresaParceira("${idModal}")' data-dismiss="modal" class="btn btn-success">Criar</button>
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

    div.appendChild(modal);
}

function CadastrarEmpresaParceira(idModal) {
    
    var token = document.querySelector("input[name=__RequestVerificationToken]");
    var modal = document.querySelector(`#${idModal}`);
    var Descricao = modal.querySelector('#Descricao');
    var Inicio = modal.querySelector('#Inicio');
    var Fim = modal.querySelector('#Fim');

    const url = "/EmpresaParceira/Create";
    let form = new FormData();
    form.append("__RequestVerificationToken", token.value);
    form.append("Descricao", Descricao.value);
    form.append("Inicio", Inicio.value);
    form.append("Fim", Fim.value);
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
    var table = document.querySelector('#dispositivoTableBody');
    empresaParceira.cnpj = cnpjFormat(empresaParceira.cnpj);
    table.insertAdjacentHTML("beforeend", `
        <tr name="empresaParceira" id="emp-${empresaParceira.id}">
            <td id=${empresaParceira.id}>
                ${empresaParceira.id}
            </td>
            <td id="NomeFantasia-${empresaParceira.id}">
                ${empresaParceira.nomeFantasia}
            </td>
            <td id="RazaoSocial-${empresaParceira.id}">
                ${empresaParceira.razaoSocial}
            </td>
            <td id="CNPJ-${empresaParceira.id}">
                ${empresaParceira.cnpj}
            </td>
            <td>
            <button type="button" data-toggle="modal" data-target="#modalEdit" class="btn btn-brown" onclick='modalEdit("modalEdit", ${empresaParceira.id})'>Editar</button>
            </td>
            <td>
                <a asp-action="Detalhes" class="btn btn-info" id="${empresaParceira.id}">Detalhes</a>
            </td>
            <td>
                <button type="button" data-toggle="modal" data-target="#modalDelete" class="btn btn-danger" onclick='modalDelete("modalDelete", ${empresaParceira.id})'>Apagar</button>
            </td>
        </tr>  
    `);
}

function cnpjFormat(cnpj) {
    var x = cnpj.replace(/\D/g, '').match(/(\d{0,2})(\d{0,3})(\d{0,3})(\d{0,4})(\d{0,2})/);
    cnpj = !x[2] ? x[1] : x[1] + '.' + x[2] + '.' + x[3] + '/' + x[4] + (x[5] ? '-' + x[5] : '')
    return cnpj;
}

