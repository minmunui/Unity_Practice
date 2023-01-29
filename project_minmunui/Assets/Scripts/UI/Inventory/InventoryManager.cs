using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Start is called before the first frame update

    public  InventoryWindow inventoryWindow;
    void Start()
    {
        inventoryWindow.SetItemGrid(5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Show the window
            inventoryWindow.ActiveWindow(true);
            Debug.Log("Inventory Open");

            // Update the text
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Hide the window
            inventoryWindow.ActiveWindow(false);
        }
    }
}
