var login = document.getElementById("logar");
var cadastro = document.getElementById("cadastro");
var btn_escolha = document.getElementById("escolha-button");

var form_cadastro = document.getElementById("form-cadastro");
var form_login = document.getElementById("form-login");

var etapa1 = document.getElementById("Etapa-1");
var etapa2 = document.getElementById("Etapa-2");
var etapa3 = document.getElementById("Etapa-3");

function btncadastro() {
  if (form_cadastro.style.display === "none") {
    form_cadastro.style.display = "grid";
    form_login.style.display = "none"; // Esconde o formulário de login quando o de cadastro for mostrado
    btn_escolha.style.display = "none";
    etapa1.style.display = "grid";
  } else {
    form_cadastro.style.display = "none"; // Adiciona a opção de esconder o formulário se clicar novamente
  }
}

function btnlogar() {
  if (form_login.style.display === "none") {
    form_login.style.display = "grid";
    form_cadastro.style.display = "none"; // Esconde o formulário de cadastro quando o de login for mostrado
    btn_escolha.style.display = "none";
  } else {
    form_login.style.display = "none"; // Adiciona a opção de esconder o formulário se clicar novamente
  }
}

function mostraretapa2() {
  if (etapa2.style.display === "none") {
    etapa1.style.display = 'none';
    etapa2.style.display = 'grid';
  } else {
    etapa2.style.display = 'none';
    etapa1.style.display = 'grid';
  }
}

function mostraretapa3() {
  if (etapa3.style.display === "none") {
    etapa2.style.display = 'none';
    etapa3.style.display = 'grid';
  } else {
    etapa3.style.display = 'none';
    etapa2.style.display = 'grid';
  }
}


function voltar_etapa1() {
    if(btn_escolha.style.display ==="none"){
        btn_escolha.style.display = "block";
        etapa1.style.display = "none";
        form_cadastro.style.display = "none";
    }else{
        etapa1.style.display = "grid";
    }

}

function voltar_etapa2() {
    if(etapa1.style.display ==="none"){
        etapa1.style.display ="grid"
        etapa2.style.display = "none";
    }else{
        etapa2.style.display = "grid";
    }

}

function voltar_etapa3() {
    if(etapa2.style.display ==="none"){
        etapa2.style.display ="grid"
        etapa3.style.display = "none";
    }else{
        etapa3.style.display = "grid";
    }

}



function voltar_login(){
    if(btn_escolha.style.display ==="none"){
        btn_escolha.style.display = "block";
        form_login.style.display = "none";
    }

}

