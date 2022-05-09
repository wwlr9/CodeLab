using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]//you are able to see it in the editor even though the variable is not public
    private float moveSpeed = 2.0f;

    Vector3 getInput;

    private void Update()
    {
        getInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()//run at a set rate
    {
        GetComponent<Rigidbody>().velocity = getInput * moveSpeed;

        //player always faces to the direction of movement
        Vector3 lookPos = new Vector3(
            transform.position.x + GetComponent<Rigidbody>().velocity.x,
            transform.position.y,
            transform.position.z + GetComponent<Rigidbody>().velocity.z
            );
        transform.LookAt(lookPos);

    }
}
