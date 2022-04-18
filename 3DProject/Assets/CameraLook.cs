using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CameraLook : MonoBehaviour
{
    public string fileName;
    private char[] newLineChar = { '\n' };
    public string[] storyLine;

    private GameObject cube;

    private int myLyric;

    // Start is called before the first frame update
    void Start()
    {
        //create txt file for the lyric from The RED RAIN-HIROOMI TOSAKA   
        StreamReader reader = new StreamReader(fileName);
        string contentOfFile = reader.ReadToEnd();
        reader.Close();
        storyLine = contentOfFile.Split(newLineChar);

        //Instantiate # of game objects = lines of the lyric
        for (int i = 0; i < storyLine.Length; i++)
        {
            cube = Instantiate(Resources.Load("Cube")) as GameObject;
            cube.transform.position = new Vector3(Random.Range(-16,16),Random.Range(0.85f,6.92f), Random.Range(-14,14));
            cube.name = i.ToString();           
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyePos = transform.position;//start of the ray
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Camera.main.nearClipPlane;//so I can only click on objects I can see via the camera

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);//translate mouse position to this world space

        Vector3 myDirect = mouseWorldPos - eyePos;//direction the ray goes
        myDirect.Normalize();//1 with dir

        RaycastHit myHitter = new RaycastHit();
        
        if(Physics.Raycast(eyePos,myDirect,out myHitter))
        {
            if(myHitter.collider.gameObject.tag == "CUBE")
            {
                //Debug.Log(myHitter.collider.gameObject.name);//return the name of game object I hit
                myLyric = int.Parse(myHitter.collider.gameObject.name);
                Debug.Log(storyLine[myLyric]);
            }
            
        }
        
    }
}
