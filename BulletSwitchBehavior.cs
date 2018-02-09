using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwitchBehavior : MonoBehaviour {
    Vector3 tempPos;
    GameObject whoFiredMe;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag !="Immovable")
        {
            tempPos = whoFiredMe.transform.position;
            whoFiredMe.transform.position = collision.transform.position;
            collision.transform.position = tempPos;
            Destroy(gameObject);
        }
    }

    public void SetWhoFiredMe(GameObject player) {
        whoFiredMe = player;
    }


}
