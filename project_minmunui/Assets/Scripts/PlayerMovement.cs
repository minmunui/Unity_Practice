using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15.0f;
    public Rigidbody playerRigidbody;
    private const float Diagonal_Normalize_Coef = 1.0f / 1.41f;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = (horizontal * CameraManager.directionMap[CameraManager.cameraAngle].horizon +
                             vertical * CameraManager.directionMap[CameraManager.cameraAngle].vertical);

        if (direction.magnitude > 1.0f)
        {
            direction *= Diagonal_Normalize_Coef;
        }
        

        // Vector3 direction = new Vector3(horizontal * speed, 0, vertical * speed);
        // Debug.Log(direction);
        
        transform.position = transform.position + direction * speed * Time.deltaTime; 
    }
}