using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove : MonoBehaviour
{
    private float amplitude;
    private float frequency;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        amplitude = 7f;
        frequency = 7f;

    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        float x = transform.position.x;
        float y = Mathf.Sin(time * frequency) * amplitude+10; 
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
