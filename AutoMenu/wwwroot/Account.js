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
  var nome = document.getElementById("nome").value.trim();
  var span_nome = document.getElementById("erro-nome");


  var Cnpj = document.getElementById("cnpj").value.trim();
  var span_cnpj = document.getElementById("erro-cnpj");

  var cnpjPattern = /^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$/;

if (!cnpjPattern.test(Cnpj) && Cnpj === "" 
                   || 
      nome.length <= 100 && nome === "") {

  span_cnpj.textContent = "CNPJ inválido ou vazio.";
  span_nome.textContent = "Nome deve ter até 100 caracteres e não pode ser vazio.";
 
}else{
  if (etapa2.style.display === "none") {
    etapa1.style.display = "none";
    etapa2.style.display = "grid";
  } else {
    etapa2.style.display = "none";
    etapa1.style.display = "grid";
  }

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

