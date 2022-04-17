<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCostumer.aspx.cs" Inherits="ManagamentCustomer.RegisterCostumer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/register.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js" integrity="sha512-894YE6QWD5I59HgZOGReFYm4dnWc1Qt5NtvYSaNcOP+u1T9qYdvdihz0PPSiiqn/+/3e7Jo4EaG7TubfWGUrMQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.8/jquery.mask.min.js" integrity="sha512-hAJgR+pK6+s492clbGlnrRnt2J1CJK6kZ82FZy08tm6XG2Xl/ex9oVZLE6Krz+W+Iv4Gsr8U2mGMdh0ckRH61Q==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <title></title>
</head>
<body class="register">
    <form id="form1" runat="server" class="default">
        <div class="bottom">
            <div>
                <label class="cabecalho">Cadastro do Cliente</label>
            </div>
            <div class="row">
                <div class="name">
                    <label class="campos">CPF</label>
                </div>
                <asp:TextBox ID="CPF" runat="server" placeholder="Digite o CPF"></asp:TextBox>
                <asp:Label ForeColor="Red" runat="server" Text="" ID="lblValidateCPF"></asp:Label>
                <br />
            </div>

            <div class="row">
                <div class="name">
                    <label class="campos">Tipo de Cliente</label>
                </div>
                <asp:DropDownList ID="DropDownType" runat="server">
                </asp:DropDownList>
                <span asp-validation-for="type" class="text-danger"></span>
                <br />
            </div>
            <div class="row">
                <div class="name">
                    <label class="campos">Situação do Cliente</label>
                </div>
                <asp:DropDownList ID="DropDownSituation" runat="server">
                </asp:DropDownList>
                <span asp-validation-for="situation" class="text-danger"></span>
                <br />
            </div>
            <div class="row">
                <div class="name">
                    <label class="campos">Sexo</label>
                </div>
                <asp:DropDownList ID="DropDownSex" runat="server">
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                </asp:DropDownList>
                <span asp-validation-for="sex" class="text-danger"></span>
                <br />
            </div>

            <asp:Button ID="btnRegister" runat="server" Text="Cadastrar" OnClick="btnRegister_Click" CssClass="btn-Register btn btn-primary" />
        </div>
    </form>
</body>
<script>
    $('#CPF').mask('000.000.000-00');
</script>
</html>
