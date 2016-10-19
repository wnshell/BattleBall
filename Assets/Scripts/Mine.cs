using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public float radius;
	public float power;

	public GameObject explosion;

	Vector3 explosionPos;
	SphereCollider bc;

	Rigidbody rb;

	public bool activated;

	// Use this for initialization
	void Start () {
		bc = gameObject.GetComponent<SphereCollider> ();
		bc.enabled = true;
		StartCoroutine (activateMine());
		activated = false;
		AudioSource s = GameObject.Find ("plant mine").GetComponent<AudioSource> ();
		s.Play ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision other){
		if (activated && other.gameObject.tag != "Field") {
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			foreach (Collider hit in colliders) {
				Rigidbody rb = hit.GetComponent<Rigidbody> ();

				if (rb != null)
					rb.AddExplosionForce (power, explosionPos, radius);

			}
			AudioSource s = GameObject.Find ("Explosion").GetComponent<AudioSource>();
			s.Play ();
			GameObject go = Instantiate (explosion, transform.position,Quaternion.Euler(0, 0, 0)) as GameObject;
			Destroy (this.gameObject);

		}
	}

	IEnumerator activateMine(){
		yield return new WaitForSeconds (3);
		activated = true;
		AudioSource s = GameObject.Find ("mine armed").GetComponent<AudioSource> ();
		s.Play ();
		gameObject.GetComponent<Renderer>().material.color = Color.red;

	}
}
