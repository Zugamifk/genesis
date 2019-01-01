using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public abstract class MenuBase : MonoBehaviour
{
    public delegate void TransitionHandler();
    public TransitionHandler OnTransitionOut;

    public void Destroy()
    {
        ServiceLocator.Get<UIManager>().DestroyMenu(this);
    }
}
