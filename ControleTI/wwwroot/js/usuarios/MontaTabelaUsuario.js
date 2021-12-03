function montarTabelaUsuario(usuario){
    var tableBody = document.querySelector("#tableUsuario");
    tableBody.insertAdjacentHTML("beforeend",`
        <tr name="Usuario">
            <td>
                ${usuario.id}
            </td>
            <td>
                ${usuario.nomeUsu}
            </td>
            <td>
                ${usuario.nomeCompleto}
            </td>
            <td>
                ${usuario.setor}
            </td>

            <td>
                ${usuario.filial}
            </td>
    
            <td>
                <a href="/Usuarios/Editar/${usuario.id}" class="btn btn-brown" asp-route-id="@item.Id">Editar</a>
            </td>
            <td>
                <a href="/Usuarios/Detalhes/${usuario.id}" class="btn btn-info" asp-route-id="@item.Id">Detalhes</a>
            </td>
            <td>
                <a href="/Usuarios/Excluir/${usuario.id}" class="btn btn-danger">Apagar</a>
            </td>
        </tr>  
        `);
}