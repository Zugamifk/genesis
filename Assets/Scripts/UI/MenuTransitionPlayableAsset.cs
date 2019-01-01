using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class MenuTransitionPlayableAsset : PlayableAsset
{
    public override double duration => 1;

    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var p = ScriptPlayable<MenuTransitionPlayableBehaviour>.Create(graph);
        var b = p.GetBehaviour();
        b.Menu = go.GetComponent<MenuBase>();
        return p;
    }
}
