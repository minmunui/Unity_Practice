using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
[Serializable]
public class ItemObject : MonoBehaviour
{
    public ItemPile ItemPile;
    public static ItemObjectUI itemObjectUI;
    public int ID;
    public int amount;

    // Update is called once per frame

    public void Start()
    {
        ItemPile = new ItemPile(ID, amount);
        gameObject.layer = LayerMask.NameToLayer("ItemObject");
        if (itemObjectUI == null)
        {
            itemObjectUI = FindObjectOfType<ItemObjectUI>();
        }
        if (itemObjectUI.gameObject.activeSelf)
        {
            itemObjectUI.gameObject.SetActive(false);
        }
    }

    public void Set(int ID, int amount)
    {
        this.ItemPile.amount = amount;
        this.ItemPile.item = Item.ItemList[ID];
        this.ItemPile.item.ID = ID;
    }
    private void OnMouseOver()
    {
        itemObjectUI.ShowToolTipWithCursor(this);
    }

    private void OnMouseExit()
    {
        itemObjectUI.HideToolTip();
    }
    
    void Update()
    {
        
    }




}
