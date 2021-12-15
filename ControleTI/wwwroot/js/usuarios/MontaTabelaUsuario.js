function montarTabelaUsuario(usuario){
    var tableBody = document.querySelector("#tableUsuario");
    tableBody.insertAdjacentHTML("beforeend",`
        <tr name="Usuario">
            <td>
                ${usuario.id}
            </td>
            <td id='nomeUsuario-${usuario.id}'>
                ${usuario.nomeUsu}
            </td>
            <td id='nomeCompleto-${usuario.id}'>
                ${usuario.nomeCompleto}
            </td>
            <td id='setor-${usuario.id}'>
                ${usuario.setor}
            </td>

            <td id='filial-${usuario.id}'>
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

    var nomeUsuario = tableBody.querySelector(`#nomeUsuario-${usuario.id}`);
    var nomeCompleto = tableBody.querySelector(`#nomeCompleto-${usuario.id}`);
    var setor = tableBody.querySelector(`#setor-${usuario.id}`);
    var filial = tableBody.querySelector(`#filial-${usuario.id}`);
    if (usuario.nomeUsu) {
        nomeUsuario.textContent = usuario.nomeUsu;
    }
    if (usuario.nomeCompleto) {
        nomeCompleto.textContent = usuario.nomeCompleto;
    }
    setor.textContent = usuario.setor;
    filial.textContent = usuario.filial;
}