using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Launch
{
    [RuntimeInitializeOnLoadMethod]
    static void LaunchGame()
    {
        var ui = new UIManager();
        ui.Initialize();
        ui.GoToMenu<MainMenu>();
    }
}
