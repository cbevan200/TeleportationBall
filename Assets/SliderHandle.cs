using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHandle : MonoBehaviour
{

    public UIManager ui;

    // Use this for initialization
    void Start()
    {

        ui = GameObject.FindWithTag("ui").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D Ball)

    {

        ui.IncrementScore();

    }
}
