using UnityEngine; 
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement_P2 : MonoBehaviour  
{

    public float speed = 0;
    public float maxspeed = 40;
    public float boostspeed = 40;

    public float reversespeed = -.5f;
    public float reversespeedmax = -10;

    public float acceleration = 1f;
    public float deceleration = .8f;

    public float turnspeed = 100;

    public float boost = 3;


     public bool ______________________;

    public Text boosttext;
    GameObject boostGO;

    public Vector3 movementVector;
    public Transform rotationvector;
    public Rigidbody rigid;

    public bool move;
    public bool reverse;

    void Start()
      {
        boostGO = GameObject.Find("BoostCount_P2");
        boosttext = boostGO.GetComponent<Text>();
        boosttext.text = "Boost: 3";

        rigid = GetComponent<Rigidbody>();
      }

    void FixedUpdate() {

        //Deals with A and B accelration and deceleration

        if (move == true && maxspeed > speed)
        {
            speed = speed + acceleration;
        }

        if (reverse == true && reversespeedmax < speed)
        {
            speed = speed + reversespeed;
        }


        //Deals with passive stopping and slowing after boost
        if (reverse == false && move == false)
        {
            if (speed < -1f)
            {
                speed = speed + deceleration;
            }
            else if (speed > 1f)
            {
                speed = speed - deceleration;
            }
            else
            {
                speed = 0;
            }
        }
        else if (maxspeed < speed) {
            speed = speed - deceleration;
        }
        else if (reversespeedmax > speed)
        {
            speed = speed + deceleration;
        }

        //Turning
        if (speed > 2f || speed < -1f)
        {
            transform.Rotate(new Vector3(Input.GetAxis("LeftJoystickX_P2"), 0, 0) * Time.deltaTime * turnspeed);
            transform.Rotate(new Vector3(Input.GetAxis("LeftJoystickY_P2"), 0, 0) * Time.deltaTime * turnspeed);

            if (Input.GetKey("a"))
            {
                transform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * turnspeed);
            }
            else if (Input.GetKey("d"))
            { 
               transform.Rotate(new Vector3(1, 0, 0) * Time.deltaTime * turnspeed);
            }
        }

        movementVector = speed * transform.forward;
        rigid.velocity = movementVector;
    }

    void Update()  
    {
        //Inputs from player one
        if (Input.GetButton("A_P2") || Input.GetKey("w"))
        {
            move = true;
        }
        else
        {
            move = false;
        }

        if (Input.GetButton("B_P2") || Input.GetKey("s"))
        {
            reverse = true;
        }
        else
        {
            reverse = false;
        }
        if (boost > 0) {
            if (Input.GetButtonDown("RightBumper_P2") || Input.GetKeyDown("left shift")) {
                speed = speed + boostspeed;
                boost--;
                boosttext.text = "Boost: " + boost.ToString();
            }
            else if (Input.GetButtonDown("LeftBumper_P2") || Input.GetKeyDown("space"))
            {
                speed = speed - boostspeed * 1.5f;
                boost--;
                boosttext.text = "Boost: " + boost.ToString();
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "PowerUpB" && boost < 6) {
            boost = boost + 3;
            boosttext.text = "Boost: " + boost.ToString();

        }
    }
    
 }