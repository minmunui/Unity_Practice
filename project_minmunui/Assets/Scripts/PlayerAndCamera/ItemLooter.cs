using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLooter : MonoBehaviour
{
    public float radius = 1.5f;
    public LayerMask lootObjectLayer;
    public LayerMask obstacleLayer;
    public List<Collider> objectsInContainer;
    private int objectCursor = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        objectsInContainer = new List<Collider>();
    }
    
    // Update is called once per frame
    void Update() {
        // Get all colliders within radius and on objectLayer
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, lootObjectLayer);

        // Check if objects are blocked by obstacles
        for (int i = 0; i < colliders.Length; i++) {
            if (IsBlocked(colliders[i].transform.position)) {
                // If object is blocked, skip it
                continue;
            }

            if (!objectsInContainer.Contains(colliders[i])) {
                // If object is not blocked, add it to container
                objectsInContainer.Add(colliders[i]);
                IncreaseCursor();
            }
        }

        // Check if objects have moved out of radius
        for (int i = 0; i < objectsInContainer.Count; i++) {
            if (Vector3.Distance(transform.position, objectsInContainer[i].transform.position) > radius) {
                objectsInContainer.RemoveAt(i);
                DecreaseCursor();
                i--;
            }
        }

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            IncreaseCursor();
        }
        
        // if lootable item exist show tooltip of it
        if (objectsInContainer.Count > 0)
        {
            ItemObject foundObject = objectsInContainer[objectCursor].gameObject.GetComponent<ItemObject>();
            ItemObject.itemObjectUI.ShowToolTip(foundObject);
        }
        else
        {
            if (!ItemObject.itemObjectUI.isMousePointing)
            {
                ItemObject.itemObjectUI.HideToolTip();
            }
        }

        Debug.Log($"{objectsInContainer.Count}");
    }
    bool IsBlocked(Vector3 targetPosition) {
        // Create a ray from the player to the target object
        Ray ray = new Ray(transform.position, targetPosition - transform.position);
        // Check if the ray hits any obstacles on the obstacleLayer
        if (Physics.Raycast(ray, out RaycastHit hit, Vector3.Distance(transform.position, targetPosition), obstacleLayer)) {
            // If the ray hits an obstacle, the target object is blocked
            return true;
        }
        return false;
    }

    void IncreaseCursor()
    {
        objectCursor++;
        if (objectCursor >= objectsInContainer.Count)
        {
            objectCursor = 0;
        }
    }

    void DecreaseCursor()
    {
        objectCursor--;
        if (objectCursor < 0)
        {
            objectCursor = objectsInContainer.Count - 1;
        }
    }
}
