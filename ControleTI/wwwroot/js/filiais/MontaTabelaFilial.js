function montarTabelaFilial(Filial){
    var tableBody = document.querySelector("#tableFilial");
    tableBody.insertAdjacentHTML("beforeend",`
        <tr name="Filial">
            <td>
                ${Filial.id}
            </td>
            <td>
                ${Filial.nome}
            </td>
            
    
            <td>
                <a href="/Filiais/Editar/${Filial.id}" class="btn btn-brown" asp-route-id="@item.Id">Editar</a>
            </td>
            <td>
                <a href="/Filiais/Detalhes/${Filial.id}" class="btn btn-info" asp-route-id="@item.Id">Detalhes</a>
            </td>
            <td>
                <a href="/Filiales/Excluir/${Filial.id}" class="btn btn-danger">Apagar</a>
            </td>
        </tr>  
        `);
}