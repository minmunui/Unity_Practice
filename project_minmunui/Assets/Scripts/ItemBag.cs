using System.Collections.Generic;
using UnityEngine;

public class ItemBag
{
    private int capacity;
    // The current number of items in the bag
    private int count;
    private List<ItemPile> itemPiles;

    public static ItemPile Empty = new ItemPile(Item.Empty, 0);
    
    // Constructor to initialize the item bag with a given capacity
    public ItemBag(int capacity)
    {
        this.capacity = capacity;
        this.count = 0;
        this.itemPiles = new List<ItemPile>(capacity);
    }

    // Method to add an item to the bag
    public ItemPile AddItem(Item item, int amount)
    {
        int remainToAdd = amount;
        foreach (var itemPile in itemPiles)
        {
            if (itemPile.item.ID == item.ID)
            {
                remainToAdd = itemPile.AddAmount(amount);
            }
            if (remainToAdd == 0)
            {
                return Empty;
            }
        }

        if (capacity > amount)
        {
            itemPiles.Add(new ItemPile(item, 0));
            this.AddItem(item, remainToAdd);
        }
        
        Debug.Log($"Bag is overflow! / {item}*{remainToAdd}");
        return new ItemPile(item, remainToAdd);
        // if make new itemPile
    }

    public ItemPile AddItem(ItemPile itemPileToAdd)
    {
        return AddItem(new ItemPile(itemPileToAdd.item, itemPileToAdd.amount));
    }
    
    

    // Method to remove an item from the bag
    public void RemoveItem(Item item, int amount)
    {
        foreach (var itemPile in itemPiles)
        {
            if (itemPile.item == item)
            {
                itemPile.amount -= amount;
                if (itemPile.amount == 0)
                {
                    return;
                }
                if (itemPile.amount < 0)
                {
                    amount = -itemPile.amount;
                    itemPiles.Remove(itemPile);
                }
            }
        }
        if (amount > 0)
        {
            Debug.Log($"Bag is underflow! / {item}*{amount}");
        }
    }
    
    // Method to check if the bag is full
    public bool IsFull()
    {
        return count == capacity;
    }

    // Method to get the number of items in the bag
    public int GetCount()
    {
        return count;
    }

    // Method to get the list of items in the bag
    public List<ItemPile> GetItems()
    {
        return itemPiles;
    }
}