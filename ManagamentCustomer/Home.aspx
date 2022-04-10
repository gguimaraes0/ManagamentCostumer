<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ManagamentCustomer.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/home.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <title></title>
</head>
<body class="home">
    <div class="bottom">
        <form id="form1" runat="server">
            <div class="default">
                <label class="cabecalho">Gerenciamento de Usuários</label>
                <asp:Button ID="RegisterCustomer" runat="server" CssClass="btn-initRegister btn btn-primary" Text="Iniciar Cadastro" OnClick="RegisterCustomer_Click" />
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col" />
                            <th scope="col" />
                            <th scope="col">CPF</th>
                            <th scope="col">Tipo de Cliente</th>
                            <th scope="col">Sexo</th>
                            <th scope="col">Situação do Cliente</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repCustomer" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Button ID="BtnDelete" runat="server" CssClass="btn-danger" CommandArgument='<%# Eval("CPF") %>' Text="Excluir" OnClick="BtnDelete_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnEdit" runat="server" CssClass="btn-success" CommandArgument='<%# Eval("CPF") %>' Text="Editar" OnClick="BtnEdit_Click" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text='<%# Eval("CPF") %>' ReadOnly="true" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text='<%# Eval("CustomerTypes") %>' ReadOnly="true" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSex" runat="server" Text='<%# Eval("Sex") %>' ReadOnly="true" />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text='<%# Eval("CustomerSituations") %>' ReadOnly="true" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </form>
    </div>
</body>
</html>
