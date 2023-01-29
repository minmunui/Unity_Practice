using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemPile : IComparable<ItemPile>
{
    public int amount;
    public Item item;
    public GameObject itemObject;
    
    public static ItemPile emptyPile= new ItemPile(0, 1);

    public ItemPile()
    {
        item = Item.empty;
        amount = 0;
    }
    
    public ItemPile(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public ItemPile(int ID, int amount)
    {
        this.item = ItemManager.ItemList[ID];
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

        if (this.amount - amount < 0)
        {
            int remain = this.amount - amount;
            this.amount = 0;
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
    public void LootItem(ItemBag itemBag, Transform bagTransform)
    {
        ItemPile remains = itemBag.AddItem(this);
        if (remains.amount > 0)
        {
            ItemPile remainItemObject = new ItemPile(remains.item, remains.amount);
            ItemManager.instance.DropItem(remainItemObject, bagTransform.position);
            Debug.Log($"Loot Item {this} to {itemBag}");
        }
        
    }
}