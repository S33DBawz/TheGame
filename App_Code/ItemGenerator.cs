using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemGenerator
/// </summary>
public class ItemGenerator
{
  /*  static DataClassesDataContext db = new DataClassesDataContext();

    //CORE FUNCTIONALITY AND HELPERS

    //Randomizer. Takes start+end parameters
    public static int rand(int start, int end)
    {
        Random rd = new Random();
        return rd.Next(start, end);
    }

    //Randomizer 1-100
    public static int rand()
    {
        Random rd = new Random();
        return rd.Next(0, 100);
    }

    public static int iir()
    {
        //skal returnere bonuser fra equipment på et senere tidspunkt
        return Chars.CurrentChar.Level;
    }

    //Rolls item count [CONSTRUCTOR]
    public static int ItemQuantity()
    {
        int count = (int)rand(0, 100) / 100 * iir();

        return count;
    }

    //Sets item count
    public static int ItemQuantity(int count)
    {
        return count;
    }

    public static int levelDecider()
    {
        if (Looting.hostileLevel() < 1)
        {

        }
        return Looting.hostileLevel();
    }

    /// <summary>
    /// Rolls the rarity of an item.
    /// If Unique rarity, rolls Unique tier.
    /// Returns rarity ID.
    /// </summary>
    /// <returns>Rarity ID</returns>
    public static int rarityDecider()
    {
        int rd = ItemGenerator.rand(0, 100);
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
            int uTier = ItemGenerator.rand(0, 100);

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
        return ItemGenerator.rand(0, db.itemBases.Count());
    }*/
}