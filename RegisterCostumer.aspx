<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCostumer.aspx.cs" Inherits="ManagamentCostumer.RegisterCostumer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="opacity: 0.75; background-color: white; height: 710PX">
            <div style="margin-left: 100px">
                <div class="row">
                    <label class="titulocadastro">Cadastro de Cliente</label>
                </div>

                <div id="divCPF">
                    <div class="row">
                        <div class="col-2">
                            <label class="campos">CPF</label>
                        </div>
                        <asp:TextBox ID="CPF" runat="server"></asp:TextBox>

                    </div>

                    <div class="row">
                        <div class="col-2">
                            <label class="campos">Tipo de Cliente</label>
                        </div>
                        <asp:DropDownList ID="DropDownType" runat="server">
    
                        </asp:DropDownList>
                    </div>
                    <div class="row">
                        <div class="col-2">
                            <label class="campos">Situação do Cliente</label>
                        </div>
                        <asp:DropDownList ID="DropDownSituation" runat="server">
     
                        </asp:DropDownList>

                    </div>
                    <div>
                        <div class="col-2">
                            <label class="campos">Sexo</label>
                        </div>
                        <asp:DropDownList ID="DropDownSex" runat="server">
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <asp:Button ID="Button1" runat="server" Text="Cadastrar" OnClick="btnRegister_Click" />
                </div>

            </div>
    </form>
</body>
</html>
