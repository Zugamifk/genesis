using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MenuBase
{
    public void Button_New()
    {
        OnTransitionOut?.Invoke();
    }
}
