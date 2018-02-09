using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
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
    private string f1;
    private string f2;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (gameObject.tag=="Player")
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
	}
	
	// Update is called once per frame
	void Update () {
        float xAxis = -Input.GetAxis(h);
        float yAxis = -Input.GetAxis(v);
        Accellerate(xAxis, yAxis);

        if (Input.GetAxis(f1)!=0)
        {
            if (canFire1)
            {
                //fireVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                if (Input.GetAxis(hAim)!= 0 || Input.GetAxis(vAim)!=0)
                {
                    fireVector = new Vector2(Input.GetAxis(hAim), -Input.GetAxis(vAim));
                    print(fireVector);
                    GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), newBullet.GetComponent<Collider2D>());
                    newBullet.GetComponent<Rigidbody2D>().AddForce(fireVector * fireSpeed);
                    canFire1 = false;
                }
            }
        }
        else
        {
            canFire1 = true;
        }
        if (Input.GetAxis(f2)!=0)
        {
            if (canFire2)
            {
                //fireVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                if (Input.GetAxis(hAim) != 0 || Input.GetAxis(vAim) != 0)
                {
                    fireVector = new Vector2(Input.GetAxis(hAim), -Input.GetAxis(vAim));
                    print(fireVector);
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

    void Accellerate(float y, float x)
    {
        Vector2 force = new Vector2(0, 0);
        if (new Vector2 (x,y).magnitude > deadzone)
        {
            force = (transform.up * y * accelleration) + (transform.right * x * accelleration);
        }
        if (y != 0 || x != 0)
        {
            

        }
        rb.AddForce(force);
        ClampVelocity();
    }
    void ClampVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }
}
