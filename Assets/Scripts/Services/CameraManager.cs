using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager
{
    public Camera Main { get; private set; }

    public CameraManager()
    {
        ServiceLocator.Register(this);
        Main = NewCamera("MainCamera");   
    }

    Camera NewCamera(string name)
    {
        var go = new GameObject(name);
        var cam = go.AddComponent<Camera>();
        cam.backgroundColor = Color.black;
        return cam;
    }
}
