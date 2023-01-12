using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
public class ItemBag
{
    private int capacity;
    // The current number of items in the bag
    private int ID;
    private static int IDCount = 1;
    private int count;
    private List<ItemPile> itemPiles;

    public static ItemPile Empty = new ItemPile(Item.Empty, 0);
    
    // Constructor to initialize the item bag with a given capacity
    public ItemBag(int capacity)
    {
        this.capacity = capacity;
        this.count = 0;
        this.ID = IDCount;
        IDCount++;
        this.itemPiles = new List<ItemPile>(capacity);
    }

    // Method to add an item to the bag
    public ItemPile AddItem(Item item, int amount)
    {
        Debug.Log($"Add {item}*{amount} to {this}");
        
        int remainToAdd = amount;
        foreach (var itemPile in itemPiles)
        {
            if (itemPile.item.ID == item.ID && itemPile.amount < itemPile.item.stackMaximum) 
            {
                remainToAdd = itemPile.AddAmount(amount);
            }
            if (remainToAdd == 0)
            {
                return Empty;
            }
        }

        if (capacity > count && remainToAdd > 0)
        {
            itemPiles.Add(new ItemPile(item, 0));
            this.count++;
            return AddItem(item, remainToAdd);
        }
        
        Debug.Log($"Bag is overflow! / {item}*{remainToAdd}");
        return new ItemPile(item, remainToAdd);
        // if make new itemPile
    }

    public ItemPile AddItem(ItemPile itemPileToAdd)
    {
        ItemPile newItemPile = new ItemPile(itemPileToAdd.item, itemPileToAdd.amount);
        return AddItem(newItemPile.item, newItemPile.amount);
    }
    
    

    // Method to remove an item from the bag
    public void RemoveItem(Item item, int amount)
    {
        for (int i = 0; i < itemPiles.Count; i++)
        {
            if (itemPiles[i].item == item)
            {
                itemPiles[i].amount -= amount;
                if (itemPiles[i].amount > 0)
                {
                    return;
                }

                if (itemPiles[i].amount < 0)
                {
                    amount = (-1)*itemPiles[i].amount;
                    Debug.Log($"Additional Remove Required {item}*{amount} from {this}");
                    itemPiles.Remove(itemPiles[i]); // In foreach, element remove is not allowed TODO
                    Debug.Log($"After Remove\n{this}");
                    this.count--;
                    this.RemoveItem(item, amount);
                    return;
                }

                if (itemPiles[i].amount == 0)
                {
                    itemPiles.Remove(itemPiles[i]);
                    this.count--;
                    return;
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

    public override string ToString()
    {
        string result = $"capacity : {capacity}, ID : {ID}\n<Contain>\n";
        foreach (var itemPile in this.itemPiles)
        {
            result+= itemPile + "\n";
        }

        result += "</Contain>";
        return result;
    }
}