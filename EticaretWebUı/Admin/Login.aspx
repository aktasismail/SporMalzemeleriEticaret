<%@ Page Title="" Language="C#" MasterPageFile="~/SiteSablonu.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EticaretWebUı.Admin.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="vh-100" style="background-color: #508bfc;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card shadow-2-strong" style="border-radius: 1rem;">
                        <div class="card-body p-5 text-center">

                            <h3 class="mb-5">Yönetici Girişi</h3>

                            <div class="form-outline mb-4">
                                <asp:Label ID="Label1" runat="server" Text="Kullanıcı Adı"></asp:Label>
                                <asp:TextBox ID="TxtKullaniciAdi" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-outline mb-4">
                                <asp:Label ID="Label2" runat="server" Text="Şifre"></asp:Label>
                                <asp:TextBox ID="TxtSifre" runat="server" CssClass="form-control form-control-lg"></asp:TextBox>
                            </div>
                            <asp:Button ID="BtnLogin" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="Giriş yap" OnClick="BtnLogin_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
