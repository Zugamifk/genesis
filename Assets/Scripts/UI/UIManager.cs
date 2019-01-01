using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager
{
    const string k_PrefabFolder = "Prefabs/UI/";

    Canvas m_Canvas;
    Dictionary<object, MenuBase> m_Prefabs = new Dictionary<object, MenuBase>();
    MenuBase m_CurrentMenu;

    public UIManager()
    {
        ServiceLocator.Register(this);
    }

    public void Initialize()
    {
        var go = new GameObject("Canvas");
        GameObject.DontDestroyOnLoad(go);

        m_Canvas = GameObject.Instantiate(Resources.Load<Canvas>(k_PrefabFolder + "Canvas"));

        var camera = ServiceLocator.Get<CameraManager>().Main;
        m_Canvas.worldCamera = camera;
    }

    public void GoToMenu<T>() where T : MenuBase
    {
        var menu = GameObject.Instantiate(GetMenu<T>());
        menu.transform.SetParent(m_Canvas.transform);
        var rtf = menu.GetComponent<RectTransform>();
        rtf.sizeDelta = Vector3.zero;
        rtf.anchorMin = Vector3.zero;
        rtf.anchorMax = Vector3.one;
        rtf.localPosition = Vector3.zero;
        rtf.localScale = Vector3.one;
        m_CurrentMenu = menu;
    }

    public void DestroyMenu(MenuBase menu)
    {
        GameObject.Destroy(menu.gameObject);
    }

    T GetMenu<T>() where T : MenuBase
    {
        MenuBase menu;
        if(!m_Prefabs.TryGetValue(typeof(T), out menu))
        {
            menu = LoadPrefab<T>();
        }
        return (T)menu;
    }

    T LoadPrefab<T>() where T : MenuBase
    {
        var name = typeof(T).Name;
        var menu = Resources.Load<T>(k_PrefabFolder + name);
        m_Prefabs[typeof(T)] = menu;
        return menu;
    }
}
