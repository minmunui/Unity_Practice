using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UsableItem : Item
{
    public void Use()
    {
        Debug.Log($"Use {this}");
    }
}
