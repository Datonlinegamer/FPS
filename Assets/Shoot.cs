using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public List<Transform> shootPoints;
    public List< ParticleSystem> flash;
  public float rayLanth;
    void Start()
    {

    }

        RaycastHit cast;
    void SetRay()
    {
        for (int i = 0; i < shootPoints.Count; i++)
        {
            if (shootPoints.Contains(shootPoints[i]))
            {

                if(Physics.Raycast(shootPoints[i].position, transform.forward, out cast, rayLanth))
                if (Input.GetMouseButton(0) &&cast.collider.gameObject.tag =="Pumpkin")
                {
                        Debug.Log(cast.collider.name);
                        health.Instance.TakeDamage(4);
                  
                }
            
           
            }
        }
    }

    void Emitflash()
    {
       if ( Input.GetMouseButtonDown(0))
       {
            for (int q = 0; q< flash.Count; q++)
            {
                CameraRecoil.Instance.Recoilfire();
                flash[q].Emit(30);
            }

       }
    }
    void Update()
    {
        SetRay();
        Emitflash(); 

    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < shootPoints.Count; i++)
        {

            Gizmos.color = Color.green;
            Gizmos.DrawRay(shootPoints[i].position, transform.forward* rayLanth);

		}
			

    }

}
    

