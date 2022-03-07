using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class LevelLoader : MonoBehaviour
{
    public string fileName;

    public GameObject Canvas;

    private char[] newLineChar = { '\n' };
    public string[] storyLine;
    private int mouseNum = 0;

    W5GameManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        //refer to W5 game manager
        myManager = W5GameManager.FindInstance();

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

        Debug.Log(myManager.currentState);
    
    }


    // Update is called once per frame
    void Update()
    {
        //Eveytime player clicks the left button
        if (Input.GetMouseButtonDown(0))
        {
            mouseNum = mouseNum + 1;
            Debug.Log(myManager.currentState);
            Debug.Log(mouseNum);

            //Change text content from the txt file
            Canvas.GetComponentInChildren<Text>().text = (storyLine[mouseNum]);


            //cambrian 2-5
            if (mouseNum < 5 && mouseNum > 0)
            {
                myManager.TransitionStates(W5GameManager.State.cambrian);
            }
            
            //silurian 6-10
            if (mouseNum < 10 && mouseNum > 4)
            {
                myManager.TransitionStates(W5GameManager.State.silurian);
            }
            
            //devonian 11-15
            if (mouseNum < 15 && mouseNum > 9)
            {
                myManager.TransitionStates(W5GameManager.State.devonian);
            }

            //land 16 - 21
            if (mouseNum < 21 && mouseNum > 14)
            {
                myManager.TransitionStates(W5GameManager.State.land);
                Canvas.GetComponentInChildren<Text>().color = Color.black;
            }

            //End the game.
            if (mouseNum >= 21)
            {
                myManager.TransitionStates(W5GameManager.State.end);
            }


            
        }
    }
}
