using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    private static MyGameManager instance;
    public static MyGameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        //create game manager singleton
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
        
    }

    // Update is called once per frame
    void Update()
    {
        //check the character health value throughout the game
        AICharacter myCharacter = GameObject.Find("AICharacter").GetComponent<AICharacter>();
        Debug.Log(myCharacter.CharacterHealth);

        //start the game from the menu scene
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
