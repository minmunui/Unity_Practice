using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // refer https://www.youtube.com/watch?v=bAfCxYH0TG0&ab_channel=%EC%BC%80%EC%9D%B4%EB%94%94
    public ItemPile itemPile;
    

    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI textAmount;

    [SerializeField] private Image itemImage;
    // [SerializeField] private GameObject amountSlot;

    public void Start()
    {
        SetItem(ItemPile.emptyPile);
    }
    
    public void SetItem(ItemPile itemPile) 
    {
        SetItem(itemPile.item, itemPile.amount);
    }

    public void SetItem(Item item, int amount = 1)
    {
        itemPile = new ItemPile(item, amount);
        itemImage.sprite = itemPile.item.sprite;
        // amountSlot.gameObject.SetActive(true);
        textAmount.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        itemPile = ItemPile.emptyPile;
        textAmount.gameObject.SetActive(false);
        // amountSlot.gameObject.SetActive(false);
    }

    public void AddAmount(int amount)
    {
        itemPile.AddAmount(amount);
        if (itemPile.amount == 0)
        {
            ClearSlot();
        }
        else
        {
            UpdateSlot();
        }
    }

    public void UpdateSlot()
    {
        textAmount.text = itemPile.amount.ToString();
    }
}
