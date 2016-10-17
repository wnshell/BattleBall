using UnityEngine;
using System.Collections;


public class Bullet : MonoBehaviour {

	Vector3 bulletOrigin;
	public AudioSource s;

	void Start() {
		bulletOrigin = transform.position;
		s = GameObject.Find ("Gunshot").GetComponent<AudioSource> ();
		s.Play();
	}


	void FixedUpdate() {

	}

	void OnCollisionEnter(Collision other) {
		Destroy (this.gameObject);
	}


}
