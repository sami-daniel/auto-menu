var login =document.getElementById("logar");
var cadastro =document.getElementById("cadastro");

var form_cadastro = document.getElementById("form-cadastro");
var form_login = document.getElementById("form-login");

function btncadastro() {
    if (form_cadastro.style.display === "none") {
        form_cadastro.style.display = "grid";
        form_login.style.display = "none";  // Esconde o formulário de login quando o de cadastro for mostrado
    } else {
        form_cadastro.style.display = "none";  // Adiciona a opção de esconder o formulário se clicar novamente
    }
}

function btnlogar() {
    if (form_login.style.display === "none") {
        form_login.style.display = "grid";
        form_cadastro.style.display = "none";  // Esconde o formulário de cadastro quando o de login for mostrado
    } else {
        form_login.style.display = "none";  // Adiciona a opção de esconder o formulário se clicar novamente
    }
}