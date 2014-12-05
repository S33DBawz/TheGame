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

    public static string c = "chars";

    public static List<Character> GetCharList()
    {
        if (LoginHandler.CurrentUser.role != 0 && HttpContext.Current.Session[c] == null)
        {
            List<Character> CharsToList = db.Characters.Where(ucc => ucc.User.Equals(LoginHandler.CurrentUser.id)).ToList();
            HttpContext.Current.Session[c] = CharsToList;
        }
        return HttpContext.Current.Session[c] as List<Character>;
    }

    public static bool CharLimit()
    {
        return GetCharList().Count < 10;
    }

    public static int CharCount()
    {
        return GetCharList().Count;
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
            NewChar.User = user;
            db.Characters.InsertOnSubmit(NewChar);
            db.SubmitChanges();

            result = NewChar.Id;
        }
        return result;
    }

    public static bool AddToChar(int id, int exp, int currency)
    {
        bool status = false;
        if (db.Characters.Any(c => c.Id.Equals(id)))
        {
            Character CharToUpdate = db.Characters.First(c => c.Id.Equals(id));
            //Run LevelUpChecker()
            if (CharToUpdate.Experience + exp > LevelUpChecker())
            {
                CharToUpdate.Level++;
            }
            CharToUpdate.Experience = exp;
            CharToUpdate.Currency = currency;
            

        }
        return status;
    }

    public static bool DeleteChar(int id)
    {
        bool status = false;
        if (db.Characters.Any(c => c.Id.Equals(id)))
        {
            Character CharName = db.Characters.First(c => c.Id.Equals(id));
            db.Characters.DeleteOnSubmit(CharName);
            db.SubmitChanges();

            status = true;
        }
        return status;
    }

    public static int LevelUpChecker()
    {
        return 1;
    }
}