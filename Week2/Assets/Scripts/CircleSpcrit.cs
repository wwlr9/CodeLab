using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpcrit : MonoBehaviour
{
    W2GameManager myManager;
    // Start is called before the first frame update
    void Start()
    {
        //W2GameManager myManager = GameObject.Find("Game Manager").GetComponent<W2GameManager>();
        //refer to public float score;
        //Debug.Log(myManager.score);

        //refer to public static float score;
        Debug.Log(W2GameManager.score);
        W2GameManager.score += 2;

        //use singleton pattern to do references
        W2GameManager myManager = W2GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Utilscript.Vector3Modify(transform.position, -0.1f, 0, 0);

        //not working because high score is private
        //Debug.Log("High Score:" + W2GameManager.highScore);

        //W2GameManager myManager = GameObject.Find("Game Manager").GetComponent<W2GameManager>();

        //use singleton pattern to do references
        W2GameManager myManager = W2GameManager.GetInstance();
        Debug.Log(myManager.HighScore);

        transform.position = Utilscript.Vector3Modify(transform.position, W2GameManager.circleSpeed, 0, 0);
    }
}
