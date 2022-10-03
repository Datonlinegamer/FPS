using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCam : MonoBehaviour
{

    [SerializeField] float senX;
    [SerializeField] float senY;
    [SerializeField] Transform oriention;
    [SerializeField] Transform weaponoriention;
    float Xrotate;
    float Yrotate;

    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        float my = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;
        Yrotate += mx;
        Xrotate -= my;

        Xrotate = Mathf.Clamp(Xrotate, -20, 20);
        transform.rotation = Quaternion.Euler(Xrotate, Yrotate, 0);
        oriention.rotation = Quaternion.Euler(0, Yrotate, 0);


    }

}
	
