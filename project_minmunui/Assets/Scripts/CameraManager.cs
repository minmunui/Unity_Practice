using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraManager : MonoBehaviour
{
    
    public enum CameraAngle
    {
        Twelve,
        Twelve_Three,
        Three,
        Three_Six,
        Six,
        Six_Nine,
        Nine,
        Nine_Twelve
    }

    public class AxisDirection
    {
        public Vector3 horizon;
        public Vector3 vertical;
        public float angle;

        public AxisDirection(Vector3 horizon, Vector3 vertical, float angle)
        {
            this.horizon = horizon;
            this.vertical = vertical;
            this.angle = angle;
        }
    }


    public static Dictionary<CameraAngle, AxisDirection> directionMap = new Dictionary<CameraAngle, AxisDirection>()
    {
        { CameraAngle.Twelve, new AxisDirection(new Vector3(-1.0f, 0, 0), new Vector3(0, 0, -1.0f), 0.0f) },
        { CameraAngle.Twelve_Three, new AxisDirection(new Vector3(-1.0f, 0, 1.0f).normalized, new Vector3(-1.0f, 0, -1.0f).normalized, 45.0f) },
        { CameraAngle.Three, new AxisDirection(new Vector3(0, 0, 1.0f), new Vector3(-1.0f, 0, 0), 90.0f) },
        { CameraAngle.Three_Six, new AxisDirection(new Vector3(1.0f, 0, 1.0f).normalized, new Vector3(-1.0f, 0, 1.0f).normalized, 135.0f) },
        { CameraAngle.Six, new AxisDirection(new Vector3(1.0f, 0, 0), new Vector3(0, 0, 1.0f), 180.0f) },
        { CameraAngle.Six_Nine, new AxisDirection(new Vector3(1.0f, 0, -1.0f).normalized, new Vector3(1.0f, 0, 1.0f).normalized, 225.0f) },
        { CameraAngle.Nine, new AxisDirection(new Vector3(0, 0, -1.0f), new Vector3(1.0f, 0, 0), 270.0f) },
        { CameraAngle.Nine_Twelve, new AxisDirection(new Vector3(-1.0f, 0, -1.0f).normalized, new Vector3(1.0f, 0, -1.0f).normalized, 315.0f) }
    };

    public static CameraManager instance;

    public static CameraAngle cameraAngle = CameraAngle.Twelve_Three;

    public static void cameraClockwise()
    {
        if (cameraAngle != CameraAngle.Nine_Twelve) cameraAngle += 1;
        else cameraAngle = CameraAngle.Twelve;
    }

    public static void cameraAntiClockwise()
    {
        if (cameraAngle != CameraAngle.Twelve) cameraAngle -= 1;
        else cameraAngle = CameraAngle.Nine_Twelve;
    }
    void Start()
    {
    }
    
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
    }
}