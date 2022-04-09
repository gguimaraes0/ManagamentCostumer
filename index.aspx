<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMain.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ManagamentCostumer.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gerenciamento de Usuários
    </h1>
    <asp:Button ID="Button1" runat="server" Text="Iniciar Cadastro" OnClick="Button1_Click" />
    <asp:ListBox ID="ListCustomers" runat="server" Height="486px" Width="944px" DataTextField="CPF"></asp:ListBox>
</asp:Content>
