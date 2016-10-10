﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class P2_Turret : MonoBehaviour {

	public float rotSpeed;
	public float bulletSpeed;

	public Transform bulletOrigin;
	public Transform mineOrigin;

	public GameObject bulletPrefab;
	public GameObject minePrefab;

	// Use this for initialization
	void Start () {
		bulletOrigin = GameObject.Find ("BulletOrigin2").GetComponent<Transform>();
		mineOrigin = GameObject.Find ("MineOrigin2").GetComponent<Transform> ();

	}


	// Update is called once per frame
	void FixedUpdate () {

	}

	void Update(){
		GameObject[] bullets = GameObject.FindGameObjectsWithTag ("P2bullet");

		if (bullets.Length > 0) {
			foreach (GameObject go in bullets) {
				go.transform.Rotate (Vector3.up, Time.deltaTime * 1000, Space.World);
			}
		}

		float rotX = Input.GetAxis("RightJoystickX_P2");

		if (rotX > 0) {
			//rotate left
			transform.Rotate(Vector3.up * rotSpeed);
		} else if (rotX < 0) {
			//rotate right
			transform.Rotate(Vector3.down * rotSpeed);
		}


		if (Input.GetButtonDown ("RightBumper_P2")) {
			if (countBulletsOnScreen () < 4) {
				Fire ();
			}
		}

		if (Input.GetButtonDown ("A_P2")) {
			GameObject mine;
			mine = Instantiate (minePrefab, mineOrigin.position, Quaternion.Euler(0, 0, 0)) as GameObject;
		}
	}

	void Fire(){
		GameObject go;
		Vector3 direction = new Vector3 (bulletOrigin.position.x - transform.position.x, 0, bulletOrigin.position.z - transform.position.z);
		go = Instantiate (bulletPrefab, bulletOrigin.position, Quaternion.Euler(0, 0, 0)) as GameObject;
		go.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
		go.tag = "P2bullet";
	}

	public int countBulletsOnScreen(){
		GameObject[] getCount;
		getCount = GameObject.FindGameObjectsWithTag ("P2bullet");
		int bulletCount = getCount.Length;
		return bulletCount;
	}
}
