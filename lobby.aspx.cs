using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lobby : System.Web.UI.Page
{
    private static DataClassesDataContext db = new DataClassesDataContext();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!LoginHandler.IsUserLoggedIn())
        {
            Response.Redirect("Login.aspx");
        }

        account_name.Text = Chars.CurrentUser.email;

        rep_characters.DataSource = Chars.GetCharList();
        rep_characters.DataBind();


    }
}