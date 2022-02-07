using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class W2GameManager : MonoBehaviour
{
    //public float score;
    public static float score;

    public const float GRAVITY = 1.622f;

    private int userId = 2;

    private int highScore;
    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
        }
    }

    //public static float circleSpeed = -0.5f;
    public static float circleSpeed = 0;

    private static W2GameManager instance;

    public static W2GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance!=null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        //the same as DontDestroyOnLoad(this);

        HighScore = 10;
        //you get 10
        Debug.Log(highScore);

        circleSpeed = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //0 means left button
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
