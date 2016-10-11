using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public float radius;
	public float power;

	Vector3 explosionPos;
	BoxCollider bc;

	Rigidbody rb;

	public bool activated;

	// Use this for initialization
	void Start () {
		bc = gameObject.GetComponent<BoxCollider> ();
		bc.enabled = false;
		StartCoroutine (activateMine());
		activated = false;



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		if (activated) {
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			foreach (Collider hit in colliders) {
				Rigidbody rb = hit.GetComponent<Rigidbody> ();

				if (rb != null)
					rb.AddExplosionForce (power, explosionPos, radius);

			}
			Destroy (this.gameObject);

		}
	}

	IEnumerator activateMine(){
		yield return new WaitForSeconds (3);
		bc.enabled = true;
		activated = true;
		gameObject.GetComponent<Renderer>().material.color = Color.red;

	}
}
