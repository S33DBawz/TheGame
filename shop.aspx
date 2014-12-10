<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shop.aspx.cs" Inherits="shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <aside class="sidebar">

        <header>
            <img src="" />
            <h1>Magimand420</h1>
        </header>

        <section class="stats-lockup">

            <div class="stat-unit" data-description="Vitality is the thing that keeps you alive, it supplies you with health so that you can defeat your opponents.">

                <img src="images/function-icons/heart.svg" />

                <span class="stat-title">Vitality</span>

                <span class="stat-amount">51</span>

            </div>

            <div class="stat-unit" data-description="Strength is the stat that keeps you fit! It increases your normal muscle mass with an extrodinary amount and helps you defeat them smelly foes!">

                <img src="images/function-icons/str.svg" />

                <span class="stat-title">Strength</span>

                <span class="stat-amount">18</span>

            </div>

            <div class="stat-unit" data-description="Dexterity is your Red Bull. It makes you super fast and even helps you strike faster.">

                <img src="images/function-icons/dex.svg" />

                <span class="stat-title">Dexterity</span>

                <span class="stat-amount">12</span>

            </div>

            <div class="stat-unit" data-description="'You're a wizard Harry!' *Cough That was bad Cough* Intellect makes your magical abilities do more damage and is the most useful stat on Mages and Warlocks.">

                <img src="images/function-icons/int.svg" />

                <span class="stat-title">Intellect</span>

                <span class="stat-amount">123</span>

            </div>

        </section>

        <section class="equipment-lockup">

            <div class="head-slot"></div>


            <div class="neck-slot"></div>


            <div class="equipment-slots">
                <div class="hands-slot"></div>
                <div class="body-slot"></div>
                <div class="feet-slot"></div>
            </div>


            <div class="equipment-slots">
                <div class="pants-slot"></div>
                <div class="weapon-slot"></div>
            </div>

        </section>

        <section class="combat-stats-lockup">
            <div class="stat-unit" data-description="This is your Attack points, these get balanced according to your Main weapon and what stats you have.">
                <img src="images/function-icons/sword.svg" />
                <span class="stat-title">Attack</span>
                <div class="stat-amount">32</div>
            </div>
            <div class="stat-unit shield" data-description="Armor helps you stay alive longer in fights, as it reduces the damage you take.">
                <img src="images/function-icons/shield.svg" />
                <span class="stat-title">Defence</span>
                <div class="stat-amount">312</div>
            </div>
        </section>

        <footer>
            <div class="currency">
                <img src="images/function-icons/coins.svg" />
                <span class="gold">271</span>
            </div>
            <ul>
                <li>
                    <img data-title="Iron Sword" data-stats="swag" data-desc="lorem penis 123" data-price="512" src="images/function-icons/dex.svg" /></li>
                <li>
                    <img data-title="Golden Apple" data-stats="lol" data-desc="askfhasdihaskdh" data-price="12" src="images/function-icons/heart.svg" /></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
            </ul>
        </footer>
        <div class="tooltip">
            <h6>Blood Sword</h6>

            <ul>
                <li>
                    <img src="images/function-icons/shield.svg" />
                    334</li>
                <li>
                    <img src="images/function-icons/heart.svg" />
                    72</li>
                <li>
                    <img src="images/function-icons/str.svg" />
                    58</li>
            </ul>

            <blockquote>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit fusce vel sapien elit in malesuada semper.
            </blockquote>

            <p>
                <img src="images/function-icons/coins.svg" />
                <span>1732</span></p>

        </div>

    </aside>

</asp:Content>
