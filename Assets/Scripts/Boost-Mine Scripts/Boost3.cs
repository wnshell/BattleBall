﻿using UnityEngine;
using System.Collections;

public class Boost3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInParent<P1_Movement>().boost > 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
	}
}
