using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public Vector2 rotMinMax = new Vector2(15, 90);
	public Vector2 driftMinMax = new Vector2(.25f, 2);
	public float lifeTime = 6f;
	public float fadeTime = 4f;
	public bool __________;
	public GameObject cube;
	public TextMesh letter;
	public Vector3 rotPerSecond;
	public float birthTime;

	void Awake(){
		cube = transform.Find ("Cube").gameObject;
		letter = GetComponent<TextMesh>();

		Vector3 vel = Random.onUnitSphere;
		vel.z = 0; 
		//make length 1
		vel.Normalize();
		vel *= Random.Range(driftMinMax.x, driftMinMax.y);
		GetComponent<Rigidbody>().velocity = vel;

		//set rotation to 0 0 0 
		transform.rotation = Quaternion.identity;

		//Set rotpersec for Cube using rotminmax x and y
		rotPerSecond = new Vector3(Random.Range(rotMinMax.x, rotMinMax.y),Random.Range(rotMinMax.x, rotMinMax.y),Random.Range(rotMinMax.x, rotMinMax.y));

		//check every 2 secs for offscreen
		InvokeRepeating("CheckOffscreen", 2f, 2f);
		birthTime = Time.time;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//rotate cube child every update
		cube.transform.rotation = Quaternion.Euler (rotPerSecond * Time.time);

		//fade it out over time
		float u = (Time.time - (birthTime + lifeTime)) / fadeTime;

		//destroy when u >= 1
		if (u >= 1) {
			Destroy (this.gameObject);
			return;
		}
		//u determines alpha of cube and letter
		if (u > 0) {
			Color c = cube.GetComponent<Renderer>().material.color;
			c.a = 1f - u;
			cube.GetComponent<Renderer>().material.color = c;
			//fade letter too, not as much
			c = letter.color;
			c.a = 1f - (u * 0.5f);
			letter.color = c;
		}
	}



}
