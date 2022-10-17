using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public static health Instance;
  public float Currenthealth  ;
   float Maxhealth;
    
    void Start()
    {
        
        Currenthealth = Maxhealth;
        Instance = this;
    }

    public void TakeDamage(float d)
    {
        Currenthealth -= d;
        if (Currenthealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        
        this.gameObject.SetActive(false);
    }
    void Update()
    {
          
    }
}
