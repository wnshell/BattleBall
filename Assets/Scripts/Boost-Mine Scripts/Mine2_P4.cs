﻿using UnityEngine;
using System.Collections;

public class Mine2_P4 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("P4UFO").GetComponentInChildren<P4_Turret>().minecount > 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
