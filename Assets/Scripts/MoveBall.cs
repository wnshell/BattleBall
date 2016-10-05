using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	public float speed;
    public Vector3 startpos;

    //RESPAWN VARIBLES
    public float respawntime = 3;
    public float delay;
    public bool respawn = false;

    public Rigidbody ball;

	void Start(){
		ball = GetComponent<Rigidbody> ();
        startpos = ball.transform.position;
		ball.maxAngularVelocity = 20.0f;

	}

	void Update(){
		float moveX = Input.GetAxis ("Horizontal");
		float moveZ = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveX, 0.0f, moveZ);

		ball.AddForce (movement * speed);

	}

    void FixedUpdate() {
        if (delay < Time.time && respawn == true)
        {
            respawn = false;
            ball.position = startpos;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
        }

    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Goal")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            delay = Time.time + respawntime;
            respawn = true;
        }
    }
}

