using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public bool keyClick;

    // Start is called before the first frame update
    void Start()
    {
        keyClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        //Debug.Log("click");
        keyClick = true;
    }

}
