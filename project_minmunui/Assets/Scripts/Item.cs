using System;
using System.Collections.Generic;
using UnityEngine;

public class Item : IComparable<Item>
{
    public string name;
    public int ID;
    public Sprite sprite;
    public int stackMaximum;

    public static Item Empty = new Item("Empty", 0);
    public Item(string name, int ID)
    {
        this.name = name;
        this.ID = ID;
        sprite = Resources.Load<Sprite>("Sprite/" + name);
    }

    public int CompareTo(Item other)
    {
        if (this.ID > other.ID) return 1;
        if (this.ID == other.ID) return 0;
        return -1;
    }

    public void InsertTo(ItemBag bag)
    {
        bag.AddItem(this, 1);
    }

    public override string ToString()
    {
        return $"{{name}} * ({ID})";
    }

    public override int GetHashCode()
    {
        return ID;
    }

    
    
}
