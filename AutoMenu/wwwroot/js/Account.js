
var btn_choice = document.getElementById("choice-button");

var form_register = document.getElementById("form-register");
var form_login = document.getElementById("form-login");

var stage1 = document.getElementById("stage-1");
var stage2 = document.getElementById("stage-2");
var stage3 = document.getElementById("stage-3");

function btn_register() {
    if (form_register.style.display === "none") {
        form_register.style.display = "grid";
        form_login.style.display = "none"; // Esconde o formulário de login quando o de cadastro for mostrado
        btn_choice.style.display = "none";
        stage1.style.display = "grid";
    } else {
        form_register.style.display = "none"; // Adiciona a opção de esconder o formulário se clicar novamente
    }
}

function btn_logar() {
    if (form_login.style.display === "none") {
        form_login.style.display = "grid";
        form_register.style.display = "none"; // Esconde o formulário de cadastro quando o de login for mostrado
        btn_choice.style.display = "none";
    } else {
        form_login.style.display = "none"; // Adiciona a opção de esconder o formulário se clicar novamente
    }
}

function show_stage2() {
    var name = document.getElementById("Name").value.trim();
    var span_name = document.getElementById("error-Name");

    var Cnpj = document.getElementById("Cnpj").value.trim();
    var span_cnpj = document.getElementById("error-Cnpj");

    var cnpjPattern = /^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$/;

    if (name === "") {
        span_name.textContent = "Insira o nome:";
    } else if (name.length >= 80) {
        span_name.textContent = "Nome deve ser menor que 80 caracteres";
        var name_obrigatorio = true;
    } else {
        span_name.textContent = "";
        var name_obrigatorio = true;
        var name_caracteres = true;
    }

    if (Cnpj === "") {
        span_cnpj.textContent = "Insira o CNPJ";
    } else if (Cnpj.length != 18) {
        var cnpj_obrigatorio = true;
        span_cnpj.textContent = "O CNPJ deve ter 18 caracteres!";
    } else if (!cnpjPattern.test(Cnpj)) {
        span_cnpj.textContent = "cnpj invalido";
        var cnpj_caracteres = true;
    } else if (span_cnpj.textContent === ""){
        span_cnpj.textContent = "";
        var cnpj_obrigatorio = true;
        var cnpj_caracteres = true;
        var cnpj_valido = true;
    }

    if (
        cnpj_obrigatorio &&
        name_obrigatorio &&
        cnpj_caracteres &&
        name_caracteres &&
        cnpj_valido
    ) {
        if (stage2.style.display === "none") {
            stage1.style.display = "none";
            stage2.style.display = "grid";
        } else {
            stage2.style.display = "none";
            stage1.style.display = "grid";
        }
    }
}

function show_stage3() {
    var city = document.getElementById("City").value.trim();
    var span_city = document.getElementById("error-City");

    var District = document.getElementById("District").value.trim();
    var span_District = document.getElementById("error-District");

    var Address = document.getElementById("Address").value.trim();
    var span_Address = document.getElementById("error-Address");

    var Complement = document.getElementById("Complement").value.trim();
    var span_Complement = document.getElementById("error-Complement");

    var Number = document.getElementById("Number").value.trim();
    var span_Number = document.getElementById("error-Number");

    if (city === "") {
        span_city.textContent = "Insira a cidade:";
    } else if (city.length >= 100) {
        span_city.textContent = "Cidade deve ser menor que 100 caracteres";
        var city_obrigatorio = true;
    } else {
        span_city.textContent = "";
        var city_obrigatorio = true;
        var city_caracteres = true;
    }

    if (District === "") {
        span_District.textContent = "Insira um bairro!";
    } else if (District.length >= 100) {
        span_District.textContent = "Bairro deve ser menor que 100 caracteres";
        var District_obrigatorio = true;
    } else {
        span_District.textContent = "";
        var District_obrigatorio = true;
        var District_caracteres = true;
    }

    if (Address === "") {
        span_Address.textContent = "Insira um logradouro!";
    } else if (Address.length >= 100) {
        span_Address.textContent =
            "Logradouro deve ser menor que 100 caracteres";
        var Address_obrigatorio = true;
    } else {
        span_Address.textContent = "";
        var Address_obrigatorio = true;
        var Address_caracteres = true;
    }

    if (Number === "") {
        span_Number.textContent = "Insira um numero!";
    } else if (Number !== "" && isNaN(Number)) {
        span_Number.textContent = "Deve ser um numero";
        var Number_obrigatorio = true;
    } else {
        span_Number.textContent = "";
        var Number_obrigatorio = true;
        var Number_caracteres = true;
    }

    if (Complement === "") {
        span_Complement.textContent = "Insira um complemento!";
    } else if (Complement.length >= 100) {
        span_Complement.textContent =
            "Complemento deve ser menor que 100 caracteres";
        var Complement_obrigatorio = true;
    } else {
        span_Complement.textContent = "";
        var Complement_obrigatorio = true;
        var Complement_caracteres = true;
    }

    if (
        city_obrigatorio &&
        District_obrigatorio &&
        Address_obrigatorio &&
        Number_obrigatorio &&
        Complement_obrigatorio &&
        city_caracteres &&
        District_caracteres &&
        Address_caracteres &&
        Number_caracteres &&
        Complement_caracteres
    ) {
        if (stage3.style.display === "none") {
            stage2.style.display = "none";
            stage3.style.display = "grid";
        } else {
            stage3.style.display = "none";
            stage2.style.display = "grid";
        }
    }
}

function validar_etapa3() {
    var email = document.getElementById("Email").value.trim();
    var span_email = document.getElementById("error-Email");

    var Password = document.getElementById("Password").value.trim();
    var span_Password = document.getElementById("error-Password");

    var regexemail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    var regexPassword = /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$/;

    if (email === "") {
        span_email.textContent = "Insira um email!";
    } else if (email.length >= 100) {
        span_email.textContent = "Email deve ser menor que 100 caracteres";
        var email_obrigatorio = true;
    } else if (!regexemail.test(email)) {
        span_email.textContent = "Email invalido";
        var email_caracteres = true;
        var email_obrigatorio = true;
    } else {
        span_email.textContent = "";
        var email_obrigatorio = true;
        var email_caracteres = true;
        var email_valido = true;
    }

   

    if (Password === "") {
        span_Password.textContent = "Insira uma senha!";
    } else if (Password.length < 8) {
        span_Password.textContent = "Senha não pode ser menor que 8 caracteres";
        var Password_obrigatorio = true;
    } else if (Password.length >= 30) {
        span_Password.textContent = "Senha deve ser menor que 30 caracteres";
        var Password_obrigatorio = true;
    } else if (!regexPassword.test(Password)) {
        span_Password.textContent = "A senha deve conter pelo menos uma letra minúscula, uma letra maiúscula, um caractere especial (@$!%*?&)";
        var Password_caracteres = true;
        var Password_obrigatorio = true;
    } else {
        span_Password.textContent = "";
        var Password_obrigatorio = true;
        var Password_caracteres = true;
        var Passwordvalido = true;
    }

    if (Passwordvalido && email_valido) {
        document.getElementById('form-register').submit()
    }
}

function validacao_login(){
  var Password_login = document.getElementById("Password-login").value.trim();
  var span_Password_login = document.getElementById("error-Password-login");

  var Cnpj_login = document.getElementById("Cnpj-login").value.trim();
  var span_cnpj_login = document.getElementById("error-Cnpj-login");

  var cnpjPattern = /^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$/;
  var regexPassword =  /^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$/;


  if (Cnpj_login === "") {
    span_cnpj_login.textContent = "Insira o CNPJ";
} else if (Cnpj_login.length != 18) {
    var cnpj_obrigatorio = true;
    span_cnpj_login.textContent = "O CNPJ deve ter 18 caracteres!";
} else if (!cnpjPattern.test(Cnpj_login)) {
  span_cnpj_login.textContent = "cnpj invalido";
    var cnpj_caracteres = true;
} else {
  span_cnpj_login.textContent = "";
    var cnpj_obrigatorio = true;
    var cnpj_caracteres = true;
    var cnpj_login_valido = true;
}


if (Password_login === "") {
    span_Password_login.textContent = "Insira uma senha!";
} else if (Password_login.length < 8) {
    span_Password_login.textContent = "Senha não pode ser menor que 8 caracteres";
    var Password_obrigatorio = true;
} else if (Password_login.length >= 30) {
    span_Password_login.textContent = "Senha deve ser menor que 30 caracteres";
    var Password_obrigatorio = true;
} else if (!regexPassword.test(Password_login)) {
    span_Password_login.textContent = "A senha deve conter pelo menos uma letra minúscula, uma letra maiúscula, um caractere especial (@$!%*?&)";
    var Password_caracteres = true;
    var Password_obrigatorio = true;
} else {
    span_Password_login.textContent = "";
    var Password_obrigatorio = true;
    var Password_caracteres = true;
    var Password_login_valido = true;
}


if (cnpj_login_valido && Password_login_valido) {
  document.getElementById('form-login').submit()
}
}

function show_senha_login() {
    var campoSenha = document.getElementById('Password-login');
    if (campoSenha.type === "password") {
        campoSenha.type = "text";
       
    } else {
        campoSenha.type = "password";
     
    }
}




function back_stage1() {
    if (btn_choice.style.display === "none") {
        btn_choice.style.display = "block";
        stage1.style.display = "none";
        form_register.style.display = "none";
    } else {
        stage1.style.display = "grid";
    }
}

function back_stage2() {
    if (stage1.style.display === "none") {
        stage1.style.display = "grid";
        stage2.style.display = "none";
    } else {
        stage2.style.display = "grid";
    }
}

function back_stage3() {
    if (stage2.style.display === "none") {
        stage2.style.display = "grid";
        stage3.style.display = "none";
    } else {
        stage3.style.display = "grid";
    }
}

function back_login() {
    if (btn_choice.style.display === "none") {
        btn_choice.style.display = "block";
        form_login.style.display = "none";
    }
}


function mascaraCNPJ() {
    var cnpjCadastro = document.getElementById("Cnpj").value;

    cnpjCadastro = cnpjCadastro.replace(/\D/g,"");

    var cnpjFormatado = cnpjCadastro;

    if (cnpjFormatado[2] != ".") {
        if (cnpjFormatado[2] != undefined) {
            cnpjFormatado = cnpjFormatado.slice(0, 2) + "." + cnpjFormatado.slice(2);
        }
    }

    if (cnpjFormatado[6] != ".") {
        if (cnpjFormatado[6] != undefined) {
            cnpjFormatado = cnpjFormatado.slice(0, 6) + "." + cnpjFormatado.slice(6);
        }
    }

    if (cnpjFormatado[10] != "/") {
        if (cnpjFormatado[10] != undefined) {
            cnpjFormatado = cnpjFormatado.slice(0, 10) + "/" + cnpjFormatado.slice(10);
        }
    }
    if (cnpjFormatado[15] != "-") {
        if (cnpjFormatado[15] != undefined) {
            cnpjFormatado = cnpjFormatado.slice(0, 15) + "-" + cnpjFormatado.slice(15);
        }
    }

    document.getElementById("Cnpj").value = cnpjFormatado;
}

function mascaraCNPJLogin() {
    var cnpjLogin = document.getElementById("Cnpj-login").value;

    cnpjLogin = cnpjLogin.replace(/\D/g, "");

    var cnpjLoginFormatado = cnpjLogin;

    if (cnpjLoginFormatado[2] != ".") {
        if (cnpjLoginFormatado[2] != undefined) {
            cnpjLoginFormatado = cnpjLoginFormatado.slice(0, 2) + "." + cnpjLoginFormatado.slice(2);
        }
    }

    if (cnpjLoginFormatado[6] != ".") {
        if (cnpjLoginFormatado[6] != undefined) {
            cnpjLoginFormatado = cnpjLoginFormatado.slice(0, 6) + "." + cnpjLoginFormatado.slice(6);
        }
    }

    if (cnpjLoginFormatado[10] != "/") {
        if (cnpjLoginFormatado[10] != undefined) {
            cnpjLoginFormatado = cnpjLoginFormatado.slice(0, 10) + "/" + cnpjLoginFormatado.slice(10);
        }
    }
    if (cnpjLoginFormatado[15] != "-") {
        if (cnpjLoginFormatado[15] != undefined) {
            cnpjLoginFormatado = cnpjLoginFormatado.slice(0, 15) + "-" + cnpjLoginFormatado.slice(15);
        }
    }

    document.getElementById("Cnpj-login").value = cnpjLoginFormatado;
}
