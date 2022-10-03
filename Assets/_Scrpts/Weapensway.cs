using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapensway : MonoBehaviour
{

    public float Smoothing;
    public float Swayamount;
    public  AnimationCurve curve;
    float swayH;
    float swayV;
    
     void SwayInput()
    {   
        swayH = Input.GetAxis("Mouse X") * Swayamount;
        swayV = Input.GetAxis("Mouse Y") * Swayamount;
    }


        float ani;
    void setSway()
    {
        Quaternion rotateX;
        Quaternion rotateY;
        rotateX = Quaternion.AngleAxis(-swayV, Vector3.right* Swayamount);
        rotateY = Quaternion.AngleAxis(swayH, Vector3.up* Swayamount);
        Quaternion Targetrotate;
        Targetrotate = rotateX * rotateY;

        transform.localRotation = Quaternion.Lerp (transform.localRotation, Targetrotate,Swayamount *Time.deltaTime);
       
    }
    // Update is called once per frame
    void Update()
    {
        SwayInput();
        setSway();
    }
}
