function montarTabelaSetor(setor){
    var tableBody = document.querySelector("#tableSetor");
    tableBody.insertAdjacentHTML("beforeend",`
        <tr name="Setor">
            <td>
                ${setor.id}
            </td>
            <td id='nomeSetor-${setor.id}'>
                ${setor.nome}
            </td>
            
            
            <td>
                <a href="/Setores/Editar/${setor.id}" class="btn btn-brown" asp-route-id="@item.Id">Editar</a>
            </td>
            <td>
                <a href="/Setores/Detalhes/${setor.id}" class="btn btn-info" asp-route-id="@item.Id">Detalhes</a>
            </td>
            <td>
                <a href="/Setores/Excluir/${setor.id}" class="btn btn-danger">Apagar</a>
            </td>
        </tr>  
        `);

    var setorNome = tableBody.querySelector(`#nomeSetor-${setor.id}`);
    setorNome.textContent = setor.nome;
}