function SetNum() {
    var num = $("#numero").val();
    if (num == "" || num < 0)
        return num = 0;
}

$("#numero").val(SetNum());

$('#cep').keyup(function GetCep() {
    var cep = $(this).val().replace('-', '');
    $("#cep").val(cep);
    $.ajax({
        url: 'https://viacep.com.br/ws/' + cep + '/json',
        dataType: 'json',
        success: function (resposta) {
            $("#logradouro").val(resposta.logradouro);
            $("#complemento").val(resposta.complemento);
            $("#bairro").val(resposta.bairro);
            $("#localidade").val(resposta.localidade);
            $("#uf").val(resposta.uf);
            $("#numero").val(SetNum());
            $("#numero").focus();
        }
    })
});