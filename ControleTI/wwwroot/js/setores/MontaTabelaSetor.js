function montarTabelaSetor(setor){
    var tableBody = document.querySelector("#tableSetor");
    tableBody.insertAdjacentHTML("beforeend",`
        <tr name="Setor">
            <td>
                ${setor.id}
            </td>
            <td>
                ${setor.nome}
            </td>
            
    
            <td>
                <a href="/Setores/Editar/${setor.id}" class="btn btn-brown" asp-route-id="@item.Id">Editar</a>
            </td>
            <td>
                <a href="/Setores/Detalhes/${setor.id}" class="btn btn-info" asp-route-id="@item.Id">Detalhes</a>
            </td>
            <td>
                <a href="/Setores/Detalhes/${setor.id}" class="btn btn-danger">Apagar</a>
            </td>
        </tr>  
        `);
}