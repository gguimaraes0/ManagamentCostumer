<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCostumer.aspx.cs" Inherits="ManagamentCustomer.RegisterCostumer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="home">
<head runat="server">
    <link href="css/home.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class="default">

        <div class="bottom">
            <div>
                <label class="cabecalho">Cadastro de Cliente</label>
            </div>
            <div class="row">
                <div class="name">
                    <label class="campos">CPF</label>
                </div>
                <asp:TextBox ID="CPF" runat="server" placeholder="Digite o CPF"></asp:TextBox>

            </div>

            <div class="row">
                <div class="name">
                    <label class="campos">Tipo de Cliente</label>
                </div>
                <asp:DropDownList ID="DropDownType" runat="server">
                </asp:DropDownList>
            </div>
            <div class="row">
                <div class="name">
                    <label class="campos">Situação do Cliente</label>
                </div>
                <asp:DropDownList ID="DropDownSituation" runat="server">
                </asp:DropDownList>

            </div>
            <div class="row">
                <div class="name">
                    <label class="campos">Sexo</label>
                </div>
                <asp:DropDownList ID="DropDownSex" runat="server">
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnRegister" runat="server" Text="Cadastrar" OnClick="btnRegister_Click" CssClass="btn-initRegister" />
        </div>
    </form>
</body>
</html>
