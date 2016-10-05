using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {

	public float speed;

	private Rigidbody ball;

	void Start(){
		ball = GetComponent<Rigidbody> ();

		ball.maxAngularVelocity = 20.0f;

	}

	void Update(){
		/*float moveX = Input.GetAxis ("Horizontal");
		float moveZ = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveX, 0.0f, moveZ);

		ball.AddForce (movement * speed);*/

	}
		

}

