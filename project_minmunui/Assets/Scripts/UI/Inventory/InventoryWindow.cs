using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    public GameObject window;
    private RectTransform rectTransform;
    
    [SerializeField] private TextMeshProUGUI BagName;
    [SerializeField] private GameObject ItemGridPenal;
    [SerializeField] private GameObject itemSlot;

    private ItemGrid itemGrid;

    public static float Padding = 5f;
    public static float SlotSize = 50f;
    public static float SlotSpacing = 5f;
    public static float TitleHeight = 40f;
    public static int MaxVerticalSlotDisplay = 12;

    private float WindowWidth;
    private float WindowHeight;

    private float GridCanvasWidth;
    private float GridCanvasHeight;


    
    public void ActiveWindow(bool active)
    {
        if (active)
        {
            window.SetActive(true);
        }
        else
        {
            window.SetActive(false);
        }
    }

    public void SetItemGrid(int cols, int rows)
    {

        WindowWidth = Padding * 2 + cols * SlotSize + (cols - 1) * SlotSpacing;
        WindowHeight = Padding * 2 + rows * SlotSize + (rows - 1) * SlotSpacing + TitleHeight;
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, WindowHeight);
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, WindowWidth);

        GridCanvasWidth = SlotSize * cols + SlotSpacing * (cols - 1);
        
        if (rows > MaxVerticalSlotDisplay)
        {
            GridCanvasHeight = SlotSize * MaxVerticalSlotDisplay + (MaxVerticalSlotDisplay - 1) + SlotSpacing;
        }
        else
        {
            GridCanvasHeight = SlotSize * rows + (rows - 1) * SlotSpacing;
        }
        
        RectTransform ItemGridPenalRect = ItemGridPenal.GetComponent<RectTransform>();
            
        ItemGridPenalRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, GridCanvasHeight);
        ItemGridPenalRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, GridCanvasWidth);
        ItemGridPenalRect.anchoredPosition = new Vector3(0, -TitleHeight);

        itemGrid = GetComponent<ItemGrid>();
        for (int i = 0; i < cols * rows; i++)
        {
            GameObject slot = Instantiate(itemSlot);
            slot.transform.SetParent(ItemGridPenal.transform, false);
            slot.SetActive(true);
        }
    }

    public void SetTitle(string title)
    {
        BagName.text = title;
    }
    

    public void DisplayBag(ItemBag itemBag)
    {
        
    }

    public void DisplayItem(Item item)
    {
        
    }
    
    public 

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    
    void Update()
    {

    }
}