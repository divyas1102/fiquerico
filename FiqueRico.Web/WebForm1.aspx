<%@ Page Language="C#" AutoEventWireup="true" ViewStateMode="Disabled" CodeBehind="WebForm1.aspx.cs"
    Inherits="FiqueRico.Web.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.4/jquery.min.js"></script>
    <script type="text/javascript">

        function SetarNovaBusca(concursoAtual) {
            var num = parseInt($("#lblNumConcurso").html());
            num += concursoAtual;
            $("#hdnNovaBusca").val(num);
        }


    </script>
    <link media="screen" href="App_Themes/Default/css/style.css" rel="Stylesheet" type="text/css" />
    <title>Loterias Caixa</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main" class="centralizar">
        <div class="barra_lateral">
            <div class="texto_center">
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
                sss<br />
            </div>
        </div>
        <div id="header">fdasfdafsa</div>
       <asp:Label ID="lblJogoHTML" runat="server"></asp:Label>

       <%-- <div id="megasena" class="centralizar">
            <div id="titulo" class="centralizar">
                <asp:Image ID="imgTitulo" runat="server" />
            </div>
            <div id="info" class="centralizar">
                <asp:HiddenField ID="hdnNovaBusca" ClientIDMode="Static" runat="server" />
                <asp:Label ID="lblNumConcurso" ClientIDMode="Static" runat="server"></asp:Label>
                <asp:Label ID="lblInfo" runat="server"></asp:Label>
                <asp:Label ID="lblAcumulado" runat="server"></asp:Label>
            </div>
            <div id="numeros" class="centralizar">
                <asp:Label ID="lblNumeros" runat="server"></asp:Label>
            </div>
            <div id="premio" class="centralizar">
                <asp:Label ID="lblPremio" runat="server"></asp:Label>
            </div>
            <div id="outros" class="centralizar">
                <div class="left">
                    <asp:LinkButton ID="lnkAnterior" runat="server" Text="Anterior" OnClientClick="SetarNovaBusca(-1)"
                        OnClick="BuscaNovoConcurso"></asp:LinkButton>
                </div>
                <div class="right">
                    <asp:LinkButton ID="lnkProximo" runat="server" OnClientClick="SetarNovaBusca(1)"
                        Text="Proximo" OnClick="BuscaNovoConcurso"></asp:LinkButton>
                </div>
            </div>
        </div>--%>
    </div>
    </form>
</body>
</html>
