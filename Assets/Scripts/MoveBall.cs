using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	public float speed;
    public Vector3 startpos;

    //RESPAWN VARIBLES
    public float respawntime = 3;
    public float delay;
    public bool respawn = false;

	public AudioSource bounce;

    public Rigidbody ball;

	void Start(){
		ball = GetComponent<Rigidbody> ();
        startpos = ball.transform.position;
		ball.maxAngularVelocity = 20.0f;
		bounce = GameObject.Find ("ball bounce").GetComponent<AudioSource> ();
	}

	void Update(){
		/*
		float moveX = Input.GetAxis ("Left Stick X Axis");
		float moveZ = Input.GetAxis ("Left Stick Y Axis");

		Vector3 movement = new Vector3 (moveX, 0.0f, moveZ);

		ball.AddForce (movement * speed);
		*/
	}

    void FixedUpdate() {
        if (delay < Time.time && respawn == true)
        {
            respawn = false;
            ball.position = startpos;
            ball.constraints = RigidbodyConstraints.None;
            ball.constraints = RigidbodyConstraints.FreezePositionY;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Collider>().enabled = true;
        }

    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Goal")
        {
			AudioSource s = GameObject.Find ("cheer").GetComponent<AudioSource> ();
			s.Play ();
            if (collidedWith.name == "Goal1")
            {
                GameObject.Find("Main Camera").GetComponent<ScoreTracker>().scoredp1 = true;
            }
            else
            {
                GameObject.Find("Main Camera").GetComponent<ScoreTracker>().scoredp2 = true;
            }
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            ball.constraints = RigidbodyConstraints.FreezeAll;
            delay = Time.time + respawntime;
            respawn = true;
        }
    }

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag != "Field") {
			bounce.Play ();
		}
	}
}

