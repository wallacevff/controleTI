

function modalDelete(id, nome) {
    var div = document.querySelector("#modalHere");
    if (modal = document.querySelector("#modalApagar")) {
        modal.remove();
    }
    var modal = document.createElement("div");
    modal.insertAdjacentHTML("beforeend", `
<div class="modal fade" id="modalApagar" tabindex="-1" role="dialog" aria-labelledby="modalApagar" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalApagarLabel">Apagar Key</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Tem certeza que deseja Apagar o software: ${nome}
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-dark" data-dismiss="modal" onclick='apagarModal()'>Não</button>
                    <button type="button" class="btn btn-danger" onclick='deletarSoftawre(${id})' data-dismiss="modal">Sim</button>
                </div>
            </div>
        </div>
</div>
`
    );
 
    var show = modal.querySelector("span");
    div.appendChild(modal);
    //show.removeAttribute("aria-hidden");
    
    console.log(modal);
    //div.removeChild(modal);
}

function apagarModal() {
    var modal = document.querySelector("#modalApagar");
    modal.remove();
}

function deletarSoftawre(id) {
    apagarModal();
    var token = document.querySelector("input[name=__RequestVerificationToken]");
   /// console.log(token);
    var tr = document.querySelector(`#soft-${id}`);
    const url = "/DispositivoSoftwares/Apagar";
    let form = new FormData();
    form.append("__RequestVerificationToken", token.value);
    form.append("id", id);
    fetch(url, {
        body: form,
        method: "POST"
    }).then(function () {
        tr.remove();
    })
}