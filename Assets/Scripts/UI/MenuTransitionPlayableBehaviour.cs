using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class MenuTransitionPlayableBehaviour : PlayableBehaviour
{
    public MenuBase Menu;
    bool paused;
    PlayableGraph graph;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if(!paused) {
            paused = true;
            graph = playable.GetGraph();
            var p = graph.GetRootPlayable(0);
            p.SetSpeed(0);
            Menu.OnTransitionOut += () => p.SetSpeed(1);
        } 
    }

    public override void OnGraphStop(Playable playable)
    {
        Menu.Destroy();
        base.OnGraphStop(playable);
    }

}
