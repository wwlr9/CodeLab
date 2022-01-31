using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    public float my_Speed = 7f;

void Start()
{
    //Fetch the Rigidbody from the GameObject with this script attached
    m_Rigidbody = GetComponent<Rigidbody2D>();
}

void FixedUpdate()
{
    //arrow keys
    Vector3 my_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

    //Apply the movement vector to the current position, which is
    //multiplied by deltaTime and speed for a smooth MovePosition
    m_Rigidbody.MovePosition(transform.position + my_Input * Time.deltaTime * my_Speed);
}
}
