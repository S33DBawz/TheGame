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

    public static string c = "char";
    public static string cl = "charlist";

    private static List<Character> CharList;

    //CHAR HELPERS

    public static int CharCount()
    {
        return GetCharList().Count;
    }

    public static bool CharLimit(int count)
    {
        return GetCharList().Count < count;
    }

    //CHAR CONTROL

    public static void SelectChar(int id)
    {
        HttpContext.Current.Session[c] = GetCharList().FirstOrDefault(ci => ci.Id.Equals(id));
    }

    public static Character CurrentChar
    {
        get
        {
            return HttpContext.Current.Session[c] as Character;
        }
    }

    //CHAR SESSION CONTROL

    public static void SaveCharToSession()
    {
        Character CharToSave = (Character)GetCharList().Where(cc => cc.Id.Equals(CurrentChar.Id));
        HttpContext.Current.Session[c] = CharToSave;
    }

    public static Character GetCharFromSession()
    {
        Character GetChar = (Character)HttpContext.Current.Session[c];
        if (HttpContext.Current.Session[c] == null)
        {
            GetChar = db.Characters.FirstOrDefault(ch => ch.Id.Equals(CurrentChar.Id));
        }
        return GetChar;
    }

    //CHAR DATABASE CONTROL

    public static void SaveCharToDb()
    {
        //virker ikke
        Character CharToSave = (Character)GetCharList().Where(cc => cc.Id.Equals(CurrentChar.Id));

        Character CharToUpdate = new Character();

        CharToUpdate.Level = CharToSave.Level;
        CharToUpdate.Experience = CharToSave.Experience;
        CharToUpdate.Currency = CharToSave.Currency;
        db.SubmitChanges();
    }

    public static Character GetCharFromDb()
    {
        return db.Characters.FirstOrDefault(c => c.Id.Equals(CurrentChar.Id)) as Character;
    }

    //CHARLIST CONTROL

    public static List<Character> GetCharList()
    {
        if (LoginHandler.CurrentUser.role != 0)
        {
            List<Character> CharsToList = db.Characters.Where(ucc => ucc.User.Equals(LoginHandler.CurrentUser.id)).ToList();
            HttpContext.Current.Session[cl] = CharsToList;
        }
        return HttpContext.Current.Session[cl] as List<Character>;
    }
    public static void ClearCharList()
    {
        HttpContext.Current.Session.Remove(cl);
    }

    //CHAR OPTIONS
   
    public static int CharToCreate(string name, int race, int role, int user)
    {
        int result = -1;
        if (CharLimit(10))
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
<<<<<<< HEAD
        }
        return result;
    }

    /*public static void AddToChar(int id, int exp, int currency)
    {
        Character CharToUpdate = CurrentChar;
        if (CharToUpdate.Experience + exp > CheckForLevelUp())
        {
            CharToUpdate.Level++;
        }
        CharToUpdate.Experience = exp;
        CharToUpdate.Currency = currency;

        SaveCharToSession(CharToUpdate);
    }
    */
    public static bool CharToDelete(int id)
    {
        bool status = false;
        if (db.Characters.Any(c => c.Id.Equals(id)))
        {
            Character CharName = db.Characters.First(c => c.Id.Equals(id));
            db.Characters.DeleteOnSubmit(CharName);
            db.SubmitChanges();
=======

            CharList = GetCharList();
>>>>>>> 0e4314325cfb59eb52f0e6f6278bf7e76dd2068a

            GetCharList();
        }
        return result;
    }

<<<<<<< HEAD
    /*public static int CheckForLevelUp()
    {
        if (CurrentChar > db.Levels )
        return 1;
    }*/
=======
    //public static void AddToChar(int id, int exp, int currency)
    //{
    //    Character CharToUpdate = CurrentChar;
    //    if (CharToUpdate.Experience + exp > CheckForLevelUp())
    //    {
    //        CharToUpdate.Level++;
    //    }
    //    CharToUpdate.Experience = exp;
    //    CharToUpdate.Currency = currency;

    //    SaveCharToSession(CharToUpdate);
    //}

    //public static bool CharToDelete()
    //{
    //    bool status = false;
    //    if (db.Characters.Any(c => c.Id.Equals(CurrentChar.Id)))
    //    {
    //        Character CharName = db.Characters.First(c => c.Id.Equals(CurrentChar.Id));
    //        db.Characters.DeleteOnSubmit(CharName);
    //        db.SubmitChanges();

    //        status = true;
    //    }
    //    return status;
    //}

    //public static int CheckForLevelUp()
    //{
    //    if (CurrentChar > db.Levels)
    //        return 1;
    //}
>>>>>>> 0e4314325cfb59eb52f0e6f6278bf7e76dd2068a
}