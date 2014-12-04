using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Chars
/// </summary>
public class Chars
{
    static DataClassesDataContext db = new DataClassesDataContext();

    public static string u = "user";
    public static string c = "chars";

    private static List<Character> CharList;
    private static List<Character> CharCount;
    private static List<User> UserList;

    public static User CurrentUser
    {
        get
        {
            if (HttpContext.Current.Session[u] == null)
            {
                User newUser = new User();
                newUser.role = 0;
                HttpContext.Current.Session[u] = new User();
            }
            return HttpContext.Current.Session[u] as User;
        }        
    }

    public static List<Character> GetCharCount()
    {
        if (CurrentUser.role != 0 && HttpContext.Current.Session[c] == null)
        {
            List<Character> CharsToCount = db.Characters.Where(ucc => ucc.User.Equals(CurrentUser.id)).ToList();
            HttpContext.Current.Session[c] = CharsToCount;
        }        
        return HttpContext.Current.Session[c] as List<Character>;
    }

    public static List<Character> GetCharList()
    {

        List<Character> CharsToList = db.Characters.Where(uc => uc.User.Equals(CurrentUser.id)).Select(ch => ch).ToList();
        return CharsToList;
    }

	public static bool CharLimit()
	{           
        return GetCharCount().Count >= 10;
	}  
  
    public static int CreateChar(string name, int race, int role, int user)
    {
        int result = -1;
        if (CharLimit())
        {
            Character NewChar = new Character();

            NewChar.Name = name;
            NewChar.Race = race;
            NewChar.Class = role;
            NewChar.Level = 1;
            NewChar.Experience = 0;
            NewChar.Currency = 0;
            NewChar.User = CurrentUser.id;
            db.Characters.InsertOnSubmit(NewChar);
            db.SubmitChanges();

            result = NewChar.Id;
        }
        return result;
    }
}