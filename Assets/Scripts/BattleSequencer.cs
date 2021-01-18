using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class BattleSequencer : MonoBehaviour
{
    private PlayableDirector director;
    public TimelineAsset MainLine;


    // Start is called before the first frame update
    void Awake()
    {
        director = GetComponent<PlayableDirector>();



    }

   

}
