/*As funções necessitam de JQuery, não esquecer de incluir o 
JQuery na página antes de usar essas funções
*/
webservice = "./fiquerico/fiquericoWS.asmx/";

$(document).ready(function () {
    //InicializarConcursos();
    $("#btnTeste").click(function () {
        $.ajax({ url: "CrossDomain.aspx",
            data: {concurso: "Megasena"},
            type: "GET",            
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                alert('inicio');//$("#" + tipoJogo).addClass("loading");
            },
            success: function (objJogo) {
                alert(objJogo.Tipo);
            },
            error: function () {
                alert("Hit error fn!");
            }
        });        
    });
});

function BuscarConcursoAnterior(tipoJogo) {
    $('#btnProximoQuina').removeAttr('disabled');
    $('#btnProximoMegasena').removeAttr('disabled');
    var numConcurso = eval($('#' + tipoJogo + ' #num_concurso' + tipoJogo).html());
    BuscarConcurso(tipoJogo, numConcurso - 1);
}

function BuscarConcursoProximo(tipoJogo) {
    var numConcurso = eval($('#' + tipoJogo + ' #num_concurso' + tipoJogo).html());
    BuscarConcurso(tipoJogo, numConcurso + 1);
}





function BuscarConcurso(tipoJogo, numConcurso) {

    //    $.jmsajaxurl = function (options) {
    //        var url = options.url;
    //        url += "/" + options.method;
    //        if (options.data) {
    //            var data = ""; for (var i in options.data) {
    //                if (data != "")
    //                    data += "&"; data += i + "=" + msJSON.stringify(options.data[i]);
    //            }
    //            url += "?" + data; data = null; options.data = "{}";
    //        }
    //        return url;
    //    };

    if (typeof numConcurso == "undefined")
        numConcurso = "0";

    $.ajax({ url: webservice + "RecuperarConcurso",
        data: { tipoJogo: JSON.stringify(tipoJogo), numConcurso: JSON.stringify(numConcurso) },
        dataType: "jsonp",
        beforeSend: function () {
            $("#" + tipoJogo).addClass("loading");
        },
        success: function (objJogo) {
            $("#" + tipoJogo).removeClass("loading");
                        if (objJogo != null) {
                            $('#' + objJogo.d.sTipoJogo + ' #num_concurso' + objJogo.d.sTipoJogo).html(objJogo.d.NumeroConcurso);
                            $('#' + objJogo.d.sTipoJogo + ' #data' + objJogo.d.sTipoJogo).html(objJogo.d.sDataConcurso);
                            $('#' + objJogo.d.sTipoJogo + ' #num_sorteados' + objJogo.d.sTipoJogo).html(objJogo.d.sDezenas);
                            $('#' + objJogo.d.sTipoJogo + ' #primeiro_premio_win' + objJogo.d.sTipoJogo).html("Sena: " + objJogo.d.JogoInfo.GanhadoresPrimeiroPremio);
                            $('#' + objJogo.d.sTipoJogo + ' #primeiro_premio_val' + objJogo.d.sTipoJogo).html("R$ " + objJogo.d.JogoInfo.ValorPrimeiroPremio);
                            $('#' + objJogo.d.sTipoJogo + ' #segundo_premio_win' + objJogo.d.sTipoJogo).html("Quina: " + objJogo.d.JogoInfo.GanhadoresSegundoPremio);
                            $('#' + objJogo.d.sTipoJogo + ' #segundo_premio_val' + objJogo.d.sTipoJogo).html("R$ " + objJogo.d.JogoInfo.ValorSegundoPremio);
                            $('#' + objJogo.d.sTipoJogo + ' #terceiro_premio_win' + objJogo.d.sTipoJogo).html("Quadra: " + objJogo.d.JogoInfo.GanhadoresTerceiroPremio);
                            $('#' + objJogo.d.sTipoJogo + ' #terceiro_premio_val' + objJogo.d.sTipoJogo).html("R$ " + objJogo.d.JogoInfo.ValorTerceiroPremio);
                            $('#' + objJogo.d.sTipoJogo + ' #acumulado_label' + objJogo.d.sTipoJogo).html("Acumulado: ");
                            $('#' + objJogo.d.sTipoJogo + ' #acumulado_val' + objJogo.d.sTipoJogo).html("R$ " + objJogo.d.JogoInfo.ValorAcumulado);
                        }            
        },
        error: function () {
            alert("Hit error fn!");
        }
    });

    /*
    var params = "";
    //params += "'tipoJogo':'" + tipoJogo + "','numConcurso':'" + numConcurso + "'"; via post
    params += "tipoJogo=" + tipoJogo + "&numConcurso=" + numConcurso + ""; //via get
    params += "";


    var url = webservice + "RecuperarConcurso?" + params;

    $.ajax({        
    cache: false,
    dataType: "jsonp",        
    success: function (d) { alert(d); },
    url: url + "&format=json"
    });
    */
    // $.getJSON(webservice + "RecuperarConcurso?" + params + "&callback=?", Teste);

    //    $.ajax({
    //        type: "GET",
    //        url: webservice + "RecuperarConcurso",
    //        data: params,
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        beforeSend: function () {
    //            $("#" + tipoJogo).addClass("loading");
    //        },        
    //        success: function (objJogo) {
    //            $("#" + tipoJogo).removeClass("loading");

    //            if (objJogo != null) {
    //                $('#' + objJogo.d.sTipoJogo + ' #num_concurso' + objJogo.d.sTipoJogo).html(objJogo.d.NumeroConcurso);
    //                $('#' + objJogo.d.sTipoJogo + ' #data' + objJogo.d.sTipoJogo).html(objJogo.d.sDataConcurso);
    //                $('#' + objJogo.d.sTipoJogo + ' #num_sorteados' + objJogo.d.sTipoJogo).html(objJogo.d.sDezenas);
    //                $('#' + objJogo.d.sTipoJogo + ' #primeiro_premio_win' + objJogo.d.sTipoJogo).html("Sena: " + objJogo.d.JogoInfo.GanhadoresPrimeiroPremio);
    //                $('#' + objJogo.d.sTipoJogo + ' #primeiro_premio_val' + objJogo.d.sTipoJogo).html("R$ " + objJogo.d.JogoInfo.ValorPrimeiroPremio);
    //                $('#' + objJogo.d.sTipoJogo + ' #segundo_premio_win' + objJogo.d.sTipoJogo).html("Quina: " + objJogo.d.JogoInfo.GanhadoresSegundoPremio);
    //                $('#' + objJogo.d.sTipoJogo + ' #segundo_premio_val' + objJogo.d.sTipoJogo).html("R$ " + objJogo.d.JogoInfo.ValorSegundoPremio);
    //                $('#' + objJogo.d.sTipoJogo + ' #terceiro_premio_win' + objJogo.d.sTipoJogo).html("Quadra: " + objJogo.d.JogoInfo.GanhadoresTerceiroPremio);
    //                $('#' + objJogo.d.sTipoJogo + ' #terceiro_premio_val' + objJogo.d.sTipoJogo).html("R$ " + objJogo.d.JogoInfo.ValorTerceiroPremio);
    //                $('#' + objJogo.d.sTipoJogo + ' #acumulado_label' + objJogo.d.sTipoJogo).html("Acumulado: ");
    //                $('#' + objJogo.d.sTipoJogo + ' #acumulado_val' + objJogo.d.sTipoJogo).html("R$ " + objJogo.d.JogoInfo.ValorAcumulado);
    //            }
    //        }
    //    });
}

function Teste(data) {
    alert(data);
}

function InicializarConcursos() {
    $('#btnProximoQuina').attr('disabled', 'disabled');
    $('#btnProximoMegasena').attr('disabled', 'disabled');
    BuscarConcurso('megasena');
    BuscarConcurso('quina');
}