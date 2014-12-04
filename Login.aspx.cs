using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_login_OnClick(object sender, EventArgs e)
    {

        if (LoginHandler.Login(tb_email.Text, tb_password.Text))
        {
            
            Response.Redirect("lobby.aspx");

        }

    }

    protected void btn_register_OnClick(object sender, EventArgs e)
    {

        LoginHandler.Register(tb_reg_email.Text, tb_reg_password.Text, 4);

        if (LoginHandler.Login(tb_reg_email.Text, tb_reg_password.Text))
        {

            Response.Redirect("lobby.aspx");

        }

    }
}