<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSablonu.Master" AutoEventWireup="true" CodeBehind="UrunDetay.aspx.cs" Inherits="EticaretWebUı.Admin.UrunDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <table class="table table-active">
            <tr>
                <td><h1 id="Baslik" runat="server"></h1></td>
                <td></td>
            </tr>
            <tr>
                <td><asp:Image ID="UrunResmi" runat="server" Height="400px"/></td>
                <td> <asp:Literal ID="UrunAciklama" runat="server"></asp:Literal></td>
            </tr>
        </table>

    </div>
</asp:Content>
