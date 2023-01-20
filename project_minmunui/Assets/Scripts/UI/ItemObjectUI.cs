using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemObjectUI : MonoBehaviour
{ 
    public TextMeshProUGUI textMeshPro;
    public bool isMousePointing;
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
        gameObject.SetActive(true);
    }

    public void ShowToolTip(ItemObject itemObject)
    {
        if (isMousePointing == false)
        {
            SetItemObjectUI(itemObject.ItemPile);
            Vector3 screenPos = Camera.main.WorldToScreenPoint(itemObject.gameObject.transform.position);
            transform.position = screenPos;
        }
    }

    public void ShowToolTipWithCursor(ItemObject itemObject)
    {
        isMousePointing = true;
        SetItemObjectUI(itemObject.ItemPile);
        Vector2 cursorPos = Input.mousePosition;
        transform.position = cursorPos;
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
        isMousePointing = false;
    }
}
