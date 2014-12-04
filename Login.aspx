<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="login">
        <div class="bg">

            <div class="action-box">
                <div class="overlay"></div>
                <h1>Login or Signup </h1>

                <a class="login">
                    <span>Login</span>
                </a>

                <a class="signup">
                    <span>Signup</span>
                </a>

            </div>

            <div class="login-box">

                <span class="back"><small></small>Back</span>

                <h1>Login</h1>

                <asp:TextBox ID="tb_email" runat="server" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="tb_password" runat="server" placeholder="Password"></asp:TextBox>

                <asp:Button ID="btn_login" runat="server" Text="Login" OnClick="btn_login_OnClick"/>

            </div>

            <div class="signup-box">

                <span class="back"><small></small>Back</span>

                <h1>Signup</h1>

                <asp:TextBox ID="tb_reg_email" runat="server" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="tb_reg_password" runat="server" placeholder="Password"></asp:TextBox>

                <asp:Button ID="btn_register" runat="server" Text="Signup" OnClick="btn_register_OnClick"/>

            </div>


            <div class="container">
            </div>
        </div>
    </section>
</asp:Content>

