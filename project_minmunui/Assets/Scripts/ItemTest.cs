using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    public Item testitem;
    public ItemPile testItemPile;
    private ItemBag testItemBag;
    // Start is called before the first frame update
    void Start()
    {
        testitem = new Item("Test Item", 1);
        testItemPile = new ItemPile(testitem, 10);
        testItemBag = new ItemBag(10);
        testitem.stackMaximum = 64;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(testItemBag.AddItem(testItemPile));
            Debug.Log($"Bag : {this.testItemBag}\n");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            testItemBag.RemoveItem(this.testitem, 6);
            Debug.Log($"Bag : {this.testItemBag}\n");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log($"Bag : {this.testItemBag}");
        }
    }
}
