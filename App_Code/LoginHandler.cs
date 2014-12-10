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
                newUser.Role = 0;
                HttpContext.Current.Session["user"] = new User();
            }
            return HttpContext.Current.Session["user"] as User;
        }
    }
    public static bool Login(string email, string password)
    {
        bool status = false;

        if (db.Users.Any(user => user.Email.Equals(email)))
        {
            User loggingUser = db.Users.First(user => user.Email.Equals(email));

            if (PasswordHash.ValidatePassword(password, loggingUser.Password))
            {
                HttpContext.Current.Session["user"] = loggingUser;
                status = true;
            }
        }
        return status;
    }
    public static bool IsUserLoggedIn()
    {
        return (CurrentUser.Role > 0);
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
        if (!db.Users.Any(user => user.Email.Equals(email)))
        {
            User createUser = new User();
            createUser.Email = email;
            createUser.Password = PasswordHash.CreateHash(password);
            createUser.Role = role;

            db.Users.InsertOnSubmit(createUser);
            db.SubmitChanges();

            return createUser.Id;
        }
        return -1;
    }
}