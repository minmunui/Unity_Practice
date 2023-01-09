
using OpenCover.Framework.Model;
using UnityEngine;

public class ItemPile
{
    public int amount;
    public Item item;

    public ItemPile()
    {
        this.item = item;
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
    /// <param name="amount"></param>
    /// <returns>the amount of items remaining after filling the stack if ItemPile overflow</returns>
    public int AddAmount(int amount)
    {
        if (this.amount + amount > this.item.stackMaximum)
        {
            this.amount = this.item.stackMaximum;
            return amount + this.amount - this.item.stackMaximum;
        }
        this.amount += amount;
        return 0;
    }
    
    
}
