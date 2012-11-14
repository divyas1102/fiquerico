<%@ Page Language="C#" CodeBehind="Default.aspx.cs" AutoEventWireup="true" Inherits="FiqueRico.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link media="screen" href="App_Themes/Default/css/style.css" rel="Stylesheet" type="text/css" />
    <link media="screen" href="App_Themes/Default/css/jquery.click-calendario-1.0.css"
        rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="http://jonatanmachado.com/fiquerico/fiquerico/js/exemplo-calendario.js"
        language="javascript"></script>
    <script type="text/javascript" src="http://jonatanmachado.com/fiquerico/fiquerico/js/jquery.click-calendario-1.0-min.js"
        language="javascript"></script>
    <%-- <script type="text/javascript" src="fiquerico/js/exemplo-calendario.js"></script>
    <script type="text/javascript" src="fiquerico/js/jquery.click-calendario-1.0-min.js"></script>--%>
    <script type="text/javascript" language="javascript">
        $('#dataAgenda').focus(function () { $(this).calendario({ target: '#dataAgenda' }); });
        function mascara(o, f) {
            v_obj = o
            v_fun = f
            setTimeout("execmascara()", 1)
        }
        function execmascara() {
            v_obj.value = v_fun(v_obj.value)
        }

        function MegasenaRegex(v) {
            v = v.replace(/\D/g, "");
            var chars = v.split("");
            var textoFormatado = "";
            for (var i = 1; i <= chars.length; i++) {
                textoFormatado += chars[i - 1];
                if (i != chars.length && i % 2 == 0) {
                    textoFormatado += '-';
                }
            }
            return textoFormatado;
        }
        function QuinaRegex(v) {
            v = v.replace(/\D/g, "");

            return v.replace(/^(\d{2})(\d{2})/g, "$1-$2");
        }
        window.onload = function () {
            var inputs = document.getElementsByTagName('input');
            for (var i = 0; i < inputs.length; i++) {
                var input = inputs[i];
                if (input.getAttribute('type') == 'text') {
                    input.onfocus = function () {
                        input.style.borderColor = '#666666';
                    }
                    input.onblur = function () {
                        input.style.borderColor = '#999999';
                    }
                }
            }
        };     
    </script>
</head>
<body>
    <div id="fb-root">
    </div>
    <script type="text/javascript">
        window.fbAsyncInit = function () {
            FB.init({
                appId: '205162109517014', // App ID            
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true  // parse XFBML
            });

            // Additional initialization code here
            FB.getLoginStatus(function (response) {
                if (response.status === 'connected') {
                    // the user is logged in and has authenticated your
                    // app, and response.authResponse supplies
                    // the user's ID, a valid access token, a signed
                    // request, and the time the access token 
                    // and signed request each expire
                    var uid = response.authResponse.userID;
                    var accessToken = response.authResponse.accessToken;
                    //alert(uid + " e " + accessToken);                    
                    $('#Content').css('display', 'inline');
                    document.getElementById('hdnAccessToken').value = accessToken + '|' + uid;
                } else if (response.status === 'not_authorized') {
                    // the user is logged in to Facebook, 
                    // but has not authenticated your app
                } else {
                    // the user isn't logged in to Facebook.
                    $('#Content').css('display', 'none');
                    $('#not-connect').css('display', 'inline');
                    FB.login(function (response) {
                        if (response.authResponse) {
                            console.log('Welcome!  Fetching your information.... ');
                            FB.api('/me', function (response) {
                                console.log('Good to see you, ' + response.name + '.');
                                $('#Content').css('display', 'inline');
                                $('#not-connect').css('display', 'none');
                            });
                        } else {
                            console.log('User cancelled login or did not fully authorize.');
                        }
                    });
                }
            });
        };

        // Load the SDK Asynchronously
        (function (d) {
            var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement('script'); js.id = id; js.async = false;
            js.src = "//connect.facebook.net/en_US/all.js";
            ref.parentNode.insertBefore(js, ref);
        } (document));

    </script>
    <form id="form1" runat="server">
    <asp:HiddenField runat="server" ID="hdnAccessToken" ClientIDMode="Static" />
    <asp:Panel ID="Content" ClientIDMode="Static" runat="server">
        <div id="main">
            <div id="header">
                <div id="logo">
                    FiqueRico
                </div>
            </div>
            <div style="display:none" id="rightbar">
                <div class="rightbarTit">
                    Ferramentas</div>
                <div id="grid" class="rightbarContent">
                    <p class="barra_tit">
                        Aposta já saiu?</p>
                    <p>
                        Escolha o jogo:</p>
                    <div>
                    </div>
                    <p class="barra_sub_tit">
                        Clique para selecionar a aposta:</p>
                    <p class="barra_sub_tit">
                        Resultado:</p>
                    <label id="lblResultado" runat="server" />
                </div>
                &nbsp;
            </div>
            <div id="content">
                <div id="menu">
                    <div class="top">
                        Escolha o Concurso
                        <asp:DropDownList CssClass="dropdown" ID="ddlConcurso" ClientIDMode="Static" runat="server">
                            <asp:ListItem Text=":: Selecione ::" Selected="True" Value="0" />
                            <asp:ListItem Value="60" Text="Megasena" />
                            <asp:ListItem Value="80" Text="Quina" />
                        </asp:DropDownList>
                        Escolha as Dezenas
                        <input class="borda_txt" type="text" id="dataAgenda" runat="server" />
                    </div>
                    <div class="middle">
                        <asp:RadioButtonList ID="rblOpcoes" RepeatColumns="2" runat="server">
                            <asp:ListItem Value="1" Text="Consultar aposta &nbsp;<img src='App_Themes/Default/img/info.png' title='Verifica se a aposta selecionada já foi sorteada alguma vez. Caso tenha ocorrido mais de uma vez, recupera apenas o último concurso.' alt='Consultar se aposta selecionada já saiu' />" />                            
                        </asp:RadioButtonList>
                    </div>
                    <div class="bottom">
                        <asp:Button ID="btnConsultaSeConcursoSaiu" OnClick="ConsultarSeConcursoSaiu" runat="server"
                            Text="Consultar" />
                    </div>
                </div>
                <div id="megasena" class="jogos">
                    <div class="texto">
                        <asp:Literal ID="lblMegasena" runat="server"></asp:Literal>
                    </div>
                </div>
                <div id="quina" class="jogos">
                    <div class="texto">
                        <asp:Literal ID="lblQuina" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="jogos">
                </div>
            </div>
        </div>
    </asp:Panel>
    <div id="not-connect" style="display: none">
        <p>
            Não identificamos você.</p>
        <p>
            Faça seu login no Facebook por favor!</p>
        <p>
            Ao término do processo, o conteúdo será exibido pra você. ;)</p>
        <p style="color: #FF0000; font-size: 15px; margin-top: 15px">
            *Se nenhuma janela aparecer, desbloqueie o popup.</p>
    </div>
    </form>
</body>
</html>
