using System.Collections.Generic;
using UnityEngine;

public class ItemBag
{
    // The maximum number of items that can be held in the bag
    private int capacity;

    // The current number of items in the bag
    private int count;

    // A list to hold the items in the bag
    private List<ItemPile> itemPiles;

    // Constructor to initialize the item bag with a given capacity
    public ItemBag(int capacity)
    {
        this.capacity = capacity;
        this.count = 0;
        this.itemPiles = new List<ItemPile>(capacity);
    }

    // Method to add an item to the bag
    public void AddItem(Item item)
    {
        if (count < capacity)
        {
            itemPile.Add(item);
            count++;
        }
        else
        {
            Debug.Log("Item bag is full!");
        }
    }

    // Method to remove an item from the bag
    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            count--;
        }
        else
        {
            Debug.Log("Item not found in bag!");
        }
    }

    public bool isInsertable(Item item, int amount)
    {
        
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
    public List<Item> GetItems()
    {
        return items;
    }
}