<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSablonu.Master" AutoEventWireup="true" CodeBehind="Urunler.aspx.cs" Inherits="EticaretWebUı.Urunler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <asp:GridView CssClass="table table-responsie table-primary" ID="GridViewUrun" runat="server" OnSelectedIndexChanged="GridViewUrun_SelectedIndexChanged">
             <Columns>
                 <asp:CommandField ShowSelectButton="True" />
             </Columns>
        
    </asp:GridView>
    <table class="table table-primary table ">
      
        <tr>
            <td>Ürün Adı</td>
            <td><asp:TextBox ID="TxtAd" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ürün Açıklama</td>
            <td><asp:TextBox ID="TxtAciklama" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Fİyat</td>
            <td><asp:TextBox ID="TxtFiyat" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Kdv</td>
            <td><asp:TextBox ID="TxtKdv" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Stok Miktarı</td>
            <td><asp:TextBox ID="TxtStok" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>ToptanFiyat</td>
            <td><asp:TextBox ID="TxtToptanFiyat" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Marka</td>
            <td>
                <asp:DropDownList ID="DropDownMarka" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ürün</td>
            <td>
                <asp:DropDownList ID="DropDownKategori" runat="server"></asp:DropDownList>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ürün Resmi</td>
            <td>
                <asp:FileUpload ID="FileUploadResim" runat="server" />
            <td>
                <asp:HiddenField ID="HiddenFieldResim" runat="server" />
            </td>
        </tr>
         <tr>
            <td>Aktif Mi?</td>
            <td>
                <asp:CheckBox ID="CbAktifmi" runat="server" />
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
    <asp:Label ID="LblTarih" runat="server" Text=""></asp:Label>
</asp:Content>
