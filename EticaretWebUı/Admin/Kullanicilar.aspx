<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSablonu.Master" AutoEventWireup="true" CodeBehind="Kullanicilar.aspx.cs" Inherits="EticaretWebUı.Kullanicilar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView CssClass="table table-responsie table-primary" ID="GridViewKullanici" runat="server" OnSelectedIndexChanged="GridViewKullanici_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        
    </asp:GridView>

    <table class="table table-primary table ">
      
        <tr>
            <td>Kullanıcı Adı</td>
            <td><asp:TextBox ID="TxtKullaniciAd" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Sifre</td>
            <td><asp:TextBox ID="TxtSifre" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Email</td>
            <td><asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ad</td>
            <td><asp:TextBox ID="TxtAd" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Soyad</td>
            <td><asp:TextBox ID="TxtSoyad" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Aktif mi?</td>
            <td><asp:CheckBox ID="Cbaktifmi" runat="server" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Button CssClass="btn btn-success btn-xl" ID="BtnEkle" runat="server" Text="Ekle" OnClick="BtnEkle_Click"  /></td>
            <td><asp:Button CssClass="btn btn-primary" ID="BtnGuncelle" runat="server" Text="Guncelle" OnClick="BtnGuncelle_Click"  /></td>
            <td><asp:Button CssClass="btn btn-danger" ID="BtnSil" runat="server" Text="Sil" OnClick="BtnSil_Click" /></td>
        </tr>
    </table>
    <asp:Label ID="LblHata" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblId" runat="server" Text="0"></asp:Label>
    <asp:Label ID="LblTarih" runat="server" Text=""></asp:Label>
</asp:Content>
