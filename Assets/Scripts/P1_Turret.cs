﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class P1_Turret : MonoBehaviour {

	public float rotSpeed;
	public float bulletSpeed;
    public float minecount = 0;

    public Transform bulletOrigin;
	public Transform mineOrigin;

	public GameObject bulletPrefab;
	public GameObject minePrefab;

	// Use this for initialization
	void Start () {
		bulletOrigin = GameObject.Find ("BulletOrigin1").GetComponent<Transform>();
		mineOrigin = GameObject.Find ("MineOrigin1").GetComponent<Transform> ();
	}

	
	// Update is called once per frame
	void FixedUpdate () {

	}

	void Update(){
		GameObject[] bullets = GameObject.FindGameObjectsWithTag ("P1bullet");

		if (bullets.Length > 0) {
			foreach (GameObject go in bullets) {
				go.transform.Rotate (Vector3.up, Time.deltaTime * 1000, Space.World);
			}
		}

		float rotX = Input.GetAxis ("RightJoystickX");
		float rotY = Input.GetAxis ("RightJoystickY");

		Vector3 rightstick = new Vector3 (rotX, 0, rotY);

		float facing = Mathf.Atan2 (rotX, rotY);

		if (rightstick.magnitude > 0.4f) {
			transform.rotation = Quaternion.Euler (0f, facing * Mathf.Rad2Deg + 180, 0f);
		}

		if (Input.GetButtonDown ("RightBumper")) {
			if (countBulletsOnScreen () < 4) {
				Fire ();
			}
		}

		if (Input.GetButtonDown ("A")) {
            if (minecount > 0)
            {
                minecount--;
                GameObject mine;
                mine = Instantiate(minePrefab, mineOrigin.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }

	}

	void Fire(){
		GameObject go;
		Vector3 direction = new Vector3 (bulletOrigin.position.x - transform.position.x, 0, bulletOrigin.position.z - transform.position.z);
		go = Instantiate (bulletPrefab, bulletOrigin.position, Quaternion.Euler(0, 0, 0)) as GameObject;
		go.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
		go.tag = "P1bullet";
		go.layer = LayerMask.NameToLayer ("Bullet1");
	}

	public int countBulletsOnScreen(){
		GameObject[] getCount;
		getCount = GameObject.FindGameObjectsWithTag ("P1bullet");
		int bulletCount = getCount.Length;
		return bulletCount;
	}
}
