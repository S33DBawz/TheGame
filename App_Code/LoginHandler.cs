using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for LoginHandler
/// </summary>
public static class LoginHandler
{
    private static DataClassesDataContext db = new DataClassesDataContext();

    public static User CurrentUser
    {
        get
        {
            if (HttpContext.Current.Session["user"] == null)
            {
                User newUser = new User();
                newUser.role = 0;
                HttpContext.Current.Session["user"] = new User();
            }
            return HttpContext.Current.Session["user"] as User;
        }
    }
    public static bool Login(string email, string password)
    {
        bool status = false;

        if (db.Users.Any(user => user.email.Equals(email)))
        {
            User loggingUser = db.Users.First(user => user.email.Equals(email));

            if (PasswordHash.ValidatePassword(password, loggingUser.password))
            {
                HttpContext.Current.Session["user"] = loggingUser;
                status = true;
            }
        }
        return status;
    }
    public static bool IsUserLoggedIn()
    {
        return (CurrentUser.role > 0);
    }

    public static void Logout()
    {
        if (HttpContext.Current.Session["user"] != null)
        {
            HttpContext.Current.Session.Remove("user");
        }
    }
    public static int Register(string email, string password, int role)
    {
        if (!db.Users.Any(user => user.email.Equals(email)))
        {
            User createUser = new User();
            createUser.email = email;
            createUser.password = PasswordHash.CreateHash(password);
            createUser.role = role;

            db.Users.InsertOnSubmit(createUser);
            db.SubmitChanges();

            return createUser.id;
        }
        return -1;
    }
}