using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TestItem : ItemObject
{
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        this.ItemPile = new ItemPile(0, amount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
