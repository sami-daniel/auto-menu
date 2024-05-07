$(document).ready(function () {
    $('#Cnpj').blur(function () {
        var inputCnpj = $(this).val();

        $.ajax({
            url: `/Account/verify/cnpj`,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(inputCnpj),
            success: (response) => {
                if (response === 'Invalid CNPJ') {
                    $('#availabe-cnpj').text('CNPJ Inválido'); // Use .text() para definir o texto do elemento
                }
                else {
                    $('#availabe-cnpj').text('');
                }
            },
            error: (xhr, status, error) => {
                $('#availabe-cnpj').text('Não foi possivel verificar o CNPJ');
            }
        });
    });
});
