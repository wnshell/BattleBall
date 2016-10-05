using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{

    public float speed;
    public float maxSpeed;

    public bool ________________________;

    public Rigidbody car;
    // Use this for initialization
    void Start()
    {
        car = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {
    }

    //Physics updater
    void FixedUpdate()
    {

    }
}