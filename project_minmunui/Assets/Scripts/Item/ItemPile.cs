using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemPile : MonoBehaviour, IComparable<ItemPile>
{
    public Rigidbody itemRigidbody;
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
    
    
    void Start()
    {
        itemRigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnDestroy()
    {
        Debug.Log($"{this} is destroyed at {transform.position}");
    }
    
    public void LootItem(ItemBag itemBag)
    {
        ItemPile remains = itemBag.AddItem(this);
        if (remains.amount > 0)
        {
            ItemPile remainItemObject = new ItemPile(remains.item, remains.amount);
            Instantiate()
            ItemManager.instance.DropItem(remainItemObject, transform.position);
            Debug.Log($"Loot Item {this} to {itemBag}");
        }
        
    }
}