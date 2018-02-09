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

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        Accellerate(xAxis, yAxis);

        if (Input.GetButtonDown("Fire1"))
        {
            fireVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), newBullet.GetComponent<Collider2D>());
            newBullet.GetComponent<Rigidbody2D>().AddForce(fireVector*fireSpeed);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            fireVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            GameObject newBullet = Instantiate(bullet2, transform.position, Quaternion.identity);
            newBullet.GetComponent<BulletSwitchBehavior>().SetWhoFiredMe(gameObject);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), newBullet.GetComponent<Collider2D>());
            newBullet.GetComponent<Rigidbody2D>().AddForce(fireVector * fireSpeed);
        }

    }

    void Accellerate(float y, float x)
    {
        Vector2 force = new Vector2(0, 0);
        if (y != 0 || x != 0)
        {
            force = (transform.up * -y * accelleration) + (transform.right * x * accelleration);

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
