using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputController
{
    class MouseWatcher : MonoBehaviour
    {
        MouseInputController m_Controller;
        public void SetController(MouseInputController mic)
        {
            m_Controller = mic;
        }
        void Update()
        {
            m_Controller.CheckInput();
        }
    }

    Camera m_Camera;

    public MouseInputController()
    {
        ServiceLocator.Register(this);
        m_Camera = ServiceLocator.Get<CameraManager>().Main;

        var go = new GameObject(typeof(MouseWatcher).Name);
        var mw = go.AddComponent<MouseWatcher>();
        mw.SetController(this);
    }

    void CheckInput()
    {
        Debug.Log(Input.mousePosition);
    }
}
