using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Products
/// </summary>
[Serializable]
public class Hostile
{
    public Hostile(int id, int count)
    {
        this.Id = id;
        this.Count = count;
    }

    public int Id { get; set; }
    public int Count { get; set; }
}