using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager
{
    const string k_PrefabPath = "Prefabs/Fx/";

    public FxManager()
    {
        ServiceLocator.Register(this);
    }

    public GameObject Spawn(string name)
    {
        return GameObject.Instantiate(Resources.Load<GameObject>(k_PrefabPath + name));
    }
}
