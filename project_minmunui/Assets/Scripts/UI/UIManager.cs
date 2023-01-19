// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
//
// public class UIManager : MonoBehaviour
// {
//     public static UIManager instance; 
//     public TextMeshPro itemObjectText;
//     // Start is called before the first frame update
//     void Start()
//     {
//         itemObjectText = GameObject.FindObjectOfType<TextMeshPro>();
//     }
//     
//     private void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
// }
