var login =document.getElementById("logar");
var cadastro =document.getElementById("cadastro");

var form_cadastro = document.getElementById("form-cadastro");
var form_login = document.getElementById("form-login");

function btncadastro(){
if (form_cadastro.style.display === "none"){
    form_cadastro.style.display = "block";
}
}

function btnlogar(){
    if (form_login.style.display === "none"){
        form_login.style.display = "block";
    }
    }