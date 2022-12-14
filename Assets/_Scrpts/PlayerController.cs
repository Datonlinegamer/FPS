using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    float Horizontal;
    float Vertical;
    float jumpCoolDown;
    float AIrvalocity;
    public float moveSpeed ;
    public  float Playerhight;
    public float groundDrag;
    [SerializeField] protected float Jumpforce;

    public	LayerMask WhatisGround;

    public bool Moving;
    public bool Grounded;
     public bool Canjump;

    public Transform Orientation;
    Vector3 Movedir;
   protected Rigidbody rb;
      
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        
    }



    
    void Update()
    {
        Groundcheck();
        PlayspeedControl();
        PlayersInput();
        playerSprit();
    }

	private void FixedUpdate()
	{
        Playermove();
	}
	void PlayersInput()
	{
        Horizontal = Input.GetAxisRaw("Horizontal");
       Vertical = Input.GetAxisRaw("Vertical");

        if (Grounded)
        {
            rb.drag = groundDrag;
        Moving = false;

        }

        else
            rb.drag = 0;
		
	}
   

       public RaycastHit hit;
     public bool Groundcheck()
   	{
        if (Physics.Raycast (this.transform.position, Vector3.down,  out hit ,  Playerhight , WhatisGround))
        {
            if (hit.collider.gameObject.tag == "ground"&& Input.GetKey(KeyCode.Space))
            {
              
                rb.AddForce(Vector3.up .normalized* Jumpforce, ForceMode.Force);

                Debug.Log(hit.collider);

            }   

                
            
        }       
        
                
      
        return Grounded;
	}
    
     
    void Playermove()
	{
         Movedir = Orientation.forward * Vertical + Orientation.right * Horizontal;
        rb.AddForce(Movedir.normalized * moveSpeed * 10,ForceMode.Force);
	}

	void PlayspeedControl()
	{
        Vector3 flatSpeed;
        flatSpeed = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		if (flatSpeed.magnitude > moveSpeed)
		{
            Moving = true;
            Vector3 speedlimit;
            speedlimit = flatSpeed.normalized * moveSpeed;
           rb.velocity = new Vector3(speedlimit.x, rb.velocity.y, speedlimit.z);
        }
        if (!(flatSpeed == Vector3.zero))
        {
            return;
        }   
            Moving = false;
	}

    bool CanJump()
    {
        return Canjump  ;
    }
       public float SpritcoolDown ;
    void playerSprit()
    {
        if (Input.GetKey(KeyCode.LeftShift)&& Moving != false)
        {
            SpritcoolDown -= Time.deltaTime;
            moveSpeed = 1000* Time.deltaTime;
        }
        if (SpritcoolDown <= 0)
        {
            moveSpeed = 100;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, Vector3.down * Playerhight)  ;
    }
}
