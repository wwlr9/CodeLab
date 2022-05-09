using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class FishManager : MonoBehaviour
{
    #region Game objects of fish bone of fossil
    private GameObject head;
    private GameObject headFossil;
    private GameObject bone1;
    private GameObject bone1Fossil;
    private GameObject bone4;
    private GameObject bone4Fossil;
    private GameObject bone5;
    private GameObject bone5Fossil;
    public GameObject key;
    #endregion

    private bool FishSetUp;


    #region dialog
    public Text dialog;
    public string fileName;
    public char[] newLineChar = { '\n' };
    public string[] storyLine;
    #endregion

    Key keyScript;

    public float timetotravel;
    void Start()
    {
        FishSetUp = false;
        timetotravel = 0;
        
        head = GameObject.FindWithTag("head");
        headFossil = GameObject.FindWithTag("headFossil");
        bone1 = GameObject.FindWithTag("bone1");
        bone1Fossil = GameObject.FindWithTag("bone1Fossil");
        bone4 = GameObject.FindWithTag("bone4");
        bone4Fossil = GameObject.FindWithTag("bone4Fossil");
        bone5 = GameObject.FindWithTag("bone5");
        bone5Fossil = GameObject.FindWithTag("bone5Fossil");

        //create dialog txt file 
        fileName = "dialog.txt";
        StreamReader reader = new StreamReader(fileName);
        string contentOfFile = reader.ReadToEnd();
        reader.Close();
        storyLine = contentOfFile.Split(newLineChar);
        dialog = GameObject.Find("Dialog").GetComponent<Text>();
        dialog.text = storyLine[0]+ '\n' + storyLine[1];

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 headDiff = head.transform.position - headFossil.transform.position;
        Vector3 bone1Diff = bone1.transform.position - bone1Fossil.transform.position;
        Vector3 bone4Diff = bone4.transform.position - bone4Fossil.transform.position;
        Vector3 bone5Diff = bone5.transform.position - bone5Fossil.transform.position;

        PosCheck(headDiff, head, headFossil);
        PosCheck(bone1Diff, bone1, bone1Fossil);
        PosCheck(bone4Diff, bone4, bone4Fossil);
        PosCheck(bone5Diff, bone5,bone5Fossil);

        if (head.GetComponent<Rigidbody>().mass == 200 & bone1.GetComponent<Rigidbody>().mass == 200 & bone4.GetComponent<Rigidbody>().mass == 200 & bone5.GetComponent<Rigidbody>().mass == 200)
        {
            FishSetUp = true;
        }
        //Debug.Log(FishSetUp);

        //instantiate key
        if (FishSetUp && key == null)
        {
            key = Instantiate(Resources.Load("Key")) as GameObject;
            keyScript =key.GetComponent<Key>();
            Debug.Log(keyScript.keyClick);
        }
        //show after grab the key
        if (FishSetUp && key != null)
        {
            if (keyScript.keyClick)
            {
                //Debug.Log(keyScript.keyClick);
                dialog.text = storyLine[3];
                timetotravel += Time.deltaTime;
            }
        }

    }

    void PosCheck(Vector3 Diff, GameObject bone, GameObject fossil)
    {
        //Debug.Log(head.transform.position);
        //Debug.Log(headFossil.transform.position);
        //Debug.Log(Diff);

        //If player push  bones on the fossil, clear rigidbody so player could not push bones anymore
        if (Mathf.Abs(Diff.x) < 0.3 && Mathf.Abs(Diff.z) < 0.3)
        {
            //Debug.Log("good" + Diff);
            bone.GetComponent<Rigidbody>().mass = 200;
        }
    }

 
    
}

