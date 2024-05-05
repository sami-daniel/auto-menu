$(document).ready(function () {
    $('#Cnpj').keyup(function () {
        var inputCnpj = $(this).val();

        $.ajax({
            url: '/Account/CheckCNPJAvailability', // Verifique se a rota está correta
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(inputCnpj), // Apenas envie a string diretamente
            success: (response) => {
                if (response === 'Invalid CNPJ') {
                    $('#error-Cnpj').text('CNPJ Inválido'); // Use .text() para definir o texto do elemento
                }
                else {
                    $('#error-Cnpj').text('CNPJ Válido');
                }
            },
            error: (xhr, status, error) => {
                $('#error-Cnpj').text('CNPJ Inválido');
            }
        });
    });
});
