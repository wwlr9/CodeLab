using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    int Heartnum = 10;
    int Harmnum = 20;
    public GameObject Heart;
    public GameObject Harm;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello world");

        

        for (int x = 0; x < Heartnum; x++)
        {
            Instantiate(Heart, new Vector3(Random.Range(-15.0f, 15.0f), Random.Range(-5.0f, 5.0f), 0.0f), Quaternion.identity);
        }

        for (int x = 0; x < Harmnum; x++)
        {
            Instantiate(Harm, new Vector3(Random.Range(-15.0f, 15.0f), Random.Range(-5.0f, 5.0f), 0.0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
