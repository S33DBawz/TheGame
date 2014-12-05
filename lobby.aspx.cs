using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lobby : System.Web.UI.Page
{
    private static DataClassesDataContext db = new DataClassesDataContext();

    private int SelectedRace = -1;
    private int SelectedClass = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        bl_races.DataSource = db.Races.ToList();
        bl_races.DataBind();
        bl_classes.DataSource = db.Classes.ToList();
        bl_classes.DataBind();


        if (!LoginHandler.IsUserLoggedIn())
        {
             Response.Redirect("Login.aspx");
        }

        account_name.Text = LoginHandler.CurrentUser.email;








        if (Request.QueryString["character"] != null)
        {

            switch (Request.QueryString["character"])
            {
                    
                case "create":

                    panel_create.Visible = true;

                    break;


                case "show":


                    break;

            }

        }
        else
        {
            Panel_Characters.Visible = true;
            rep_characters.DataSource = Chars.GetCharList();
            rep_characters.DataBind();
        }



























        // db.UserInformations.Where(un => un.Name == Request.QueryString["Character"]);

        // rep_characters.DataSource = Chars.GetCharList();
        // rep_characters.DataBind();

        // if (Chars.CharCount() == 0)
        // {
        //     Literal_Delete.Visible = false;
        // }

        // if (!Chars.CharLimit())
        // {
        //     Literal_Create.Visible = false;
        // }

        // if (Request.RawUrl.Contains("Character") && Request.QueryString["Character"] == null)
        // {
        //     Panel_Characters.Visible = false;

        //     /*rep_races.DataSource = db.Races.ToList();
        //     rep_races.DataBind();

        //     rep_classes.DataSource = db.Classes.ToList();
        //     rep_classes.DataBind();*/

        //     if (SelectedRace != -1)
        //     {
        //         SelectedRace = Convert.ToInt16(Request.QueryString["Race"]);
        //     }

        //     if (SelectedClass != -1)
        //     {
        //         SelectedRace = Convert.ToInt16(Request.QueryString["Class"]);
        //     }

        //     if (SelectedRace == -1 && Request.QueryString["Race"] == null)
        //     {
        //         Panel_Race.Visible = true;
        //     }
        //     if (Request.QueryString["Race"] != null && SelectedClass == -1 && Request.QueryString["Class"] == null)
        //     {
        //         Panel_Class.Visible = true;
        //     }
        //     if (Request.QueryString["Race"] != null && Request.QueryString["Class"] != null)
        //     {
        //         Panel_Create.Visible = true;
        //     }
        // }
        // if (Panel_Characters.Visible = true && Request.QueryString["Character"] != null)
        // {
        //    Repeater_Info.DataSource = db.Characters.Where(ui => ui.Name == Request.QueryString["Character"]);
        //     Repeater_Info.DataBind();
        // }
        ///* if (Panel_Race.Visible == false && Panel_Class.Visible == false && Panel_Create.Visible == false)
        // {
        //     Panel_Characters.Visible = true;
        // }*/
        //}
        //protected void Button_Create_Click(object sender, EventArgs e)
        //{
        //   /* Chars.CreateChar(TextBox_Name.Text, Convert.ToInt16(Request.QueryString["Race"]), Convert.ToInt16(Request.QueryString["Class"]), Convert.ToInt16(LoginHandler.CurrentUser.id));
        //    Response.Redirect("Lobby.aspx");*/
        //}
        //protected void Button_Play_Click(object sender, EventArgs e)
        //{
        //    //if (Panel_Characters.Visible = true && Request.QueryString["Character"] != null)
        //    //{
        //    //    HttpContext.Current.Session["game"] = Chars.GetCharList().Where(cc => cc.Name == Request.QueryString["Character"]);
        //    //    Response.Redirect("Game.Aspx");
        //    //}
        //}
    }
}