using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandardBehavior : MonoBehaviour {
    float bulletDistance = 8.0f;
    public float bulletRange;
    private Vector3 startingPos;
	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(startingPos,transform.position) > bulletRange)
        {
            Destroy(gameObject);
        }
	}
    //void BulletRange()
    //{
    //    bulletRange = bulletDistance - 3.0f;
    //   /* if (bulletDistance > bulletRange)
    //    {
    //        Destroy(gameObject);
    //    */
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().velocity* ((bulletRange - Vector3.Distance(startingPos, transform.position))/bulletRange));
        }
        Destroy(gameObject);
    }
}
