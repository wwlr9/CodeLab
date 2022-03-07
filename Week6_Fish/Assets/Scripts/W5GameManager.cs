using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W5GameManager : MonoBehaviour
{
    private GameObject Cam;

    //public GameObject myCanvas;

    //create game manager singleton
    private static W5GameManager instance;
    public static W5GameManager FindInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance !=null && instance != this)
        {
            Destroy(this);
        }
        else if(instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    //all potential game states
    public enum State
    {
        intro,
        cambrian,
        silurian,
        devonian,
        land,
        end
    }

    //track current game state
    public State currentState;

    // Start is called before the first frame update
    void Start()
    {
        //refer to camera
        Cam = GameObject.Find("Main Camera");
        
        //Debug.Log("Hi game manager");

        TransitionStates(State.intro);//game starts with the intro part state
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeBackColor(float colorR, float colorG, float colorB)
    {
        Cam.GetComponent<Camera>().backgroundColor = new Color(colorR / 255f, colorG / 255f, colorB / 255f, 0f);
    }

    public void TransitionStates(State newState)
    {
        
        currentState = newState;
        //check what the new state is
        switch (newState)
        {
            case State.intro:
                //what happens in this state
                changeBackColor(0, 26, 51);
                break;

            case State.cambrian:
                changeBackColor(0, 50, 110);
                break;

            case State.silurian:
                changeBackColor(0, 70, 130);
                break;

            case State.devonian:
                changeBackColor(0, 90, 180);
                break;

            case State.land:
                changeBackColor(210, 272, 171);
                break;

            case State.end:
                changeBackColor(0, 0, 0);
                break;

            default:
                Debug.Log("this state does not exist");
                break;
        }
    }
}
