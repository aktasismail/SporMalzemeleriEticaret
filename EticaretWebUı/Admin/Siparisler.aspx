<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSablonu.Master" AutoEventWireup="true" CodeBehind="Siparisler.aspx.cs" Inherits="EticaretWebUı.Siparisler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:GridView CssClass="table table-responsie table-primary" ID="GridViewSiparis" runat="server" OnSelectedIndexChanged="GridViewSiparis_SelectedIndexChanged">
         <Columns>
             <asp:CommandField ShowSelectButton="True" />
         </Columns>
        
    </asp:GridView>
    <table class="table table-primary table ">
      
        <tr>
            <td>Siparis No</td>
            <td><asp:TextBox ID="TxtSipariNo" runat="server"></asp:TextBox></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Müşteri</td>
            <td>
                <asp:DropDownList ID="DropDownMusteri" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Ürün</td>
            <td>
                <asp:DropDownList ID="DropDownUrun" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Button CssClass="btn btn-success btn-xl" ID="BtnEkle" runat="server" Text="Ekle" OnClick="BtnEkle_Click" /></td>
            <td><asp:Button CssClass="btn btn-primary" ID="BtnGuncelle" runat="server" Text="Guncelle" OnClick="BtnGuncelle_Click" /></td>
            <td><asp:Button CssClass="btn btn-danger" ID="BtnSil" runat="server" Text="Sil" OnClick="BtnSil_Click" /></td>
        </tr>
    </table>
    <asp:Label ID="LblHata" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblId" runat="server" Text="0"></asp:Label>
    <asp:Label ID="LblTarih" runat="server" Text=""></asp:Label>
</asp:Content>
