using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerMine : MonoBehaviour {

    public float respawntime = 10;
    public bool ____________________;
    public float boostcount; 
    public float delay;
    public bool respawn = false;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (delay < Time.time && respawn == true) {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
        }

	}
    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Car")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            delay = Time.time + respawntime;
            respawn = true;
			AudioSource s = GameObject.Find ("pickup").GetComponent<AudioSource>();
			s.Play ();
        }
    }
}
