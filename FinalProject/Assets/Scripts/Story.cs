using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    #region dialog
    public Text dialog;
    public char[] newLineChar = { '\n' };
    public string[] storyLine;

    public string fishText;
    #endregion

    public int mouseNum = 0;

    #region Gameobjects
    private GameObject Cambrian;
    private GameObject Silurian;
    private GameObject Devonian;
    private GameObject land;
    public Material Cam;
    public Material Sil;
    public Material Dev;
    public Material Land;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //set up UI
        dialog = GameObject.Find("Dialog").GetComponent<Text>();

        //file names
        fishText = "fishText.txt";
        Cambrian = GameObject.Find("Cambrian");
        Silurian = GameObject.Find("Silurian");
        Devonian = GameObject.Find("Devonian");
        land = GameObject.Find("Land");

        mouseNum = 0;

        txtRead(fishText);
        dialog.text = storyLine[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseNum = mouseNum + 1;
            Debug.Log(mouseNum);
            if (mouseNum < storyLine.Length)
            {
                dialog.text = storyLine[mouseNum];
            }
            
        }      

        //change material when arrives at each period
        if(mouseNum == 2)
        {
            Cambrian.GetComponent<MeshRenderer>().material = Cam;
        }

        if (mouseNum == 9)
        {
            Silurian.GetComponent<MeshRenderer>().material = Sil;
        }
        if (mouseNum == 15)
        {
            Devonian.GetComponent<MeshRenderer>().material = Dev;
        }
        if (mouseNum == 23)
        {
            land.GetComponent<MeshRenderer>().material = Land;
        }

        
    }

    void txtRead(string myFile)
    {
        StreamReader reader = new StreamReader(myFile);
        string contentOfFile = reader.ReadToEnd();
        reader.Close();
        storyLine = contentOfFile.Split(newLineChar);
       
    }
}
