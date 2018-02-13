using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Vector2 defaultPos;

    // Use this for initialization
    void Start()
    {

        defaultPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        {

            transform.position = defaultPos;
        }

    }
}
