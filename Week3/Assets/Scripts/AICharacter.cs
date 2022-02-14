using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacter : MonoBehaviour
{
    //create character health variable
    private int characterHealth = 2;
    //make characterHealth accessible to other classes
    public int CharacterHealth
    {
        get
        {
            return characterHealth;
        }
        set
        {
            characterHealth = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Good")
        {
            characterHealth = characterHealth + 1;
        }
        if (collision.gameObject.name == "Bad")
        {
            characterHealth = characterHealth - 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GoodArea")
        {
            characterHealth = characterHealth + 1;
        }

        if (collision.gameObject.name == "BadArea")
        {
            characterHealth = characterHealth - 1;
        }
    }
}
