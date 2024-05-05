$(document).ready(function () {
    $('#Cnpj').blur(function () {
        var inputCnpj = $(this).val();

        $.ajax({
            url: '/Account/CheckCNPJAvailability', // Verifique se a rota está correta
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(inputCnpj), // Apenas envie a string diretamente
            success: (response) => {
                if (response === 'Invalid CNPJ') {
                    $('#availabe-cnpj').text('CNPJ Inválido'); // Use .text() para definir o texto do elemento
                }
                else {
                    $('#availabe-cnpj').text('');
                }
            },
            error: (xhr, status, error) => {
                $('#availabe-cnpj').text('CNPJ Inválido');
            }
        });
    });
});
