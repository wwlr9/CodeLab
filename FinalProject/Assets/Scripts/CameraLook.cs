using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CameraLook : MonoBehaviour
{

    FishManager fishManager;

    // Start is called before the first frame update
    void Start()
    {
        fishManager = GameObject.Find("FishManager").GetComponent<FishManager>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Ray casting(mouse click on objects)
        Vector3 eyePos = transform.position;//start of the ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;//click on objects I can see via the camera
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 myDirect = mouseWorldPos - eyePos;//direction the ray goes
        myDirect.Normalize();
        RaycastHit myHitter = new RaycastHit();

        if (Physics.Raycast(eyePos, myDirect, out myHitter))
        {
            //Debug.Log(myHitter.collider.gameObject.name);//return the name of game object I hit

            if (myHitter.collider.gameObject.tag == "key")
            {
                //Debug.Log("key");
                fishManager.dialog.text = fishManager.storyLine[2];//find the key
            }

        }
        #endregion

    }
}
