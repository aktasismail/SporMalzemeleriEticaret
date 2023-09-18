<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSablonu.Master" AutoEventWireup="true" CodeBehind="Musteriler.aspx.cs" Inherits="EticaretWebUı.Musteriler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView CssClass="table table-responsie table-primary" ID="GridViewMusteri" runat="server" OnSelectedIndexChanged="GridViewMusteri_SelectedIndexChanged" >
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        
    </asp:GridView>

    <table class="table table-primary table ">
      
        <tr>
            <td></td>
             <td>
                 <asp:TextBox ID="TxtArama" runat="server"></asp:TextBox>
                 <asp:Button CssClass="btn btn-light" ID="BtnArama" runat="server" Text="Ara" OnClick="BtnArama_Click"/>
             </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Adı</td>
            <td><asp:TextBox ID="TxtAd" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Soyadı</td>
            <td><asp:TextBox ID="TxtSoyad" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Email</td>
            <td><asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Telefon</td>
            <td><asp:TextBox ID="TxtTelefon" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        
        <tr>
            <td><asp:Button CssClass="btn btn-success btn-xl" ID="BtnEkle" runat="server" Text="Ekle" OnClick="BtnEkle_Click"/></td>
            <td><asp:Button CssClass="btn btn-primary" ID="BtnGuncelle" runat="server" Text="Guncelle" OnClick="BtnGuncelle_Click"/></td>
            <td><asp:Button CssClass="btn btn-danger" ID="BtnSil" runat="server" Text="Sil" OnClick="BtnSil_Click"/></td>
        </tr>
    </table>
    <asp:Label ID="LblHata" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblId" runat="server" Text="0"></asp:Label>
    </asp:Content>
