using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    #region Interaction for assigning the external environment
    public int click = 0;//possible: use kinect sensor to track number of people. People's bodies release heat.
    #endregion

    #region Time
    public int myTime = 0;
    private float timer = 0f;
    public float inputT;//the time at which users change the external environment from original to HandleableStimulus or StressStimulus
    private float GeffectT;//handleable stimulus staying time
    private float workingT;//GlandA/B works for this amount of time to handle stimulus
    public float Gworking;//the time at which external stimulus disappears
    private float TdeltaA3;//the amount of time glandA works at the rate=deltaA3

    private float SeffectT;//chronic stress stimulus staying time
    private float TdeltaAmax;//In StressStimulus situation:deltaAmax could only work for this amount of time. When glandA secrets deltaAmax>this amount of time, deltaA=deltaA0.

    public List<float> TIV1 = new List<float>();//list to store the times at which IV from (1st threshold,1st threshold+0.5f)
    public List<float> TIV2 = new List<float>();//list to store the times at which IV from (2nd threshold,2nd threshold+0.5f)
    private List<float> TIV3 = new List<float>();//list to store the times at which IV from (3rd threshold,3rd threshold+0.5f)
    private List<float> TIV4 = new List<float>();//list to store the times at which IV from (4th threshold,4th threshold+0.5f)

    public float IV1t;//the times at which internal value exceeds the first IV threshold and then glandA/B sense it to work harder(deltaA1)
    public float IV2t;//the times at which internal value exceeds the second IV threshold and then glandA/B sense it to work harderr(deltaA2)
    private float IV3t;//the times at which internal value exceeds the third IV threshold and then glandA/B sense it to work harderrr(deltaA3)
    private float IV4t;//the times at which internal value exceeds the fourth IV threshold and then glandA/B sense it to work harderrrr(deltaAmax)
    private float IV3T;//TIV3[0]
    private float IV4T;//TIV4[0]
    #endregion

    #region ExternalEnvironment
    public float energy;//energy from external environmetn is metabolized, then it supports glandA/B to do work and this releases heat. So energy>deltaA+deltaB
    public float heat;//heat is released by living systems(cube+audiences)
    public float G;//the totual external stimulus
    private float G2;//external stimulus done by deltaA1 and deltaaA2
    private float G3;//external stimulus left for deltaA3 to handle within its limited time
    public float deltaG;//delta external stimulus
    private float deltaAudienceG;//delta external stimulus input
    #endregion

    #region Internal Value
    public float internalValue;
    private float IVu1;//1st threshold:60
    private float IVu2;//2nd threshold:70
    private float IVu3;//3rd threshold:90
    private float IVu4;//4th threshold:150
    #endregion

    #region A
    public float deltaA;//A production/timeunit
    private float deltaA0;
    private float deltaA1;
    private float deltaA2;
    private float deltaA3;
    private float deltaAmax;//work at this rate for too long would cause A resistance, eventually causing glandA failure
    #endregion

    #region B
    public float deltaB;//B production/timeunit
    private float deltaB0;
    private float deltaBmax;
    #endregion

    #region Game manager singleton pattern
    private static MyGameManager instance;
    public static MyGameManager FindInstance()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {   //instruction
        Debug.Log("This is a test version for a simple mathematical model of a living system on my ipad. ");
        Debug.Log("Please look at the console, follow the instruction and observe the public varibales at the right.");
        Debug.Log("It is really fast(I have not yet revised the time units.");

        Debug.Log("Press the left mouse button to see the handleable external stimulus's effect(10 times to trigger.)");

        Debug.Log("Press the right mouse button to see the chronic stimulus's effect(10 times to trigger.)");


        //Default 
        internalValue = 50;//inital internal value      
        deltaA0 = 2; //A production/timeunit
        deltaB0 = 2; //B production/timeunit
        deltaG = 0;

        //IV thresholds
        IVu1 = 60;
        IVu2 = 70;
        IVu3 = 90;
        IVu4 = 150;

        //time
        workingT = 20;//GlandA/B needs to make IV return to the normal range within 20 time units
        inputT = 10000000;//positive infinity
        IV3T = 10000000;//positive infinity
        IV4T = 10000000;//positive infinity

        //Users input
        deltaAudienceG = 7;//Audience inputs delta external stimulus = 7/time units
        GeffectT = 10;//external stimulus's effecting time = 10 time units
        G = deltaAudienceG * GeffectT;//total external stimulus

        //calculate for HandleableStimulus
        deltaA1 = Random.Range(deltaA0 + 1, deltaAudienceG - 3);
        deltaA2 = Random.Range(deltaA1 + 1, deltaAudienceG - 2);

        //stressor effect for StressStimulus
        SeffectT = 100;//long long time because chronic stress causes gland failure
        deltaAmax = deltaAudienceG + 1 + deltaA0;
        TdeltaAmax = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //time
        timer += Time.deltaTime;
        myTime = (int)timer / 1; //time unit;
        TimePoints();

        //original Environment
        if (click == 0)
        {
            Original();
        }

        //HandleableStimulus
        if (Input.GetMouseButtonDown(0))
        {
            click = 1;
            Debug.Log("handleable stimulus");
            inputT = timer;
            Gworking = inputT + GeffectT;

        }
        if (click == 1)
        {
            HandleableStimulus();
        }

        //Chronic StressStimulus
        if (Input.GetMouseButtonDown(1))
        {
            click = click+12;
            if(click == 120)
            {
                Debug.Log("chronic stress");
                inputT = timer;
                Gworking = inputT + SeffectT;
            }
            
        }
        if (click == 120)
        {
            StressStimulus();
        }

        //Equation
        internalValue = internalValue - deltaA / 60 + deltaB / 60 + deltaG / 60;
        energy = deltaA + deltaB + 10; //energy > deltaA + deltaB

    }

    public void TimePoints()
    {
        if (internalValue >= IVu1 && internalValue <= IVu1 + 0.5f)
        {
            Debug.Log(timer);
            IV1t = timer;
            TIV1.Add(IV1t);
        }

        if (internalValue >= IVu2 && internalValue <= IVu2 + 0.5f)
        {
            //Debug.Log("70:"+timer);
            IV2t = timer;
            TIV2.Add(IV2t);
        }

        if (internalValue >= IVu3 && internalValue <= IVu3 + 0.5f)
        {
            //Debug.Log("90:"+timer);
            IV3t = timer;
            TIV3.Add(IV3t);
            IV3T = TIV3[0];
        }

        if (internalValue >= IVu4 && internalValue <= IVu4 + 0.5f)
        {
            //Debug.Log("150:"+timer);
            IV4t = timer;
            TIV4.Add(IV4t);
            IV4T = TIV4[0];
        }
    }

    public void Original()
    {
        deltaA = deltaA0;
        deltaB = deltaB0;
        deltaG = 0;
    }

    public void HandleableStimulus()
    {
        //time function
        //deltaG,B
        if (myTime <= inputT)
        {
            deltaG = 0;
            deltaA = deltaA0;
            deltaB = deltaB0;
        }
        else
        {
            if (myTime < Gworking)
            {
                deltaG = deltaAudienceG;
                deltaB = deltaB0;

            }
            else
            {
                deltaG = 0;
                deltaB = deltaB0;
            }

        }
        //deltaA  
        if (myTime < IV3T)
        {
            if (internalValue > IVu1 && internalValue <= IVu2)
            {
                deltaA = deltaA1;
            }
            else if (internalValue > IVu2 && internalValue <= IVu3)
            {
                deltaA = deltaA2;
            }
            else if (internalValue <= IVu1)
            {
                deltaA = deltaA0;
            }
        }
        else
        {
            if (internalValue <= IVu1)
            {
                deltaA = deltaA0;
            }
            else
            {
                //Debug.Log();
                //ie, when workingT = 20 time units:
                G2 = (deltaA1 - deltaA0) * (TIV2[0] - TIV1[0]) + (deltaA2 - deltaA0) * (IV3T - TIV2[0]);
                G3 = G - G2;
                TdeltaA3 = workingT - (IV3T - TIV1[0]);
                deltaA3 = deltaA0 + G3 / TdeltaA3;
                deltaA = deltaA3;
            }
        }

    }

    public void StressStimulus()
    {
        //time function
        //deltaG,B
        if (myTime <= inputT)
        {
            deltaG = 0;
            deltaA = deltaA0;
            deltaB = deltaB0;
        }
        else
        {
            if (myTime < Gworking)
            {
                deltaG = deltaAudienceG;
                deltaB = deltaB0;
            }
            else
            {
                deltaG = 0;
                deltaB = deltaB0;
            }

        }
        //deltaA
        if (myTime < IV4T)
        {
            if (internalValue <= IVu1)
            {
                deltaA = deltaA0;
            }
            else if (internalValue > IVu1 && internalValue <= IVu2)
            {
                deltaA1 = 3;
                deltaA = deltaA1;
            }
            else if (internalValue > IVu2 && internalValue <= IVu3)
            {
                deltaA2 = 4;
                deltaA = deltaA2;
            }
            else if (internalValue > IVu3 && internalValue <= IVu4)
            {
                deltaA3 = 5;
                deltaA = deltaA3;
            }
        }
        else
        {
            if (timer - IV4T >= TdeltaAmax)
            {
                deltaA = deltaA0;
                Debug.Log("glandA fails");
            }
            else
            {
                deltaA = deltaAmax;
            }
        }

    }
}
