using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController
{
    const string k_PrefabFolder = "Prefabs/Tiles/";
    
    MapViewController m_MapViewController;
    Map m_Map;

    public MapController()
    {
        ServiceLocator.Register(this);
    }

    public void Initialize()
    {
        m_MapViewController = GameObject.Instantiate(Resources.Load<MapViewController>(k_PrefabFolder + "Grid"));

        ServiceLocator.Get<MouseInputController>();
    }
}
