using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{

    public UnityEngine.Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
       CrossHairPosition();
    }

    void CrossHairPosition()
    {

         Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
         mousePos.z = 0;
         transform.position = mousePos;
         
    }
}
