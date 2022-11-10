using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPumpkinBehaviar : MonoBehaviour
{

    float Distance =1;
    float Inrange;

    bool inRange;
    RaycastHit Cast;


    bool InRange()
    {

        if (!(Physics.Raycast(this.transform.position, transform.forward, out Cast, Distance)))
        {
            return inRange;
        }

        
        return inRange = true;
    }


    void Update()
    {
        this.transform.localPosition -= -transform.right  *Time.deltaTime /6 ;
    }
}
