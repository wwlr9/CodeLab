using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileIO : MonoBehaviour
{
    //create a txt file
    const string FILE_NAME = "healthValue.txt";
    // Start is called before the first frame update
    void Start()
    {
        //QUESTION: I don't know how to get the ultimate health value (like right before I exist the game), if I put it in update it gives too many

        //find the AI character script and get access to the health value
        //write a file with the health value
        AICharacter myCharacter = GameObject.Find("AICharacter").GetComponent<AICharacter>();
        StreamWriter writer = new StreamWriter(FILE_NAME, true);
        writer.Write(myCharacter.CharacterHealth + ",");
        writer.Close();

        //read the health value txt file and show the content in the console
        StreamReader reader = new StreamReader(FILE_NAME);
        string content = reader.ReadLine();
        Debug.Log(content);
        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
