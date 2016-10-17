using UnityEngine;
using System.Collections;

public class MouseHoverGame : MonoBehaviour {


    public bool isStart;
    public bool isQuit;
    public bool isstart4p;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().material.color = Color.black;
	}
	
	// Update is called once per frame
	void OnMouseEnter() {
        GetComponent<Renderer>().material.color = Color.red;
	}

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = Color.black;
    }

    void OnMouseUp()
    {
        if (isStart)
        {
            Application.LoadLevel("MainScene");
        }
        if (isstart4p)
        {
            Application.LoadLevel("MainScene4p");
        }
        if (isQuit)
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
