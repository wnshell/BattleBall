using UnityEngine;
using System.Collections;

public class Boost2_P2: MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInParent<P2_Movement>().boost > 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
	}
}
