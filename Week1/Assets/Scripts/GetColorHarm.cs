using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetColorHarm : MonoBehaviour
{
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {

            Debug.Log("change to harm color");
            character.GetComponent<Renderer>().material = gameObject.GetComponent<Renderer>().material;
        }
    }
}

