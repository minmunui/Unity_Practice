using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemObjectUI : MonoBehaviour
{ 
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItemObjectUI(ItemPile itemPile)
    {
        textMeshPro.text = $"{itemPile.item.name} * {itemPile.amount}";
    }
}
