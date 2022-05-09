using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    #region Game manager singleton pattern
    private static MyGameManager instance;
    public static MyGameManager FindInstance()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion


    private Button startButton;
    private Button endButton;

    FishManager fishManager;
    Story story;

    // Start is called before the first frame update
    void Start()
    {

        startButton = GameObject.Find("Start").GetComponent<Button>();
        endButton = GameObject.Find("End").GetComponent<Button>();
        
    }

    // Update is called once per frame
    void Update()
    {
        startButton.onClick.AddListener(StartGame);//start the game
        endButton.onClick.AddListener(EndGame);//end the game

        //go to travel scene
        TravelScene();
        //restart when game ends
        RestartGame();
    }

    void StartGame()
    {
    SceneManager.LoadScene("FishBone");
    }

    void EndGame()
    {
        Application.Quit();
    }

    void TravelScene()
    {
        if (GameObject.Find("FishManager") != null)
        {
            fishManager = GameObject.Find("FishManager").GetComponent<FishManager>();
            if (fishManager.timetotravel >= 8)
            {
                SceneManager.LoadScene("Travel");
                Debug.Log("Travel");
            }
        }      
    }

    void RestartGame()
    {
        if (GameObject.Find("TextManager") != null)
        {
            story = GameObject.Find("TextManager").GetComponent<Story>();
            if (story.mouseNum == 29)
            {
                SceneManager.LoadScene("Menu");
                Debug.Log("restart");
            }
        }
    }

   
  }
