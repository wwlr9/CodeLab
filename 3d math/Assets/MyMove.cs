using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMove : MonoBehaviour
{
    public float amplitute;
    public float frequency;
    public float timePoint;
    public float timePoint2;
    public float timePoint3;

    public float click;//state of clicking

    // Start is called before the first frame update
    void Start()
    {
        amplitute = 7f;
        frequency = 2f;
        click = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timePoint3 = Time.time;

        float x = Mathf.Cos(timePoint * frequency) * amplitute;
        float y = transform.position.y;
        float z = transform.position.z;
        

        if (Input.GetMouseButtonUp(0))
        {
            click = 1;
            timePoint2 = Time.time; //constant: get the exact time when the button is released                      
        }

        if(click == 0)
        {
            timePoint = timePoint3; //variable: get a timer
            
        }
        else
        {
            timePoint = timePoint2;
            if (x <= 1.5f && x >= -1.5f)
            {
                Debug.Log("YOU GET IT");//Question: It seems like that the result is not accurate enough
            }
        }


        transform.position = new Vector3(x, y, z);
       

    }
}
