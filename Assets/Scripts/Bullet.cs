using UnityEngine;
using System.Collections;


public class Bullet : MonoBehaviour {

	public GameObject flash;
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
		GameObject go;
		go = Instantiate(flash, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
		GameObject.Find ("bulletthud").GetComponent<AudioSource> ().Play ();
		Destroy (this.gameObject);

	}


}
