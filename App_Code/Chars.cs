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

    public static Character CurrentChar
    {
        get
        {
            return HttpContext.Current.Session[c] as Character;
        }
    }

    public static void SaveCharToSession(Character CharToSave)
    {
        if (CharToSave == null)
        {
            CharToSave = db.Characters.FirstOrDefault(cs => cs.Id.Equals(CurrentChar.Id));
        }
        HttpContext.Current.Session[c] = CharToSave;
    }

    public static void SaveCharToDb(int id, Character CharToSave)
    {
        if (CharToSave == null)
        {
            CharToSave = db.Characters.FirstOrDefault(cs => cs.Id.Equals(CurrentChar.Id));
        }
        Character CharToUpdate = CharToSave;

        CharToUpdate.Level = CharToSave.Level;
        CharToUpdate.Experience = CharToSave.Experience;
        CharToUpdate.Currency = CharToSave.Currency;
        db.SubmitChanges();
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

    public static Character GetCharFromDb(int id)
    {
        return db.Characters.FirstOrDefault(c => c.Id.Equals(id)) as Character;
    }

    public static void SelectChar(int id)
    {
        HttpContext.Current.Session[c] = GetCharList().FirstOrDefault(ci => ci.Id.Equals(id));
    }

    public static List<Character> GetCharList()
    {
        if (LoginHandler.CurrentUser.role != 0 && HttpContext.Current.Session[cl] == null)
        {
            List<Character> CharsToList = db.Characters.Where(ucc => ucc.User.Equals(LoginHandler.CurrentUser.id)).ToList();
            HttpContext.Current.Session[cl] = CharsToList;
        }
        return HttpContext.Current.Session[cl] as List<Character>;
    }

    public static void SaveCharList(List<Character> CharList)
    {
         HttpContext.Current.Session[cl] = CharList;
    }

    public static bool CharLimit()
    {
        return GetCharList().Count < 10;
    }

    public static int CharCount()
    {
        return GetCharList().Count;
    }

    public static int CharToCreate(string name, int race, int role, int user)
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

            status = true;
        }
        return status;
    }

    /*public static int CheckForLevelUp()
    {
        if (CurrentChar > db.Levels )
        return 1;
    }*/
}