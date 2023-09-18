<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSablonu.Master" AutoEventWireup="true" CodeBehind="Markalar.aspx.cs" Inherits="EticaretWebUı.Markalar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewMarka" runat="server" OnSelectedIndexChanged="GridViewmarka_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <table class="table table-primary table ">
      
        <tr>
            <td>Marka Adı</td>
            <td><asp:TextBox ID="TxtAd" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Marka Açıklama</td>
            <td><asp:TextBox ID="TxtAciklama" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
       
        <tr>
            <td>Aktif mi?</td>
            <td><asp:CheckBox ID="Cbaktifmi" runat="server" /></td>
            <td>&nbsp;</td>
        </tr>
         <tr>
            <td><h1><asp:Label ID="LblHata" runat="server" Text=""></asp:Label></h1></td>
            <td><asp:Label ID="LblId" runat="server" Text="0"></asp:Label></td>
            <td><p>Eklenme Tarihi</p><asp:Label ID="LblTarih" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Button CssClass="btn btn-success btn-xl" ID="BtnEkle" runat="server" Text="Ekle" OnClick="BtnEkle_Click"/></td>
            <td><asp:Button CssClass="btn btn-primary" ID="BtnGuncelle" runat="server" Text="Guncelle" OnClick="BtnGuncelle_Click"/></td>
            <td><asp:Button CssClass="btn btn-danger" ID="BtnSil" runat="server" Text="Sil" OnClick="BtnSil_Click"/></td>
        </tr>
    </table>
</asp:Content>
