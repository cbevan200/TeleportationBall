﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHandle2 : MonoBehaviour
{

    public UIManager2 ui2;

    // Use this for initialization
    void Start()
    {

        ui2 = GameObject.FindWithTag("ui2").GetComponent<UIManager2>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D Ball)

    {

        ui2.IncrementScore();

    }
}
