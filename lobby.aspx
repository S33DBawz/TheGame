<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="lobby.aspx.cs" Inherits="lobby" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="lobby">
        <div class="bg">
            <aside class="slide-in">
                <div class="sidebar-blurred"></div>
                <div class="sidebar-characters">
                    <div class="wrapper">

                        <!--Username-->
                        <h1>
                            <asp:Literal ID="account_name" runat="server" />
                            's Account</h1>
                        <!---->
                        PIK
                        <nav class="characters">

                            <!--Race Selection-->
                            <asp:Panel ID="Panel_Race" runat="server" Visible="false">
                                <asp:Repeater ID="rep_races" runat="server" ItemType="Race">
                                    <ItemTemplate>
                                        <li><a href="<%# HttpContext.Current.Request.Url.ToString() + "&Race=" + Item.Id %>">
                                            <h2><%# Item.Name %></h2>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                            <!---->

                            <!--Class Selection-->
                            <asp:Panel ID="Panel_Class" runat="server" Visible="false">
                                <asp:Repeater ID="rep_classes" runat="server" ItemType="Class">
                                    <ItemTemplate>
                                        <li><a href="<%# HttpContext.Current.Request.Url.ToString() + "&Class=" + Item.Id %>">
                                            <h2><%# Item.Name %></h2>
                                        </a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                            <!---->

                            <!--Create Character-->
                            <asp:Panel ID="Panel_Create" runat="server" Visible="false">
                                <asp:TextBox ID="TextBox_Name" runat="server" placeholder="Character Name"></asp:TextBox>
                                <asp:Button ID="Button_Create" runat="server" OnClick="Button_Create_Click" Text="Create Character" />
                            </asp:Panel>
                            <!---->

                            <ul>

                                <!--Characters-->
                                <asp:Panel ID="Panel_Characters" runat="server">
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
                    </div>
                    <nav class="buttons">
                        <ul>
                            <asp:Literal ID="Literal_Delete" runat="server"><li><a href="%Delete"><h2>Delete Character</h2></a></li></asp:Literal>
                            <asp:Literal ID="Literal_Create" runat="server"><li><a href="?Character"><h2>Create New Character</h2></a></li></asp:Literal>
                            <li><a href="?Account"><h2>Account Settings</h2></a></li>
                            <li><a href="?Logout=true"><h2>Logout</h2></a></li>
                        </ul>
                    </nav>


                </div>
            </aside>

            <!--HØJRE SIDE-->
            <div class="højreside">

                <!--Character Info-->
                <asp:Panel ID="Panel_Info" runat="server">
                    <asp:Repeater runat="server" ID="Repeater_Info" ItemType="Character">
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

                <div class="play">
                    <asp:Button ID="Button_Play" runat="server" Text="Enter World" OnClick="Button_Play_Click" />
                </div>

            </div>

        </div>
    </section>

</asp:Content>

