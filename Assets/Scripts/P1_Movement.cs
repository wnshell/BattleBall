using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class P1_Movement : MonoBehaviour {

    public float boostspeed;
    public float speed;
    public float boost = 1;

	public float maxSpeed = 200.0f;

    public bool ______________________;


    public Rigidbody ufo;
    public Vector3 movement;

    // Use this for initialization
    void Start () {
        ufo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("LeftJoystickX");
        float moveZ = Input.GetAxis("LeftJoystickY");

        movement = new Vector3(moveX, 0.0f, moveZ);


        if (boost > 0)
        {
            if ((Input.GetButtonDown("LeftBumper") || Input.GetKeyDown("left shift")))
            {	

				if (movement.magnitude > 0.3f) {
					AudioSource s = GameObject.Find ("booster").GetComponent<AudioSource> ();
					s.Play ();
					ufo.velocity = boostspeed * movement.normalized;
					boost--;
                }
            }

        }
		if (ufo.velocity.magnitude <= maxSpeed) {
			ufo.AddForce (movement * speed);
		}
		if (movement.magnitude <= 0.05f) {
			ufo.AddForce (-ufo.velocity);
		}

    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "PowerUpB" && boost < 3)
        {
            boost++;

        }
        else if (collidedWith.tag == "PowerMine" && GetComponentInChildren<P1_Turret>().minecount < 3)
        {
            GetComponentInChildren<P1_Turret>().minecount++;
        }
    }
}
