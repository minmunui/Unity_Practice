using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void DropItem(ItemPile item, Vector3 dropPosition)
    {
        // Instantiate the item at the drop position
        ItemPile droppedItem = Instantiate(item, dropPosition, Quaternion.identity);
        
        // Add an upward force to the dropped item
        Rigidbody droppedItemRigidbody = droppedItem.GetComponent<Rigidbody>();
        droppedItemRigidbody.AddForce(Vector3.up * 5f + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), ForceMode.Impulse);
    }
}
