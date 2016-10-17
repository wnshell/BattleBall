using UnityEngine;
using System.Collections;

public class playerNoise : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		AudioSource s = GameObject.Find ("clink").GetComponent<AudioSource> ();
		if (other.gameObject.tag != "ball" && other.gameObject.tag != "Field"){
			s.Play ();
		}
	}

}
