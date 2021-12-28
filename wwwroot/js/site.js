// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checarTitulo() {
    var titulo = document.getElementById("Titulo");

    if (titulo.value == "") {
        alert("O campo 'Título' é obrigatório!");
        return false;
    }
    else {
        return true;
    }
}

function checarAutor() {
    var autor = document.getElementById("Autor");

    if (autor.value == "") {
        alert("O campo 'Autor' é obrigatório!");
        return false;
    }
    else {
        return true;
    }
}

function checarAno() {
    var ano = document.getElementById("Ano");

    if (ano.value == "") {
        alert("O campo 'Ano' é obrigatório!");
        return false;
    }
    else {
        return true;
    }
}

function checarNome() {
    var nome = document.getElementById("NomeUsuario");

    if (nome.value == "") {
        alert("O campo 'Nome' é obrigatório!");
        return false;
    }
    else {
        return true;
    }
}
function checarTel() {
    var tel = document.getElementById("Telefone");

    if (tel.value == "") {
        alert("O campo 'Telefone' é obrigatório!");
        return false;
    }
    else {
        return true;
    }
}
function checarDataE() {
    var data = document.getElementById("DataEmprestimo");

    if (data.value == "") {
        alert("O campo 'Data de Empréstimo' é obrigatório!");
        return false;
    }
    else {
        return true;
    }
}
function checarDataD() {
    var data = document.getElementById("DataDevolucao");

    if (data.value == "") {
        alert("O campo 'Data de Devolução' é obrigatório!");
        return false;
    }
    else {
        return true;
    }
}
function checarLivro() {
    var livro = document.getElementById("Livro");

    if (livro.value == "") {
        alert("O campo 'Livro' é obrigatório!");
        return false;
    }
    else {
        return true;
    }
}
