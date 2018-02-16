﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public GameObject crosshair1;
	public GameObject crosshair2;
    Rigidbody2D rb;
    public float accelleration;
    public float maxVelocity;
    private Vector3 fireVector;
    public GameObject bullet;
    public GameObject bullet2;
    public float fireSpeed;
    private bool canFire1 = true;
    private bool canFire2 = true;

    public float deadzone = 0.25f;

    //axes to use
    private string h;
    private string v;
    private string hAim;
    private string vAim;
	private string chAim;
	private string cvAim;
    private string f1;
    private string f2;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>(); //save rigidbody for later use
        if (gameObject.tag=="Player") //check if the player that this is attached to is p1 or p2 and assign controls based on that
        {
            h = "Horizontal";
            v = "Vertical";
            hAim = "HorizontalAim";
            vAim = "VerticalAim";
            f1 = "Fire1";
            f2 = "Fire2";
        }
        if (gameObject.tag == "Player2")
        {
            h = "Horizontal2";
            v = "Vertical2";
            hAim = "HorizontalAim2";
            vAim = "VerticalAim2";
            f1 = "Fire12";
            f2 = "Fire22";
        }
		if (transform.Find ("crosshair1").gameObject.tag == "Player") // find child of player and assign aiming
		{
			hAim = "HorizontalAim";
			vAim = "VerticalAim";
		}
		if (transform.Find ("crosshair2").gameObject.tag == "Player2") // repeat step for second player
		{ 
			hAim = "HorizontalAim2";
			vAim = "VerticalAim2";
		}
	}	
	
	// Update is called once per frame
	void Update () {
        //get input for movement
        float xAxis = -Input.GetAxis(h); 
        float yAxis = -Input.GetAxis(v);
		Accellerate(xAxis, yAxis); //call the movement function

        if (Input.GetAxis(f1)!=0) //get input for shockwave attack from right trigger
        {
            if (canFire1) // since the trigger doesn't have a "getbuttondown" because it is an axis this bool takes care of only fireing it once when the trigger is pulled
            {
                if (Input.GetAxis(hAim)!= 0 || Input.GetAxis(vAim)!=0) //this is to make sure you don't fire a shockwave when you are not aiming anywhere
                {
                    fireVector = new Vector2(Input.GetAxis(hAim), -Input.GetAxis(vAim)); //get input for aiming
                    GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity); //instantiate bullet/shockwave
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), newBullet.GetComponent<Collider2D>()); // this is to make sure you are not pushed around by your own bullet/shockwave
                    newBullet.GetComponent<Rigidbody2D>().AddForce(fireVector * fireSpeed); //add force to the bullet in the direction of your aim
                    canFire1 = false; //this is the same bool, that makes sure you don't fire a 1000 bullets a second
                }
            }
        }
        else
        {
            canFire1 = true; //when the player releases the trigger they get back the ability to shoot
        }
        if (Input.GetAxis(f2)!=0) //same thing for the other projectile, you get the idea
        {
            if (canFire2)
            {
                if (Input.GetAxis(hAim) != 0 || Input.GetAxis(vAim) != 0)
                {
                    fireVector = new Vector2(Input.GetAxis(hAim), -Input.GetAxis(vAim));
                    GameObject newBullet = Instantiate(bullet2, transform.position, Quaternion.identity);
                    newBullet.GetComponent<BulletSwitchBehavior>().SetWhoFiredMe(gameObject);
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), newBullet.GetComponent<Collider2D>());
                    newBullet.GetComponent<Rigidbody2D>().AddForce(fireVector * fireSpeed);
                    canFire2 = false;
                }
            }

        }
        else
        {
            canFire2 = true;
        }

    }

	void Accellerate(float y, float x) //this is the movement of the player
    {
        Vector2 force = new Vector2(0, 0); 
        if (new Vector2 (x,y).magnitude > deadzone) // there is a deadzone on the controllers joysticks, if the input is in the dead zone, we ignore it
        {
            force = (transform.up * y * accelleration) + (transform.right * x * accelleration); //we have physics based movement, here we calculate the force to be applied to the player
			crosshair1.SetActive = true;
			crosshair2.SetActive = true;
			crosshair1 = new Vector2 (Input.GetAxis (hAim), -Input.GetAxis (vAim)); // once activated, get axes for each crosshair
			crosshair2 = new Vector2 (Input.GetAxis (hAim), -Input.GetAxis (vAim));
        }
        rb.AddForce(force); // and then we apply that force to the player
        ClampVelocity(); // this function limits the velocity of the player to the max velocity we set
    }
    void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }
}
