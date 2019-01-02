using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Launch
{
    [RuntimeInitializeOnLoadMethod]
    static void LaunchGame()
    {
#if UNITY_EDITOR
        var scene = SceneManager.GetActiveScene();
        if (scene != null)
        {
            var gameScene = SceneManager.CreateScene("Game");
            SceneManager.UnloadSceneAsync(scene);
            SceneManager.SetActiveScene(gameScene);
        }
#endif

        var ui = ServiceLocator.Get<UIManager>();
        ui.Initialize();
        ui.GoToMenu<MainMenu>();
    }
}
