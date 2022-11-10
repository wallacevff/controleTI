function modalDelete(idModal, id) {
   // console.log(document.querySelector(`#emp-${id}`));
    var div = document.querySelector("#modalHere");
    if (modal = document.querySelector(`#${idModal}`)) {
        modal.remove();
    }
    var NomeFantasia = document.querySelector(`#NomeFantasia-${id}`);
    var modal = document.createElement("div");
   // console.log(idModal);
    modal.insertAdjacentHTML("beforeend", `
<div class="modal fade" id="${idModal}" tabindex="-1" role="dialog" aria-labelledby="${idModal}" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="${idModal}Label">Apagar Empresa</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Tem certeza que deseja Apagar a empresa: ${NomeFantasia.textContent.trim()}
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-dark" data-dismiss="modal" onclick='apagarModal("${idModal}")'>Não</button>
                    <button type="button" class="btn btn-danger" onclick='deletarEmpresaParceira("${idModal}", ${id})' data-dismiss="modal">Sim</button>
                </div>
            </div>
        </div>
</div>
`
    );

    div.appendChild(modal);
}

function deletarEmpresaParceira(idModal, id) {
    var token = document.querySelector("input[name=__RequestVerificationToken]");
    var tr = document.querySelector(`#emp-${id}`);
    const url = "/EmpresaParceira/Delete";
    let form = new FormData();
    form.append("__RequestVerificationToken", token.value);
    form.append("id", id);
    fetch(url, {
        body: form,
        method: "POST"
    }).then(function () {
        tr.remove();
    });
    apagarModal(idModal);
}