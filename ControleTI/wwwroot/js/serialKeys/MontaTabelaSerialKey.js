function montarTabelaSerialKey(SerialKey) {
    var tableBody = document.querySelector("#tableSerialKey");
    tableBody.insertAdjacentHTML("beforeend", `
        <tr name="SerialKey">
            <td>
                ${SerialKey.id}
            </td>
            <td id='nomeSoftware-${SerialKey.id}'>
                ${SerialKey.nomeSoftware}
            </td>
            <td id='serialkey-${SerialKey.id}'>
                ${SerialKey.key}
            </td>
            <td>
                ${SerialKey.quantidade}
            </td>

            <td>
                ${SerialKey.utilizadas}
            </td>
            <td>
                ${SerialKey.restantes}
            </td>
    
            <td>
                <a href="/SerialKeys/Editar/${SerialKey.id}" class="btn btn-brown" asp-route-id="@item.Id">Editar</a>
            </td>
            <td>
                <a href="/SerialKeys/Detalhes/${SerialKey.id}" class="btn btn-info" asp-route-id="@item.Id">Detalhes</a>
            </td>
            <td>
                <a href="/SerialKeys/Excluir/${SerialKey.id}" class="btn btn-danger">Apagar</a>
            </td>
        </tr>  
        `);


    var serialKey = tableBody.querySelector(`#serialkey-${SerialKey.id}`);
    if (SerialKey.key) {
        serialKey.textContent = SerialKey.key;
    }
    var nomeSoftware = tableBody.querySelector(`#nomeSoftware-${SerialKey.id}`);
    //console.log(nomeSoftware)
    if (SerialKey.nomeSoftware) {
        nomeSoftware.textContent = SerialKey.nomeSoftware;
    }
    
}