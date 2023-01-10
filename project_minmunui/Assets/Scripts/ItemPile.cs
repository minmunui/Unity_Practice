using System;
using System.Collections.Generic;

public class ItemPile : IComparable<ItemPile>
{
    public int amount;
    public Item item;
    public static Item testItem = new Item("testItem", 0);
    
    public ItemPile()
    {
        this.item = Item.Empty;
        this.amount = 0;
    }

    public ItemPile(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="amount">amount of item to add to pile</param>
    /// <returns>the amount of items remaining after filling the stack if ItemPile overflow</returns>
    public int AddAmount(int amount)
    {
        if (this.amount + amount > this.item.stackMaximum)
        {
            int remain = amount + this.amount - item.stackMaximum;
            this.amount = this.item.stackMaximum;
            return remain;
        }
        this.amount += amount;
        return 0;
    }

    public override string ToString()
    {
        return $"{item}*{amount}";
    }

    public int CompareTo(ItemPile other)
    {
        if (this.item == other.item)
        {
            return this.amount.CompareTo(other);
        }
        return this.item.CompareTo(other.item);
    }
}