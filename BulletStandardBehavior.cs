using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandardBehavior : MonoBehaviour {
    float bulletDistance = 8.0f;
    float bulletRange;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void BulletRange()
    {
        bulletRange = bulletDistance - 3.0f;
       /* if (bulletDistance > bulletRange)
        {
            Destroy(gameObject);
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().velocity);
        Destroy(gameObject);
    }
}
