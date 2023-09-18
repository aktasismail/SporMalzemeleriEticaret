<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteSablonu.Master" CodeBehind="Default.aspx.cs" Inherits="EticaretWebUı.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
      .urunler {
            display: flex;
            align-content: center;
            align-items: center;
            flex-wrap: wrap;
            justify-content:space-around;
            margin:1%;
        }
        .linkler{
            height:20%;
            width:20%; 
            background-color:dodgerblue;
            text-align:center;
            margin:1% !important;
            border-radius:5%;
            
        }
        a{
            text-decoration:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="urunler">
            <asp:Repeater ID="RptUrun" runat="server">
                <ItemTemplate>
                    <div class="linkler">
                        <a href="/Admin/UrunDetay.aspx?urunId=<%#Eval("Id")%>">
                        <img src="/Images/<%#Eval("UrunResmi")%>" alt="Resim Yok" height="200" />
                        <hr />
                        <h3><%#Eval("UrunAdi")%></h3>
                    </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </asp:Content>
