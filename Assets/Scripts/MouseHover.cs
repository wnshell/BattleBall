using UnityEngine;
using System.Collections;

public class MouseHover : MonoBehaviour {


    public bool isStart;
    public bool isQuit;
    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material.color = Color.white;
	}
	
	// Update is called once per frame
	void OnMouseEnter() {
        GetComponent<Renderer>().material.color = Color.black;
	}

    void OnMouseExit() {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseUp()
    {
        if (isStart)
        {
            Application.LoadLevel("MainScene");
        }
        if (isQuit)
        {
            Application.Quit();
        }
    }
}
