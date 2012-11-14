$(document).ready(function () {

    AplicarToggle();
    //no Chrome ele não escondia por padrão.  
    $("#detalhesMega").hide();
    $("#detalhesQuina").hide();


});

function AplicarToggle() {
    $("#detalhesMega").toggle("fast");
    $("#detalhesQuina").toggle("fast");
    //Exibo a caixa que teve que ser escondia pelo problema no chrome
    $("#detalhesMega").show();
    $("#detalhesQuina").show();

    $("#toggleMega").click(function () {
        if ($("#toggleMega").html() == "Mostrar detalhes")
            $("#toggleMega").html("Esconder detalhes");
        else
            $("#toggleMega").html("Mostrar detalhes");      
       
        $("#detalhesMega").toggle("fast");
    });
    $("#toggleQuina").click(function () {
        if ($("#toggleQuina").html() == "Mostrar detalhes")
            $("#toggleQuina").html("Esconder detalhes");
        else
            $("#toggleQuina").html("Mostrar detalhes");
        
        $("#detalhesQuina").toggle("fast");
    });
}