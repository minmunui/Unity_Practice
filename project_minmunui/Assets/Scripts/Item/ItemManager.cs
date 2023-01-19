
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.IO;
using System.Linq;
using UnityEditor.MemoryProfiler;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public static List<Item> ItemList;
    public TextAsset csvFile;
    private char lineSeperater = '\n';
    private char fieldSeperater = ',';

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        string[][] temp = LoadCSV(csvFile);
        int itemCount = int.Parse(temp[0][4]);
        ItemList = new List<Item>(itemCount);
        Debug.Log($"{ItemList.Capacity}");
        for (int i = 1; i <= itemCount; i++)
        {
            // string logString = "";
            // foreach (var value in temp[i])
            // {
            //     logString += $"{value}, ";
            // }
            // Debug.Log(logString);
            Item item = new Item();
            
            // Debug.Log($"{temp[i][0]}");
            item.ID = int.Parse(temp[i][0]);
            item.name = temp[i][1];
            item.description = temp[i][2];
            item.stackMaximum = int.Parse(temp[i][3]);
            item.sprite = Resources.Load<Sprite>("Sprite/" + item.name);
            Debug.Log($"{item}");
            ItemList.Add(item);
        }
    }

    void Update()
    {
        
    }

    public string[][] LoadCSV(TextAsset csv)
    {
        string[] lines = csv.text.Split(lineSeperater);
        string[][] result = new string[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
        {
            result[i] = lines[i].Split(fieldSeperater);
        }

        string testString = "";
        foreach (var line in result)
        {
            foreach (var field in line)
            {
                testString += $"{field}, ";
            }
            testString += "\n";
        }
        Debug.Log(testString);
        return result;
    }
    
    public void DropItem(ItemPile item, Vector3 dropPosition)
    {
        // Instantiate the item at the drop position
        GameObject droppedItem = Instantiate(item.itemObject, dropPosition, Quaternion.identity);
        
        // Add an upward force to the dropped item
        Rigidbody droppedItemRigidbody = droppedItem.GetComponent<Rigidbody>();
        droppedItemRigidbody.AddForce(Vector3.up * 5f + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)), ForceMode.Impulse);
    }
}
