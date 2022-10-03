using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHolder : MonoBehaviour
{

    [SerializeField] Transform campoint;

    void Update()
    {
         transform.position = campoint.position;
    }
}
