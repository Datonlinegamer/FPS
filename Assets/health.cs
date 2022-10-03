using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public static health Instance;
  public  int Currenthealth = 10;
    int Maxhealth;
    
    void Start()
    {
        Currenthealth = Maxhealth;
        Instance = this;
    }

    public void TakeDamage(int d)
    {
        Currenthealth -= d;
        if (Currenthealth < 0)
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
