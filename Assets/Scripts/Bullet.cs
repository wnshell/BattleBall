using UnityEngine;
using System.Collections;


public class Bullet : MonoBehaviour {

	Vector3 bulletOrigin;

	void Start() {
		bulletOrigin = transform.position;
	}


	void FixedUpdate() {

	}

	void OnCollisionEnter(Collision other) {
		Destroy (this.gameObject);
	}


}
