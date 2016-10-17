using UnityEngine;
using System.Collections;

public class Mine1_P3 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("P3UFO").GetComponentInChildren<P3_Turret>().minecount > 0)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
