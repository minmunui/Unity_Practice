using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BagUI : MonoBehaviour
{
    public GameObject itemPrefab; // prefab for the item UI element
    public Transform content; // parent transform for the item UI elements
    public List<Item> bagItems; // list of items in the bag
    
    void Start()
    {
        // Instantiate an item UI element for each item in the bag
        foreach (Item item in bagItems)
        {
            GameObject newItem = Instantiate(itemPrefab, content);
            newItem.GetComponentInChildren<Text>().text = item.name;
        }
    }
}