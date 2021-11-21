function montarTabelaDispositivo(dispositivo) {

    var dispositivoTable = document.querySelector("#dispositivoTableBody");

    var dispositivoTdId = document.createElement("td");
    dispositivoTdId.textContent = dispositivo.id;

    var dispositivoTdNome = document.createElement("td");
    dispositivoTdNome.textContent = dispositivo.nome;

    var dispositivoTdTipo = document.createElement("td");
    dispositivoTdTipo.textContent = dispositivo.tipo;

    var dispositivoTdStatus = document.createElement("td");
    dispositivoTdStatus.textContent = dispositivo.statusNome;
    console.log(dispositivo.statusNome);

    var dispositivoTdNomeUsu = document.createElement("td");
    dispositivoTdNomeUsu.textContent = dispositivo.nomeUsu;




    var botaoEditar = document.createElement("a");
    botaoEditar.setAttribute("href", `/Dispositivos/Editar/${dispositivo.id}`);
    botaoEditar.classList.add("btn");
    botaoEditar.classList.add("btn-brown");
    botaoEditar.textContent = "Editar";

    var botaoEditarTd = document.createElement("td");
    botaoEditarTd.appendChild(botaoEditar);


    var botaoDetalhes = document.createElement("a");
    botaoDetalhes.setAttribute("href", `/Dispositivos/Detalhes/${dispositivo.id}`);
    botaoDetalhes.classList.add("btn");
    botaoDetalhes.classList.add("btn-info");
    botaoDetalhes.textContent = "Detalhes";

    var botaoDetalhesTd = document.createElement("td");
    botaoDetalhesTd.appendChild(botaoDetalhes);

    var botaoApagar = document.createElement("a");
    botaoApagar.setAttribute("href", `/Dispositivos/Excluir/${dispositivo.id}`);
    botaoApagar.classList.add("btn");
    botaoApagar.classList.add("btn-danger");
    botaoApagar.textContent = "Apagar";

    var botaoApagarTd = document.createElement("td");
    botaoApagarTd.appendChild(botaoApagar);

    dispositivoTr = document.createElement("tr");
    dispositivoTr.setAttribute("name", "dispositivo");
    dispositivoTr.appendChild(dispositivoTdId);
    dispositivoTr.appendChild(dispositivoTdNome);
    dispositivoTr.appendChild(dispositivoTdTipo);
    dispositivoTr.appendChild(dispositivoTdStatus);
    dispositivoTr.appendChild(dispositivoTdNomeUsu);

    dispositivoTr.appendChild(botaoEditarTd);
    dispositivoTr.appendChild(botaoDetalhesTd);
    dispositivoTr.appendChild(botaoApagarTd);
    dispositivoTable.appendChild(dispositivoTr);
}