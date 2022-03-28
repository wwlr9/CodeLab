using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    MyGameManager myManager;

    //3 kinds of external environment
    public enum State
    {
        Original,
        HandleableStimulus,
        StressStimulus
    }

    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        myManager = MyGameManager.FindInstance();

        TransitionState(State.Original); //start with the origical environment
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TransitionState(State newState)
    {
        currentState = newState;
        switch (newState)
        {
            case State.HandleableStimulus:
                //
                break;
            case State.StressStimulus:
                //
                break;
            default:
                Debug.Log("no transition");
                break;

        }




    }
}
