using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    public GameObject window;

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

    void Start()
    {
    }
    
    void Update()
    {

    }
}