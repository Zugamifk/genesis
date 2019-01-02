using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager
{
    readonly Vector3 k_DefaultCameraPosition = new Vector3(0, 0, -10);
    public Camera Main { get; private set; }

    public CameraManager()
    {
        ServiceLocator.Register(this);
        Main = NewCamera("MainCamera");   
    }

    Camera NewCamera(string name)
    {
        var go = new GameObject(name);
        go.transform.position = k_DefaultCameraPosition;
        var cam = go.AddComponent<Camera>();
        cam.backgroundColor = Color.black;
        return cam;
    }
}
