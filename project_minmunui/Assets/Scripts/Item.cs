using UnityEngine;

public class Item
{
    public string name;
    public int ID;
    public Sprite sprite;
    public int stackMaximum;
    
    public Item(string name, int ID)
    {
        this.name = name;
        this.ID = ID;
        sprite = Resources.Load<Sprite>("Sprite/" + name);
    }

    public void InsertTo(ItemBag bag)
    {
        
    }

    public static void InsertTo(int ID, int amount, ItemBag bag)
    {
        
    }
}
