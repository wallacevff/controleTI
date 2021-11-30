function montarTabelaSoftware(software) {

    var softwareTable = document.querySelector("#softwareTableBody");

    var softwareTdId = document.createElement("td");
    softwareTdId.textContent = software.id;

    var softwareTdNome = document.createElement("td");
    softwareTdNome.textContent = software.nome;





    var botaoEditar = document.createElement("a");
    botaoEditar.setAttribute("href", `/Softwares/Editar/${software.id}`);
    botaoEditar.classList.add("btn");
    botaoEditar.classList.add("btn-brown");
    botaoEditar.textContent = "Editar";

    var botaoEditarTd = document.createElement("td");
    botaoEditarTd.appendChild(botaoEditar);


    var botaoDetalhes = document.createElement("a");
    botaoDetalhes.setAttribute("href", `/Softwares/Detalhes/${software.id}`);
    botaoDetalhes.classList.add("btn");
    botaoDetalhes.classList.add("btn-info");
    botaoDetalhes.textContent = "Detalhes";

    var botaoDetalhesTd = document.createElement("td");
    botaoDetalhesTd.appendChild(botaoDetalhes);

    var botaoApagar = document.createElement("a");
    botaoApagar.setAttribute("href", `/Softwares/Excluir/${software.id}`);
    botaoApagar.classList.add("btn");
    botaoApagar.classList.add("btn-danger");
    botaoApagar.textContent = "Apagar";

    var botaoApagarTd = document.createElement("td");
    botaoApagarTd.appendChild(botaoApagar);

    softwareTr = document.createElement("tr");
    softwareTr.setAttribute("name", "software");
    softwareTr.appendChild(softwareTdId);
    softwareTr.appendChild(softwareTdNome);

    softwareTr.appendChild(botaoEditarTd);
    softwareTr.appendChild(botaoDetalhesTd);
    softwareTr.appendChild(botaoApagarTd);
    softwareTable.appendChild(softwareTr);
}