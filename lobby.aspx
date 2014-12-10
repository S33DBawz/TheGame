<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="lobby.aspx.cs" Inherits="lobby" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="lobby">
        <div class="bg">
            <aside class="slide-in" id="character-selection">
                <div class="sidebar-blurred"></div>
                <div class="sidebar-characters">

                    <!--Username-->
                    <h1>
                        <asp:Literal ID="account_name" runat="server" />
                        's Account</h1>
                    <!---->

                    <nav class="characters">

                        <ul>

                            <!--Characters-->
                            <asp:Panel ID="Panel_Characters" Visible="false" runat="server">
                                <asp:Repeater runat="server" ID="rep_characters" ItemType="Character">
                                    <ItemTemplate>

                                        <li><a href="?Character=<%# Item.Name %>">
                                            <span>
                                                <small>lvl</small>
                                                <small><%# Item.Level %></small>
                                            </span>
                                            <h2><%# Item.Name %></h2>
                                            <h2><%# Item.Race1.Name %></h2>
                                            <h2><%# Item.Class1.Name %></h2>
                                        </a></li>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                            <!---->

                        </ul>

                    </nav>


                    <asp:Panel runat="server" Visible="false" ID="panel_create">
                        <ul>
                            <li>
                                <h3>What is your desired race?</h3>

                                <asp:RadioButtonList DataTextField="Name" DataValueField="Id" ItemType="Race" runat="server" ID="bl_races" />

                            </li>

                            <li>
                                <h3>What role would you like?</h3>

                                <asp:RadioButtonList DataTextField="Name" DataValueField="Id" ItemType="Class" runat="server" ID="bl_classes" />

                            </li>
                        </ul>
                    </asp:Panel>

                    <asp:Button runat="server" CssClass="btn-create-character" Text="Create New" ID="btn_create"></asp:Button>

                </div>

            </aside>

            <section id="main-content">
                <div class="enter-world">
                    <asp:Panel ID="panel_enter_world" runat="server">
                        <asp:Repeater ID="rep_character_info" runat="server">
                            <ItemTemplate>

                                <asp:Image runat="server" ID="character_image" />

                                <h3>
                                    <asp:Literal runat="server" ID="char_name"></asp:Literal></h3>
                                <h3>
                                    <asp:Literal ID="char_level" runat="server"></asp:Literal></h3>

                                <h3>
                                    <asp:Literal ID="char_class" runat="server"></asp:Literal></h3>

                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>

                    <asp:Panel Visible="false" ID="panel_character_information" runat="server">
                    </asp:Panel>

                </div>
                <a class="btn-play" href="#"><span>Enter World</span></a>


            </section>

        </div>
    </section>
</asp:Content>

