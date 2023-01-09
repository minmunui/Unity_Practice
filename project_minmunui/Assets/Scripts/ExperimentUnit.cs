using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentUnit : MonoBehaviour
{
    // Start is called before the first frame update
    public float height = 30.0f;
    public float distance = 10.0f;
    public float angle = 45.0f;
    public float zoomSensitivity = 10.0f;
    public float minDistance = 5.0f;
    public float maxDistance = 20.0f;
    public float smoothTime = 10.0f;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = this.transform.position + Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward * distance + Vector3.up * height;
    }
}
