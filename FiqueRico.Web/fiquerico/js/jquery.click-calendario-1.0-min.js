function ultimo_dia(mes, ano) {
    if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
        return 31;
    if (mes == 4 || mes == 6 || mes == 9 || mes == 11) return 30;
    if (mes == 2) if (ano % 400 == 0) return 29;
    if (mes == 2) if (ano % 100 == 0) return 28;
    if (mes == 2) if (ano % 4 == 0) return 29; else return 28;
}
function ObterQtdDezena() {
    return $('#ddlConcurso option:selected').val();
}
var hoje = new Date();
var diaAtual = hoje.getDate();
var mesAtual = hoje.getMonth() + 1;
var anoAtual = hoje.getFullYear();
var dataAtual = diaAtual + '/' + mesAtual + '/' + anoAtual;
var contCalendario = 0; 
jQuery.fn.calendario = function (options) {
    var settings = {
        target: '',
        targetDay: '',
        targetMonth: '',
        targetYear: '',
        minDate: '',
        maxDate: '',
        dateDefault: dataAtual,
        left: '0',
        top: '30',
        referencePosition: this,
        closeClick: true
    };

    if ($('#ddlConcurso option:selected').val() == 0)
    { $('#ddlConcurso').focus(); return false; }
    else
        $('#ddlConcurso').attr("disabled", true);

    options = jQuery.extend(settings, options);
    arrData = options.dateDefault.split('/');
    diaOriginal = parseInt(arrData[0], 10);
    mesOriginal = parseInt(arrData[1], 10) - 1;
    anoOriginal = parseInt(arrData[2], 10);
    var diaMinimo = 0;
    var mesMinimo = 0;
    var anoMinimo = 0;
    if (options.minDate != '') {
        arrData = options.minDate.split('/');
        diaMinimo = parseInt(arrData[0], 10);
        mesMinimo = parseInt(arrData[1], 10) - 1; anoMinimo = parseInt(arrData[2], 10);
    }
    var diaMaximo = 9999;
    var mesMaximo = 9999;
    var anoMaximo = 9999;
    if (options.maxDate != '') {
        arrData = options.maxDate.split('/');
        diaMaximo = parseInt(arrData[0], 10);
        mesMaximo = parseInt(arrData[1], 10) - 1; anoMaximo = parseInt(arrData[2], 10);
    }
    this.each(function () {
        if (jQuery(this).attr('id') == '') {
            contCalendario++; jQuery(this).attr('id', 'chamada_cal_' + contCalendario);
        }
        idChamada = jQuery(this).attr('id');
        var mes = mesOriginal;
        var ano = anoOriginal;
        idCalendario = 'cal_' + idChamada;
        idCalendario = idCalendario.replace('_dia', '').replace('_mes', '').replace('_ano', '');
        if ($('#' + idCalendario).size() > 0)
            return false;
        jQuery('body').append('<div class="calendario" id="' + idCalendario + '"><a href="#" class="fechar" title="Fechar">X</a><ul class="lista_dia"></ul></div>');

        function preencher_calendario(idCalendario) {

            $('#' + idCalendario + ' ul.lista_dia li.dia_vazio').remove();
            $('#' + idCalendario + ' ul.lista_dia li.dia').remove();
            var primeiro = new Date();
            primeiro.setFullYear(ano, mes, 1);
            var inicioSemana = primeiro.getDay();
           

            var fimMes = ObterQtdDezena(); //60; //ultimo_dia(mes + 1, ano);
            for (i = 1; i <= fimMes; i++) {
                if (i < 10)
                    $('#' + idCalendario + ' ul.lista_dia').append("<li class='dia dia_n" + i + "'><a href='#'>0" + i + "<\/a><\/li>");
                else
                    $('#' + idCalendario + ' ul.lista_dia').append("<li class='dia dia_n" + i + "'><a href='#'>" + i + "<\/a><\/li>");
            }
            $('#' + idCalendario + ' ul.lista_dia li a').click(function () {
                var dia = $.trim($(this).html());
                var txtBox = $('#dataAgenda');
                var textoAtual = txtBox.val();

                if ($(this).css('color') == 'rgb(255, 0, 0)') {
                    $(this).css('color', '#666');

                    if (textoAtual.search('-' + dia + '-') != -1)
                        textoAtual = textoAtual.replace('-' + dia + '-', '-');
                    else if (textoAtual.search('-' + dia) != -1)
                        textoAtual = textoAtual.replace('-' + dia, '');
                    else if (textoAtual.search(dia + '-') != -1)
                        textoAtual = textoAtual.replace(dia + '-', '');
                    else
                        textoAtual = textoAtual.replace(dia, '');

                    txtBox.val(textoAtual);
                }
                else {
                    $(this).css('color', '#f00');

                    if (textoAtual == '')
                        txtBox.val(dia);
                    else
                        txtBox.val(textoAtual + '-' + dia);
                }
                return false;
            });
            navegacaoCalendario(idCalendario); 

        }
        function navegacaoCalendario(idCalendario) {
            $('#' + idCalendario + ' a.fechar').unbind();
            $('#' + idCalendario + ' a.fechar').click(
          function () {
              $('#' + idCalendario).remove();
              $('#ddlConcurso').attr("disabled", false);
              return false;
          });
            if (ano == anoMinimo && mes == mesMinimo) {
                $('#' + idCalendario + ' a.bt_voltar_mes').hide();
            } else {
                $('#' + idCalendario + ' a.bt_voltar_mes').show();
                $('#' + idCalendario + ' a.bt_voltar_mes').unbind();
                $('#' + idCalendario + ' a.bt_voltar_mes').click(
               function () {
                   mes = parseInt($('input[name="calendarioMes"]').val(), 10);
                   ano = parseInt($('input[name="calendarioAno"]').val(), 10); mes--; if (mes < 0) { mes = 11; ano--; } $('input[name="calendarioMes"]').val(mes); $('input[name="calendarioAno"]').val(ano); preencher_calendario(idCalendario); return false;
               });
            } if (ano == anoMaximo && mes == mesMaximo) {
                $('#' + idCalendario + ' a.bt_avancar_mes').hide();
            } else {
                $('#' + idCalendario + ' a.bt_avancar_mes').show();
                $('#' + idCalendario + ' a.bt_avancar_mes').unbind();
                $('#' + idCalendario + ' a.bt_avancar_mes').click(
                function () {
                    mes = parseInt($('input[name="calendarioMes"]').val(), 10);
                    ano = parseInt($('input[name="calendarioAno"]').val(), 10);
                    mes++;
                    if (mes == 12)
                    { mes = 0; ano++; }
                    $('input[name="calendarioMes"]').val(mes);
                    $('input[name="calendarioAno"]').val(ano);
                    preencher_calendario(idCalendario); return false;
                });
            }
        } preencher_calendario(idCalendario);
        var posicoes = $(options.referencePosition).offset();
        var leftPosition = posicoes.left + parseInt(options.left, 10);
        var topPosition = (posicoes.top + parseInt(options.top, 10) - 10);
        $('#' + idCalendario).css(
           { 'left': leftPosition - 47, 'top': topPosition });
        $('#' + idCalendario).show();
    });
};