var cnpj = document.querySelectorAll("td[name=CNPJ]");
//cnpj.textContent = cnpjFormat(cnpj.textContent);

cnpj.forEach(c => c.textContent = cnpjFormat(c.textContent));



function cnpjFormat(cnpj) {
    var x = cnpj.replace(/\D/g, '').match(/(\d{0,2})(\d{0,3})(\d{0,3})(\d{0,4})(\d{0,2})/);
    cnpj = !x[2] ? x[1] : x[1] + '.' + x[2] + '.' + x[3] + '/' + x[4] + (x[5] ? '-' + x[5] : '')
    return cnpj;
}
