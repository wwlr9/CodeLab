using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentGenerator : MonoBehaviour
{
    //create two game objects: name,arrays,number(array length)
    private GameObject good;
    private GameObject bad;

    public GameObject[] goods;
    public GameObject[] bads;

    public int goodNum;
    public int badNum;

    // Start is called before the first frame update
    void Start()
    {
        //Find 2 game objects good and bad based on their names
        good = GameObject.Find("Good");
        bad = GameObject.Find("Bad");

        //set up the number of comments players would generate
        //Question here: not working with the correct number for instantiate...
        goodNum = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //Player generates good and bad comments which would affect health value
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("generate good and bad");
            //for(int x = 0; x < goodNum; x++)
            //{
                Instantiate(good, new Vector3(Random.Range(-30.0f, 40.0f), Random.Range(-5.0f, -15.0f), 0.0f), Quaternion.identity);
                //Debug.Log(goodNum);
            //}
            
            Instantiate(bad, new Vector3(Random.Range(-30.0f, 40.0f), Random.Range(-5.0f, -15.0f), 0.0f), Quaternion.identity);

            //store good in an array goods, and get the number of good

            //store bad in an array bads, and get the number of bad


        }
    }
}
