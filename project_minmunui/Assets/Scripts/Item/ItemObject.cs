using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
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
        itemObjectUI = FindObjectOfType<ItemObjectUI>();
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

    public int GetAmount()
    {
        return this.ItemPile.amount;
    }

    public void SetAmount(int amount)
    {
        this.ItemPile.amount = amount;
    }

    public void SetID(int ID)
    {
        this.ItemPile.item = Item.ItemList[ID];
    }

    public int GetID()
    {
        return ItemPile.item.ID;
    }
    
    private void OnMouseOver()
    {
        itemObjectUI.gameObject.SetActive(true);
        itemObjectUI.SetItemObjectUI(ItemPile);
        Vector2 cursorPos = Input.mousePosition;
        itemObjectUI.transform.position = cursorPos;
    }

    private void OnMouseExit()
    {
        itemObjectUI.gameObject.SetActive(false);
    }
    
    void Update()
    {
        
    }




}
