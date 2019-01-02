using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MenuBase
{
    GameObject m_Stars;

    private void Awake()
    {
        m_Stars = ServiceLocator.Get<FxManager>().Spawn("Stars");
    }

    private void OnDestroy()
    {
        if (m_Stars != null)
        {
            Destroy(m_Stars);
        }
    }

    public void Button_New()
    {
        OnTransitionOut?.Invoke();
        ServiceLocator.Get<MapController>().Initialize();
    }
}
