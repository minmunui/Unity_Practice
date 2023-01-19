using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Item : IComparable<Item>
{
    public string name;
    public int ID;
    public int stackMaximum;
    public string description;
    public Sprite sprite;
    
    public static Item Empty = new Item("Empty", 0);
    public Item(string name, int ID)
    {
        this.name = name;
        this.ID = ID;
    }
    
    public Item()
    {
        this.name = "Empty";
        this.ID = 0;
    }
    

    public int CompareTo(Item other)
    {
        if (this.ID > other.ID) return 1;
        if (this.ID == other.ID) return 0;
        return -1;
    }
    
    public override string ToString()
    {
        return $"{name}[{ID}]";
    }

    public override int GetHashCode()
    {
        return ID;
    }

    public static Item[] ItemList =
    {
        new Item("TestItem", 0)
    };
}