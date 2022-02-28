using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class LevelLoader : MonoBehaviour
{
    public string fileName;

    private char[] newLineChar = { '\n' };
    public string[] storyLine;
    private int mouseNum = 0;

    private GameObject Canvas;
    private GameObject Cam;

    // Start is called before the first frame update
    void Start()
    {
        //refer to camera
        Cam = GameObject.Find("Main Camera");

        //Read the txt file
        StreamReader reader = new StreamReader(fileName);
        string contentOfFile = reader.ReadToEnd();
        reader.Close();
        //Debug.Log(contentOfFile);

        //For every line in the text file
        storyLine = contentOfFile.Split(newLineChar);

        //create a canvas/text game object from resources folder
        Canvas = Instantiate(Resources.Load("Canvas")) as GameObject;
        Canvas.GetComponentInChildren<Text>().text = (storyLine[0]);

        //for (int i = 0; i < storyLine.Length; i++)
        //{                      
        //}       
    }

    void changeBackColor(float colorR, float colorG, float colorB)
    {
        Cam.GetComponent<Camera>().backgroundColor = new Color(colorR / 255f, colorG/ 255f, colorB / 255f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Eveytime player clicks the left button
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pressed primary button.");
            mouseNum = mouseNum + 1;

            //Change text content from the txt file
            Canvas.GetComponentInChildren<Text>().text = (storyLine[mouseNum]);

            //Change background color
            //intro 1
            if(mouseNum == 0)
            {
                changeBackColor(0, 26, 51);           
            }
            //cambrian 2-5
            if (mouseNum < 5 && mouseNum > 0)
            {
                changeBackColor(0,50,110);
            }
            //silurian 6-10
            if (mouseNum < 10 && mouseNum > 4)
            {
                changeBackColor(0, 70,130);
            }
            //devonian 11-15
            if (mouseNum < 15 && mouseNum > 9)
            {
                changeBackColor(0, 90, 180);
            }
            //land 16 - 21
            if (mouseNum < 21 && mouseNum > 14)
            {
                changeBackColor(210,272,171);
                Canvas.GetComponentInChildren<Text>().color = Color.black;
            }

            //End the game
            if (mouseNum == 20)
            {
                Debug.Log("end");
            }

            //Restart
            if (mouseNum == 21)
            {
                mouseNum = 0;
                changeBackColor(0,0,0);
                Canvas.GetComponentInChildren<Text>().color = Color.white;
            }
        }          
    }
}
