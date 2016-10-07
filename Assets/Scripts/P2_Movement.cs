using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class P2_Movement : MonoBehaviour
{

    public float boostspeed = 100f;
    public float speed;
    public float boost = 1;
    public float deceleration = 10;
    public float maxspeed;
    public float minspeed;
    public bool ______________________;


    public Rigidbody ufo;
    public Vector3 movement;

    public Text boosttext;
    GameObject boostGO;
    // Use this for initialization
    void Start()
    {

        boostGO = GameObject.Find("BoostCount_P2");
        boosttext = boostGO.GetComponent<Text>();
        boosttext.text = "Boost: 1";

        ufo = GetComponent<Rigidbody>();
        ufo.maxAngularVelocity = 20.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("LeftJoystickX_P2");
        float moveZ = Input.GetAxis("LeftJoystickY_P2");

        movement = new Vector3(moveX, 0.0f, moveZ);

        if (boost > 0)
        {
            if ((Input.GetButtonDown("RightBumper_P2") || Input.GetKeyDown("left shift")) && speed == maxspeed)
            {
                speed = speed + boostspeed;
                boost--;
                boosttext.text = "Boost: " + boost.ToString();
            }

        }
        if (maxspeed < speed)
        {
            speed = speed - deceleration;
        }

        ufo.velocity = movement * speed;
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "PowerUpB" && boost < 3)
        {
            boost++;
            boosttext.text = "Boost: " + boost.ToString();

        }
    }
}
