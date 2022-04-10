<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ManagamentCustomer.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="home">
<head runat="server">
    <link href="css/home.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="bottomHome">
        <form id="form1" runat="server" class="default">
            <div class="default">
                <h1>Gerenciamento de Usuários
                </h1>
                <asp:Button ID="RegisterCustomer" runat="server" CssClass="btn-initRegister" Text="Iniciar Cadastro" OnClick="RegisterCustomer_Click" />
                <table class="table">
                    <tr class="tr">
                        <th />
                        <th />

                        <th class="cabecalho">CPF</th>
                        <th class="cabecalho">Tipo de Cliente</th>
                        <th class="cabecalho">Sexo</th>
                        <th class="cabecalho">Situação do Cliente</th>
                        <th class="cabecalho">123</th>
                    </tr>
                    <% foreach (var customer in _Customers)
                        {%>
                    <tr class="tr">
                        <td>
                            <asp:Button ID="BtnDelete" runat="server" CommandArgument="<%customer.CPF%>" Text="Excluir" OnClick="BtnDelete_Click" />
                        </td>
                        <td>
                            <asp:Button ID="BtnEdit" runat="server" CommandArgument="<%customer.CPF%>" Text="Editar" OnClick="BtnEdit_Click" />

                        </td>
                        <td class="lista"><%customer.CPF.ToString(); %></td>
                        <td class="lista"><%customer.CustomerSituations.ToString();%></td>
                        <td class="lista"><%customer.CustomerTypes.ToString();%></td>
                        <td class="lista"><%customer.Sex.ToString();%></td>
                        <td class="lista">123</td>
                    </tr>
                    <%}%>
                </table>
            </div>
        </form>
    </div>
</body>
</html>
