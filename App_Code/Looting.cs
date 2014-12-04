using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Looting
/// </summary>
public class Looting
{
    static DataClassesDataContext db = new DataClassesDataContext();

    public static string i = "item";
    public static string h = "hostile";

    private static List<item> ListLoot;
    private static List<monster> hostileList;

    int start = 0;
    int end = 100;

    public static List<item> GetLoot()
    {
        if (HttpContext.Current.Session[i] == null)
        {
            HttpContext.Current.Session[i] = new List<item>();
        }
        return ListLoot = HttpContext.Current.Session[i] as List<item>;
    }

    public static List<Hostile> GetHostile()
    {
        if (HttpContext.Current.Session[h] == null)
        {
            // generate hostile
            List<Hostile> hostileList = new List<Hostile>();
            monster toEncounter = db.monsters.First();
            Hostile newHostile = new Hostile(toEncounter.id, rand(0, 5));

            hostileList.Add(newHostile);
            HttpContext.Current.Session[h] = hostileList;
        }
        return HttpContext.Current.Session[h] as List<Hostile>;
    }

    public static Hostile ConvertToHostile(monster monsterToConvert)
    {
        return new Hostile(monsterToConvert.id,1);
    }

    public static monster ConvertToMonster(Hostile hostileToConvert)
    {
        monster convertedHostile = db.monsters.First(m => m.id.Equals(hostileToConvert.Id));
        return convertedHostile;
    }

    public static int rand(int start, int end)
    {
        Random rd = new Random();
        return rd.Next(start, end);
    }

    //public static int levelDecider()
    //{
    //    foreach (Hostile mob in GetHostile())
    //    int iL = -1;
    //    foreach (monster currentHostile in hostileList)
    //    {
    //        iL = currentHostile.level;
    //    }
    //    return iL;
    //}

    /// <summary>
    /// Rolls the rarity of an item.
    /// If Unique rarity, rolls Unique tier.
    /// Returns rarity ID.
    /// </summary>
    /// <returns>Rarity ID</returns>
    public static int rarityDecider()
    {
        int rd = rand(0, 100);
        bool rarityChosen = false;
        int rarityId = -1;

        foreach (itemRarity ir in (from dbIr in db.itemRarities where (dbIr.id <= 4) select dbIr).OrderByDescending(o => o.id))
        {
            if (ir.value <= rd && !rarityChosen)
            {
                rarityId = ir.id;
                rarityChosen = true;
                break;
            }
        }
        if (rarityId == 4)
        {
            int uTier = rand(0, 100);

            foreach (itemRarity ir in (from dbIr in db.itemRarities where (dbIr.id > 4) select dbIr).OrderByDescending(o => o.id))
            {
                if (ir.value <= uTier)
                {
                    rarityId = ir.id;
                    break;
                }
            }
        }
        return rarityId;
    }

    public static int baseDecider()
    {
        return rand(0, db.itemBases.Count());
    }

    //public static item itemRandomizer()
    //{


    //    if (rarityDecider() > 4)
    //    {
    //        List<unique> ListUniques;
    //        foreach(unique iU in ListUniques. == rarityDecider())
    //        {

    //        }
    //    }
    //    baseDecider();
    //    if (rarityDecider() >4)
    //    {
    //        int uniqueTier = rarityDecider();
    //        int uniqueCount = uniqueTier;
    //        itemUniques uniques = (from dbIu in db.itemRarities where(dbIu.id == rand(0, uniqueCount)) select dbIu ).OrderByDescending(o => o.id);
    //    }


    //}

    public static int hostileLevel()
    {
        monster Monster = db.monsters.First(m => m.id.Equals(HttpContext.Current.Session["monster"]));
        return Monster.level;
    }

    public static int LootDrop()
    {
        decimal dropCount = (Convert.ToDecimal(rand(1, 100) * hostileLevel() / 2));
        return Convert.ToInt32(dropCount);
    }

    public static void SaveLoot(List<item> Items)
    {
        HttpContext.Current.Session[i] = Items;
    }

    public static void SaveHostiles(List<Hostile> monsters)
    {
        HttpContext.Current.Session[h] = monsters;
    }

    public static void ClearLoot()
    {
        HttpContext.Current.Session.Remove(i);
    }

    //public static void AddToLoot(int id, )
    //{
    //    ListLoot = GetLoot();
    //    bool NewDrop = true;
    //    foreach (Item item in ListLoot)
    //    {
    //        if (item.Id == id)
    //        {
    //            int NewCount = item.Count + count;
    //            UpdateLoot(id, NewCount);
    //            NewDrop = false;
    //            break;
    //        }
    //    }
    //    if (NewDrop)
    //    {
    //        ListLoot.Add(new Item(id, name, price, count));
    //    }
    //    SaveLoot(ListLoot);
    //}

    //public static void AddToHostile(int id, int count)
    //{
    //    bool NewHostile = true;
    //    foreach (monster hostile in hostileList)
    //    {
    //        if (hostile.id == id)
    //        {
    //            int NewCount = count;
    //            UpdateHostile(id, NewCount);
    //            NewHostile = false;
    //            break;
    //        }
    //    }
    //    if (NewHostile)
    //    {
    //        hostileList.Add(new Hostile(id, count));
    //    }
    //    SaveLoot(ListLoot);
    //}

    //public static void UpdateHostile(int id, int count)
    //{
    //    ListHostiles = GetHostile();
    //    foreach (Hostile hostile in ListHostiles)
    //    {
    //        if (hostile.id == id)
    //        {
    //            if (count > 0)
    //            {
    //                hostile.Count = count;
    //                break;
    //            }
    //            else
    //            {
    //                RemoveFromHostile(id);
    //                break;
    //            }
    //        }
    //    }
    //}

    //public static void RemoveFromHostile(int id)
    //{
    //    ListHostiles = GetHostile();
    //    foreach (monster hostile in ListHostiles)
    //    {
    //        if (hostile.id == id)
    //        {
    //            ListHostiles.Remove(hostile);
    //            break;
    //        }
    //    }
    //    SaveHostiles(ListHostiles);
    //}
}