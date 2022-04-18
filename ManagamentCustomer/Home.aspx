<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ManagamentCustomer.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/home.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js" integrity="sha512-894YE6QWD5I59HgZOGReFYm4dnWc1Qt5NtvYSaNcOP+u1T9qYdvdihz0PPSiiqn/+/3e7Jo4EaG7TubfWGUrMQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.8/jquery.mask.min.js" integrity="sha512-hAJgR+pK6+s492clbGlnrRnt2J1CJK6kZ82FZy08tm6XG2Xl/ex9oVZLE6Krz+W+Iv4Gsr8U2mGMdh0ckRH61Q==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <title></title>
</head>
<body class="home">
    <div class="bottom">
        <form id="form1" runat="server">
            <div class="default">
                <label class="cabecalho">Gerenciamento de Clientes</label>
                <div class="divButtons">
                    <div>
                        <asp:Button ID="RegisterCustomer" runat="server" CssClass="btn-init btn btn-primary" Text="Iniciar Cadastro" OnClick="RegisterCustomer_Click" />
                    </div>
                    <div>
                        <asp:Button ID="SearchById" runat="server" CssClass="btn-search btn btn-warning" Text="Buscar por CPF" OnClick="SearchById_Click" />
                        <asp:TextBox ID="inputCPF" type="text" runat="server" class="inputCPF"></asp:TextBox>
                        <asp:Button ID="ClearSearch" runat="server" CssClass="btn-clear btn btn-info" Text="Limpar Busca" OnClick="ClearSearch_Click" />
                    </div>
                </div>
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
                                        <asp:Label class="lblCPF" runat="server" Text='<%# Eval("CPF") %>' ReadOnly="true" />
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
<script>
    $('.lblCPF').mask('000.000.000-00');
    $('.inputCPF').mask('000.000.000-00');
    $('#BtnDelete').on('closed.bs.alert', function () {
        // do something…
    })
</script>
<script type="text/javascript" language="javascript">
    function alertDelete() {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }
        })
    }
</script>

    <script>

        function cConfirm(str, link) {
            if (window.confirm(str)) {
                window.location.href = link;
            } else {
                // código que queres executar caso sepra pessionado CANCEL
            }
        }
    </script>
</html>
