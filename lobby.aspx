<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="lobby.aspx.cs" Inherits="lobby" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="lobby">
        <div class="bg">
            <aside class="slide-in">
                <div class="sidebar-blurred"></div>
                <div class="sidebar-characters">

                    <!--Username-->
                    <h1>
                        <asp:Literal ID="account_name" runat="server" />
                        's Account</h1>
                    <!---->

                    <nav class="characters">

                        <ul>

                            <!--Characterss-->
                            <li><a href="#">
                                <span>
                                    <small>lvl</small>
                                    <small>11</small>
                                </span>
                                <h2>Swordmandk</h2>
                            </a></li>


                            <asp:Repeater runat="server" ID="rep_characters" ItemType="Character">
                                <ItemTemplate>

                                    <li><a href="#">
                                        <span>
                                            <small>lvl</small>
                                            <small><%# Item.Level %></small>
                                        </span>
                                        <h2><%# Item.Name %></h2>
                                    </a></li>

                                </ItemTemplate>
                            </asp:Repeater>




                            <li><a href="#">
                                <span>
                                    <small>lvl</small>
                                    <small>11</small>
                                </span>
                                <h2>Swordmandk</h2>
                            </a></li>
                            <!---->

                        </ul>

                    </nav>


                </div>
            </aside>
        </div>
    </section>

</asp:Content>

