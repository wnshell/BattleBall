using UnityEngine;
using System.Collections;

public class Mine2_P2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("P2UFO").GetComponentInChildren<P2_Turret>().minecount > 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
